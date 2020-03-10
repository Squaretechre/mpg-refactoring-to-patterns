import CapitalStrategy from "./CapitalStrategy";

export default class CapitalStrategyRevolver extends CapitalStrategy{
    capital(loan) {
        return (loan.getOutstandingRiskAmount() * this.duration(loan) * this.riskFactor(loan)) +
            (loan.unusedRiskAmount() * this.duration(loan) * this.unusedRiskFactor(loan));
    }
}