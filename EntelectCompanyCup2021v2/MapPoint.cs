using System;

namespace EntelectCompanyCup2021v2
{
    public class MapPoint
    {
        public static char DefaultValue = '#';
        public char Value { get; }
        public bool IsBase
        {
            get
            {
                return char.IsUpper(Value);
            }
        }
        public bool IsWood
        {
            get
            {
                return char.IsLower(Value);
            }
        }
        public int X { get; }
        public int Y { get; }
        public bool CanTraverse { get
            {
                return Value == DefaultValue;
            } 
        }

        public MapPoint(char value, int x, int y)
        {
            Value = value;
            X = x;
            Y = y;
        }
        
    }
}
