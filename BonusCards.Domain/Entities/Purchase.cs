namespace BonusCards.Domain.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
        public int Price { get; set; }
        public int Bonus { get; set; }
    }
}
