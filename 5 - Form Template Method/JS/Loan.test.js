import Loan from "./Loan"

describe('Loan', () => {
  const loanAmount = 10000
  const highRiskRating = 1

  it('capital term loan', () => {
    const start = new Date(2003, 11, 20)
    const maturity = new Date(2006, 11, 20)
    const termLoan = Loan.NewTermLoan(loanAmount, start, maturity, highRiskRating)

    termLoan.payment(1000, new Date(2004, 11, 20))
    termLoan.payment(1000, new Date(2005, 11, 20))
    termLoan.payment(1000, new Date(2006, 11, 20))

    expect(termLoan.duration()).toBe(2)
    expect(termLoan.capital()).toBe(210)
  })

  it('capital advised line', () => {
    const start = new Date(2003, 11, 20)
    const expiry = new Date(2005, 11, 20)
    const loan = Loan.NewAdvisedLine(loanAmount, start, expiry, highRiskRating)

    expect(loan.duration()).toBe(2)
    expect(loan.capital()).toBe(21)
  })

  it('capital revolver', () => {
    const start = new Date(2003, 11, 20)
    const expiry = new Date(2006, 11, 20)
    const loan = Loan.NewRevolver(loanAmount, start, expiry, highRiskRating)

    expect(loan.duration()).toBe(3)
    expect(loan.capital()).toBe(315)
  })
})
