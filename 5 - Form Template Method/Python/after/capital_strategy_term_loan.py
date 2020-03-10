from after.capital_strategy import CapitalStrategy


class CapitalStrategyTermLoan(CapitalStrategy):
    def __init__(self):
        CapitalStrategy.__init__(self)

    def risk_amount_for(self, loan):
        return loan.get_commitment()

    def duration(self, loan):
        return self.weighted_average_duration(loan)

    def weighted_average_duration(self, loan):
        duration = 0.0
        weighted_average = 0.0
        sum_of_payments = 0.0

        for payment in loan.get_payments():
            weighted_average += self.years_to(payment.date, loan) * payment.amount
            sum_of_payments += payment.amount

        if loan.get_commitment() != 0.0:
            duration = weighted_average / sum_of_payments

        return duration
