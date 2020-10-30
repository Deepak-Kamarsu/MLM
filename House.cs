namespace MLM
{
    public class House
    {
        public int Number { get; set; }
        public House Left { get; set; }
        public House Top { get; set; }
        public House Right { get; set; }
        public House Bottom { get; set; }
        public bool IsInvaded { get; set; }
    }
}
