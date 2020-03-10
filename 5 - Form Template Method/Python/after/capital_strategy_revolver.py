from after.capital_strategy import CapitalStrategy


class CapitalStrategyRevolver(CapitalStrategy):
    def __init__(self):
        CapitalStrategy.__init__(self)

    def capital(self, loan):
        return super().capital(loan) + self.unused_capital(loan)

    def unused_capital(self, loan):
        return loan.unused_risk_amount() * self.duration(loan) * self.unused_risk_factor_for(loan)

    def risk_amount_for(self, loan):
        return loan.outstanding_risk_amount()

