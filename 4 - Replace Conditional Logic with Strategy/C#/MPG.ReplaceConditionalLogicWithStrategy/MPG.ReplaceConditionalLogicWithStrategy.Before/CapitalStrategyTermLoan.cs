using System.Linq;

namespace MPG.ReplaceConditionalLogicWithStrategy.Before
{
    public class CapitalStrategyTermLoan : CapitalStrategy
    {
        public override double Capital(Loan loan)
        {
            return loan.GetCommitment() * loan.Duration() * RiskFactor(loan);
        }

        public override double Duration(Loan loan)
        {
            return WeightedAverageDuration(loan);
        }

        private double WeightedAverageDuration(Loan loan)
        {
            var duration = 0.0;
            var weightedAverage = loan.GetPayments().Sum(payment => YearsTo(payment.Date, loan) * payment.Amount);
            var sumOfPayments = loan.GetPayments().Sum(payment => payment.Amount);

            if (loan.GetCommitment() != 0.0)
            {
                duration = weightedAverage / sumOfPayments;
            }

            return duration;
        }
    }
}