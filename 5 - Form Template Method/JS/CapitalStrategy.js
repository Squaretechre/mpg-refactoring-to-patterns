import RiskFactors from "./RiskFactors";
import UnusedRiskFactors from "./UnusedRiskFactors";

export default class CapitalStrategy {
    constructor() {
        this.millisPerDay = 86400000
        this.daysPerYear = 365
    }

    capital(loan) {
        throw new Error("implement in sub type")
    }

    riskFactor(loan) {
        return RiskFactors.ForRating(loan.getRiskRating())
    }

    unusedRiskFactor(loan){
        return UnusedRiskFactors.ForRating(loan.getRiskRating())
    }

    duration(loan){
        return this.yearsTo(loan.getExpiry(), loan)
    }

    yearsTo(endDate, loan) {
        const beginDate = loan.getToday() || loan.getStart()
        return Math.floor(((endDate - beginDate) / this.millisPerDay / this.daysPerYear))
    }
}