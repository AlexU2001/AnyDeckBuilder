namespace AnyDeckBuilder
{
    public struct AspectRatio
    {
        private const int AspectMultiplier = 25;
        public int width;
        public int height;

        public Size GetSize(int index)
        {
            return new Size((width * AspectMultiplier) * index, (height * AspectMultiplier) * index);
        }
    }
}
