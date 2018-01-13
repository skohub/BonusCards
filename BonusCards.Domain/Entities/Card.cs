using System;
using System.Collections.Generic;
using System.Linq;
using BonusCards.Domain.BonusCalcStrategies;
using BonusCards.Domain.Exceptions;

namespace BonusCards.Domain.Entities
{
    public class Card
    {
        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<Purchase> Purchases { get; set; } = new List<Purchase>();
        public List<Withdraw> Withdraws { get; set; } = new List<Withdraw>();

        public int GetAvailableBonuses()
        {
            var obtained = Purchases.Sum(p => p.Bonus);
            var spent = Withdraws.Sum(w => w.Amount);
            return obtained - spent;
        }

        public void AddWithdraw(int amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Should not be negative", nameof(amount));
            }
            if (GetAvailableBonuses() - amount < 0)
            {
                throw new DomainValidationException("Not enough bonuses");
            }

            var withdraw = new Withdraw
            {
                CardId = Id,
                Amount = amount
            };

            Withdraws.Add(withdraw);
        }

        public void AddPurchase(int price, IBonusCalcStrategy bonusCalculator)
        {
            if (price < 0)
            {
                throw new ArgumentException("Should not be negative", nameof(price));
            }

            var purchase = new Purchase
            {
                CardId = Id,
                Price = price,
                Bonus = bonusCalculator.Calc(price)
            };

            Purchases.Add(purchase);
        }
    }
}
