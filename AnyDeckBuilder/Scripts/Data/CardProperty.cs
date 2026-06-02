namespace AnyDeckBuilder.Data
{
    public enum ControlType { Text, Number, DropDown }
    public struct CardProperty
    {
        // Base Properties
        public string Name;
        public string Value => Options[0];
        /// <summary>
        /// How the card property values should be interpreted
        /// </summary>
        public ControlType controlType;

        // Drop Down Properties
        public bool MultipleSelect;
        /// <summary>
        /// Parallel array for Options
        /// </summary>
        public bool[] SelectedOptions;
        public string[] Options;

        public bool ShouldSerializeMultipleSelect()
        {
            return MultipleSelect;
        }
    }
}
