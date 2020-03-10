from datetime import datetime
from unittest import TestCase
from after.loan import Loan


class TestCapitalCalculation(TestCase):
    HIGH_RISK_RATING = 1
    LOAN_AMOUNT = 10000

    def test_capital_term_loan(self):
        start = datetime(2003, 11, 20)
        maturity = datetime(2006, 11, 20)
        term_loan = Loan.new_term_loan(self.LOAN_AMOUNT, start, maturity, self.HIGH_RISK_RATING)

        term_loan.payment(1000.00, datetime(2004, 11, 20))
        term_loan.payment(1000.00, datetime(2005, 11, 20))
        term_loan.payment(1000.00, datetime(2006, 11, 20))

        self.assertEqual(2, term_loan.duration())
        self.assertEqual(210, term_loan.capital())

    def test_capital_advised_line(self):
        start = datetime(2003, 11, 20)
        expiry = datetime(2005, 11, 20)
        advised_line = Loan.new_advised_line(self.LOAN_AMOUNT, start, expiry, self.HIGH_RISK_RATING)

        self.assertEqual(2, advised_line.duration())
        self.assertEqual(21, advised_line.capital())

    def test_capital_revolver(self):
        start = datetime(2003, 11, 20)
        expiry = datetime(2006, 11, 20)
        revolver = Loan.new_revolver(self.LOAN_AMOUNT, start, expiry, self.HIGH_RISK_RATING)

        self.assertEqual(3, revolver.duration())
        self.assertEqual(315, revolver.capital())

