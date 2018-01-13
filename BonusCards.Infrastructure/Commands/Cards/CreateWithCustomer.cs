namespace BonusCards.Infrastructure.Commands.Cards
{
    public class CreateWithCustomer
    {
        public int OrganizationId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
    }
}
