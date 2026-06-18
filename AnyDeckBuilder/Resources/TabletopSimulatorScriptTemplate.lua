-- Settings
DECK_DISPLACEMENT_X = 3.1
-- Run Time Variables
data = nil

function onLoad()
    local params = {
        click_function = "click_func",
        function_owner = self,
        label = "Spawn Deck",
        position = {0, 1, 0},
        width = 800,
        height = 400,
        font_size = 340,
        color = {0.5, 0.5, 0.5},
        font_color = {1, 1, 1},
        tooltip = "Spawns decks according to the json data, assigns metadata and then deletes this object."
    }
    self.createButton(params)
end

function click_func(obj, color, alt_click) spawnDecks() end

function spawnDecks() 
  if data == nil then 
    GetData() 
  end
  for index, value in ipairs(data["decks"]) do
    spawnDeckObject(value, self.getPosition() + Vector(DECK_DISPLACEMENT_X, 0, 0) * index)
  end
end

function spawnDeckObject(deckData, position)
  if position == nil then
    position = self.getPosition()
  end

  if deckData == nil then
    log("Nil reference exception, failed to spawn deck")
    return
  end
    local object = spawnObject({
        type = "DeckCustom",
        position = position,
        callback_function = function(spawned_object)
            local params = {
                face = deckData["exportPath"],
                back = deckData["backImagePath"],
                width = deckData["exportX"],
                height = deckData["exportY"],
                number = #deckData["cards"],
                sideways = false,
                back_is_hidden = true
            }
            spawned_object.setCustomObject(params)
            outputPosition = position
            TrySetData(spawned_object)
        end
    })
end

function TrySetData(deck)
    local cards = deck.getObjects(true)
    local length = #cards
    for index, value in ipairs(cards) do
        if (index == length) then
            SetData(deck.remainder, index)
            return
        end

        local card = deck.takeObject({guid = value.guid})
        SetData(card, index)
    end
end

function SetData(cardObj, index)
    if data == nil then GetData() end

    local guid = data["decks"][1]["cards"][index]
    local cardData = GetCardDataFromGUID(guid)

    cardObj.setName(cardData["name"])
    cardObj.setDescription(cardData["description"])
    local tags = GetTagsFromCardData(cardData) 
    if tags != nil then
      cardObj.setTags(tags)
    end
    cardObj.setPosition(Vector(outputPosition) + Vector(0, index * 0.1, 0))
end

function GetCardDataFromGUID(guid)
    if data == nil then GetData() end

    return data["cardsDict"][guid]
end

function GetData() data = JSON.decode(jsonString) end

function GetTagsFromCardData(cardData)
  if cardData["properties"] == nil then
    return nil
  end

  local tags = {}
  local nextIndex = 1
  for index, property in ipairs(cardData["properties"]) do
    if property["propertyAsTag"] == nil then
        goto skip_property
    end
    if property["propertyAsTag"] == true then
        for j, value in ipairs(property["Values"]) do
            tags[nextIndex] = value
            nextIndex = nextIndex + 1
        end
    end
    ::skip_property::
  end

  return tags
end