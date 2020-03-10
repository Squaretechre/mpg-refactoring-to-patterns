from abc import abstractmethod
from dateutil.relativedelta import relativedelta
from after.risk_factors import RiskFactors
from after.unused_risk_factors import UnusedRiskFactors


class CapitalStrategy:
    @abstractmethod
    def risk_amount_for(self, loan):
        raise NotImplementedError

    def capital(self, loan):
        return self.risk_amount_for(loan) * self.duration(loan) * self.risk_factor_for(loan)

    def duration(self, loan):
        return self.years_to(loan.get_expiry(), loan)

    @staticmethod
    def risk_factor_for(loan):
        return RiskFactors.for_rating(loan.get_risk_rating())

    @staticmethod
    def unused_risk_factor_for(loan):
        return UnusedRiskFactors.for_rating(loan.get_risk_rating())

    @staticmethod
    def years_to(end_date, loan):
        begin_date = loan.get_today() if loan.get_today() is not None else loan.get_start()
        difference = relativedelta(end_date, begin_date)
        return difference.years
