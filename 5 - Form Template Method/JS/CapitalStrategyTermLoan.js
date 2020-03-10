import CapitalStrategy from "./CapitalStrategy";

export default class CapitalStrategyTermLoan extends CapitalStrategy{
    capital(loan) {
        return loan.getCommitment() * this.duration(loan) * this.riskFactor(loan)
    }

    duration(loan) {
        return this.weightedAverageDuration(loan);
    }

    weightedAverageDuration(loan) {
        let duration = 0
        const weightedAverage = loan.getPayments()
            .map(payment => this.yearsTo(payment.date, loan) * payment.amount)
            .reduce((a, b) => a + b)

        const sumOfPayments = loan.getPayments()
            .map(payment => payment.amount)
            .reduce((a, b) => a + b)

        if (this._commitment !== 0.0) {
            duration = weightedAverage / sumOfPayments
        }

        return duration
    }
}