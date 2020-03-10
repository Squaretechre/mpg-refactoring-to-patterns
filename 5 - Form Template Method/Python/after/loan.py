from after.capital_strategy_advised_line import CapitalStrategyAdvisedLine
from after.capital_strategy_revolver import CapitalStrategyRevolver
from after.capital_strategy_term_loan import CapitalStrategyTermLoan
from after.payment import Payment


class Loan:
    def __init__(self, commitment, outstanding, risk_rating, maturity, expiry, start, today, capital_strategy):
        self.commitment = commitment
        self.outstanding = outstanding
        self.risk_rating = risk_rating
        self.maturity = maturity
        self.expiry = expiry
        self.start = start
        self.today = today
        self.unused_percentage = 1.0
        self.payments = []
        self.capital_strategy = capital_strategy

    def duration(self):
        return self.capital_strategy.duration(self)

    def capital(self):
        return self.capital_strategy.capital(self)

    def payment(self, amount, date):
        self.payments.append(Payment(amount, date))

    def outstanding_risk_amount(self):
        return self.outstanding

    def set_unused_percentage(self, unused_percentage):
        self.unused_percentage = unused_percentage

    def get_unused_percentage(self):
        return self.unused_percentage

    def get_commitment(self):
        return self.commitment

    def get_today(self):
        return self.today

    def get_start(self):
        return self.start

    def get_expiry(self):
        return self.expiry

    def get_payments(self):
        return self.payments

    def get_risk_rating(self):
        return self.risk_rating

    def unused_risk_amount(self):
        return self.commitment - self.outstanding

    @staticmethod
    def new_term_loan(commitment, start, maturity, risk_rating):
        return Loan(commitment, commitment, risk_rating, maturity, None, start, None, CapitalStrategyTermLoan())

    @staticmethod
    def new_revolver(commitment, start, expiry, risk_rating):
        return Loan(commitment, 0.0, risk_rating, None, expiry, start, None, CapitalStrategyRevolver())

    @staticmethod
    def new_advised_line(commitment, start, expiry, risk_rating):
        if risk_rating > 3:
            return None
        advised_line = Loan(commitment, 0.0, risk_rating, None, expiry, start, None, CapitalStrategyAdvisedLine())
        advised_line.set_unused_percentage(0.1)
        return advised_line
