namespace BonusCards.Domain.Entities
{
    public class Withdraw
    {
        public int Id { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
        public int Amount { get; set; }
    }
}
