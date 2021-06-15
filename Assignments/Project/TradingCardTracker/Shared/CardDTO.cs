namespace SharedComponents
{
    public abstract class CardDTO
    {
        public int CardID { get; set; }
        public string Title { get; set; }
        public int CardNumber { get; set; }
        public int CardCount { get; set; }
        public decimal Value { get; set; }
        public string ReleaseYear { get; set; }
        public string Notes { get; set; }
        public Condition CardCondition { get; set; }
        public CardType TypeOfCard { get; set; }
        public string CardFranchise { get; set; }
        public byte[] Image { get; set; }
    }
}
