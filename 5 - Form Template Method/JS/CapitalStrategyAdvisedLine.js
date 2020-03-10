import CapitalStrategy from "./CapitalStrategy";

export default class CapitalStrategyAdvisedLine extends CapitalStrategy{
    capital(loan) {
        return loan.getCommitment() * loan.getUnusedPercentage() * this.duration(loan) * this.riskFactor(loan)
    }
}