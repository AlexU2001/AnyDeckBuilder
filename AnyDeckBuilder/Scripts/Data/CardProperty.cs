using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

namespace AnyDeckBuilder.Data
{
    public enum ControlType { Text, Number, DropDown, DropDownMultiSelect }
    public struct CardProperty : IEquatable<CardProperty>
    {
        /// <summary>
        /// Display name of the card property
        /// </summary>
        public string Name;
        /// <summary>
        /// How the card property values should be interpreted
        /// </summary>
        public ControlType controlType;
        /// <summary>
        /// If multiple values can be accepted
        /// </summary>
        public string[]? Values;
        [JsonIgnore]
        public string Value => Values == null ? string.Empty : Values[0];
        [JsonIgnore] 
        public bool isValid => (controlType.Equals(ControlType.Text) || controlType.Equals(ControlType.Number)) || (Values != null && Values.Length > 0);

        /// <summary>
        /// If the property should be treated as a tag when exporting to other platforms. Example, Table Top Simulator
        /// </summary>
        public bool propertyAsTag = false;

        public CardProperty()
        {
            Name = "Property";
            controlType = ControlType.Text;
        }

        public void SetValue(params string[] values)
        {
            if (values == null || values.Length == 0)
                return;

            Values = values;
        }

        #region Other
        public bool Equals(CardProperty other)
        {
            return Name.Equals(other.Name) && controlType.Equals(other.controlType);
        }

        public override bool Equals([NotNullWhen(true)] object? obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() == typeof(CardProperty))
                return Equals((CardProperty)obj);
            return base.Equals(obj);
        }
        public static bool operator ==(CardProperty left, CardProperty right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CardProperty left, CardProperty right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return $"Property Name: {Name} Control Type: {controlType}";
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, controlType, Values);
        }

        public void ClearValues()
        {
            Values = new string[0];
        }
        #endregion
    }
}
