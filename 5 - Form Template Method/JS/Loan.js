import Payment from "./Payment";
import CapitalStrategyTermLoan from "./CapitalStrategyTermLoan";
import CapitalStrategyRevolver from "./CapitalStrategyRevolver";
import CapitalStrategyAdvisedLine from "./CapitalStrategyAdvisedLine";

export default class Loan {
  constructor (
    commitment,
    outstanding,
    riskRating,
    maturity,
    expiry,
    start,
    today,
    capitalStrategy
  ) {
    this._payments = []
    this._commitment = commitment
    this._outstanding = outstanding
    this._riskRating = riskRating
    this._maturity = maturity
    this._expiry = expiry
    this._start = start
    this._today = today
    this._unusedPercentage = 1
    this._capitalStrategy = capitalStrategy
  }

  setUnusedPercentage(value) {
    this._unusedPercentage = value
  }

  getUnusedPercentage() {
    return this._unusedPercentage;
  }

  duration () {
    return this._capitalStrategy.duration(this);
  }

  capital() {
    return this._capitalStrategy.capital(this);
  }

  getExpiry() {
    return this._expiry;
  }

  payment (amount, date) {
    this._payments.push(new Payment(amount, date))
  }

  getPayments() {
    return this._payments;
  }

  getStart() {
    return this._start;
  }

  getToday() {
    return this._today;
  }

  unusedRiskAmount () {
    return this.getCommitment() - this.getOutstandingRiskAmount()
  }

  getOutstandingRiskAmount() {
    return this._outstanding;
  }

  getCommitment() {
    return this._commitment;
  }

  getRiskRating() {
    return this._riskRating;
  }

  static NewTermLoan (commitment, start, maturity, riskRating) {
    return new Loan(commitment, commitment, riskRating, maturity, undefined, start, undefined, new CapitalStrategyTermLoan())
  }

  static NewRevolver (commitment, start, expiry, riskRating) {
    return new Loan(commitment, 0, riskRating, undefined, expiry, start, undefined, new CapitalStrategyRevolver())
  }

  static NewAdvisedLine (commitment, start, expiry, riskRating) {
    if (riskRating > 3) return undefined

    const advisedLine = new Loan(commitment, 0, riskRating, undefined, expiry, start, undefined, new CapitalStrategyAdvisedLine())
    advisedLine.setUnusedPercentage(0.1)

    return advisedLine
  }
}
