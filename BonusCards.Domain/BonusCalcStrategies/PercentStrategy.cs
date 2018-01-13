namespace BonusCards.Domain.BonusCalcStrategies
{
    public class PercentStrategy : IBonusCalcStrategy
    {
        private readonly int _percent;

        public PercentStrategy(int percent)
        {
            _percent = percent;
        }

        public int Calc(int price)
        {
            return price * _percent / 100;
        }
    }
}
