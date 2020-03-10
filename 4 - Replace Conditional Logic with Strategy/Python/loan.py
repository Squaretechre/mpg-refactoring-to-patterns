from payment import Payment
from risk_factors import RiskFactors
from unused_risk_factors import UnusedRiskFactors
from dateutil.relativedelta import relativedelta


class Loan:
    def __init__(self, commitment, outstanding, risk_rating, maturity, expiry, start, today):
        self.commitment = commitment
        self.outstanding = outstanding
        self.risk_rating = risk_rating
        self.maturity = maturity
        self.expiry = expiry
        self.start = start
        self.today = today
        self.unused_percentage = 1.0
        self.payments = []

    def set_unused_percentage(self, unused_percentage):
        self.unused_percentage = unused_percentage

    def duration(self):
        if self.expiry is None and self.maturity is not None:
            return self.weighted_average_duration()
        elif self.expiry is not None and self.maturity is None:
            return self.years_to(self.expiry)

        return 0.0

    def capital(self):
        if self.expiry is None and self.maturity is not None:
            return self.commitment * self.duration() * self.risk_factor()

        if self.expiry is not None and self.maturity is None:
            if self.get_unused_percentage() != 1.0:
                return self.commitment * self.get_unused_percentage() * self.duration() * self.risk_factor()
            else:
                return (self.outstanding_risk_amount() * self.duration() * self.risk_factor()) \
                       + (self.unused_risk_amount() * self.duration() * self.unused_risk_factor())

        return 0.0

    def payment(self, amount, date):
        self.payments.append(Payment(amount, date))

    def outstanding_risk_amount(self):
        return self.outstanding

    def get_unused_percentage(self):
        return self.unused_percentage

    def unused_risk_amount(self):
        return self.commitment - self.outstanding

    def weighted_average_duration(self):
        duration = 0.0
        weighted_average = 0.0
        sum_of_payments = 0.0

        for payment in self.payments:
            weighted_average += self.years_to(payment.date) * payment.amount
            sum_of_payments += payment.amount

        if self.commitment != 0.0:
            duration = weighted_average / sum_of_payments

        return duration

    def years_to(self, end_date):
        begin_date = self.today if self.today is not None else self.start
        difference = relativedelta(end_date, begin_date)
        return difference.years

    def risk_factor(self):
        return RiskFactors.for_rating(self.risk_rating)

    def unused_risk_factor(self):
        return UnusedRiskFactors.for_rating(self.risk_rating)

    @staticmethod
    def new_term_loan(commitment, start, maturity, risk_rating):
        return Loan(commitment, commitment, risk_rating, maturity, None, start, None)

    @staticmethod
    def new_revolver(commitment, start, expiry, risk_rating):
        return Loan(commitment, 0.0, risk_rating, None, expiry, start, None)

    @staticmethod
    def new_advised_line(commitment, start, expiry, risk_rating):
        if risk_rating > 3:
            return None
        advised_line = Loan(commitment, 0.0, risk_rating, None, expiry, start, None)
        advised_line.set_unused_percentage(0.1)
        return advised_line
