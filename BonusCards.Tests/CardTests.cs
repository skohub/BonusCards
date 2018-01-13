using System;
using BonusCards.Domain.BonusCalcStrategies;
using BonusCards.Domain.Entities;
using BonusCards.Domain.Exceptions;
using Xunit;

namespace BonusCards.Tests
{
    public class CardTests
    {
        [Fact]
        public void TestAddPurchase()
        {
            // Arrange
            const int price = 100;
            const int percent = 10;
            const int expected = 10;
            var calculator = new PercentStrategy(percent);
            var card = new Card();

            // Act
            card.AddPurchase(price, calculator);

            // Assert
            Assert.Equal(expected, card.GetAvailableBonuses());
        }

        [Fact]
        public void TestSuccessfulWithdraw()
        {
            // Arrange
            const int price = 100;
            const int percent = 10;
            const int withdraw = 4;
            const int expected = 6;
            var calculator = new PercentStrategy(percent);
            var card = new Card();
            card.AddPurchase(price, calculator);

            // Act
            card.AddWithdraw(withdraw);

            // Assert
            Assert.Equal(expected, card.GetAvailableBonuses());
        }

        [Fact]
        public void TestPurchaseWithNegativePrice()
        {
            // Arrange
            const int price = -10;
            var card = new Card();
            void Action() => card.AddPurchase(price, new PercentStrategy(0));

            // Act
            Assert.Throws<ArgumentException>((Action) Action);

            // Assert
            Assert.Equal(0, card.GetAvailableBonuses());
        }

        [Fact]
        public void TestNegativeWithdraw()
        {
            // Arrange
            const int amount = -10;
            var card = new Card();
            void Action() => card.AddWithdraw(amount);

            // Act
            Assert.Throws<ArgumentException>((Action) Action);

            // Assert
            Assert.Equal(0, card.GetAvailableBonuses());
        }

        [Fact]
        public void TestInsufficientBonuses()
        {
            // Arrange
            const int price = 100;
            const int percent = 100;
            const int withdraw = 150;
            var card = new Card();
            card.AddPurchase(price, new PercentStrategy(percent));
            void Action() => card.AddWithdraw(withdraw);

            // Act
            Assert.Throws<DomainValidationException>((Action) Action);

            // Assert
            Assert.Equal(price, card.GetAvailableBonuses());
        }
    }
}
