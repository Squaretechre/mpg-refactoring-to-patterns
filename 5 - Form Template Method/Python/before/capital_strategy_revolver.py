from before.capital_strategy import CapitalStrategy


class CapitalStrategyRevolver(CapitalStrategy):
    def __init__(self):
        CapitalStrategy.__init__(self)

    def capital(self, loan):
        return (loan.outstanding_risk_amount() * self.duration(loan) * self.risk_factor_for(loan)) \
               + (loan.unused_risk_amount() * self.duration(loan) * self.unused_risk_factor_for(loan))
