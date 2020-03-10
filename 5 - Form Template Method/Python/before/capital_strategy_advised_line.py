from before.capital_strategy import CapitalStrategy


class CapitalStrategyAdvisedLine(CapitalStrategy):
    def __init__(self):
        CapitalStrategy.__init__(self)

    def capital(self, loan):
        return loan.get_commitment() * loan.get_unused_percentage() * self.duration(loan) * self.risk_factor_for(loan)
