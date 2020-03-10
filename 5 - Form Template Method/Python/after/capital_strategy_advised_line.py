from after.capital_strategy import CapitalStrategy


class CapitalStrategyAdvisedLine(CapitalStrategy):
    def __init__(self):
        CapitalStrategy.__init__(self)

    def risk_amount_for(self, loan):
        return loan.get_commitment() * loan.get_unused_percentage()
