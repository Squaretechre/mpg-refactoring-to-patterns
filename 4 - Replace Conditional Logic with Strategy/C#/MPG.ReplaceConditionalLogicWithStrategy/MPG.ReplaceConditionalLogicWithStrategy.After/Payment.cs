using System;

namespace MPG.ReplaceConditionalLogicWithStrategy.After
{
    public class Payment
    {
        public Payment(double amount, DateTime date)
        {
            Amount = amount;
            Date = date;
        }

        public double Amount { get; internal set; }
        public DateTime Date { get; internal set; }
    }
}