namespace BricksBreaker.Data
{
    public class BrickData
    {
        public int Value { get; set; }
        public int Order { get; set; }

        public BrickData(int value, int order)
        {
            Value = value;
            Order = order;
        }
    }
}

