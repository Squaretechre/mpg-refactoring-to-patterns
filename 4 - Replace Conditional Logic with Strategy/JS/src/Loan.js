import Payment from "./Payment";
import RiskFactors from "./RiskFactors";
import UnusedRiskFactors from "./UnusedRiskFactors";

export default class Loan {
  constructor (
    commitment,
    outstanding,
    riskRating,
    maturity,
    expiry,
    start,
    today
  ) {
    this.millisPerDay = 86400000
    this.daysPerYear = 365
    this._payments = []
    this._commitment = commitment
    this._outstanding = outstanding
    this._riskRating = riskRating
    this._maturity = maturity
    this._expiry = expiry
    this._start = start
    this._today = today
    this._unusedPercentage = 1
  }

  setUnusedPercentage(value) {
    this._unusedPercentage = value
  }

  duration () {
    if (!this._expiry && this._maturity) {
      return this.weightedAverageDuration()
    } else if (this._expiry && !this._maturity) {
      return this.yearsTo(this._expiry)
    } else {
      return 0
    }
  }

  capital() {
    if (!this._expiry && this._maturity) {
      // term loan
      return this._commitment * this.duration() * this.riskFactor()
    }

    if (this._expiry && !this._maturity) {
      if (this._unusedPercentage !== 1.0) {
        // advised line
        return this._commitment * this._unusedPercentage * this.duration() * this.riskFactor()
      } else {
        // revolver
        return (this._outstanding * this.duration() * this.riskFactor())
          + (this.unusedRiskAmount() * this.duration() * this.unusedRiskFactor())
      }
    }

    return 0
  }

  payment (amount, date) {
    this._payments.push(new Payment(amount, date))
  }

  weightedAverageDuration () {
    let duration = 0
    const weightedAverage = this._payments
      .map(payment => this.yearsTo(payment.date) * payment.amount)
      .reduce((a, b) => a + b)

    const sumOfPayments = this._payments
      .map(payment => payment.amount)
      .reduce((a, b) => a + b)

    if (this._commitment !== 0.0) {
      duration = weightedAverage / sumOfPayments
    }

    return duration
  }

  yearsTo (endDate) {
    const beginDate = this._today || this._start
    return Math.floor(((endDate - beginDate) / this.millisPerDay / this.daysPerYear))
  }

  unusedRiskAmount () {
    return this._commitment - this._outstanding
  }

  riskFactor () {
    return RiskFactors.ForRating(this._riskRating)
  }

  unusedRiskFactor () {
    return UnusedRiskFactors.ForRating(this._riskRating)
  }

  static NewTermLoan (commitment, start, maturity, riskRating) {
    return new Loan(commitment, commitment, riskRating, maturity, undefined, start, undefined)
  }

  static NewRevolver (commitment, start, expiry, riskRating) {
    return new Loan(commitment, 0, riskRating, undefined, expiry, start, undefined)
  }

  static NewAdvisedLine (commitment, start, expiry, riskRating) {
    if (riskRating > 3) return undefined

    const advisedLine = new Loan(commitment, 0, riskRating, undefined, expiry, start, undefined)
    advisedLine.setUnusedPercentage(0.1)

    return advisedLine
  }
}
