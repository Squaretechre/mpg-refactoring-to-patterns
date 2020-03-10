# Form Template Method

## Intro

At the end of [Replace Conditional Logic with Strategy](https://github.com/Squaretechre/mpg-refactoring-to-patterns/tree/master/4%20-%20Replace%20Conditional%20Logic%20with%20Strategy) we were left with three subclasses of the abstract class `CapitalStrategy` as shown below:

```Python
class CapitalStrategy:
    @abstractmethod
    def capital(self, loan):
        raise NotImplementedError
```

```Python
class CapitalStrategyAdvisedLine(CapitalStrategy):
    def __init__(self):
        CapitalStrategy.__init__(self)

    def capital(self, loan):
        return loan.get_commitment() * loan.get_unused_percentage() \
               * self.duration(loan) * self.risk_factor_for(loan)
```

```Python
class CapitalStrategyTermLoan(CapitalStrategy):
    def __init__(self):
        CapitalStrategy.__init__(self)

    def capital(self, loan):
        return loan.get_commitment() * self.duration(loan) * self.risk_factor_for(loan)

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
```

```Python
class CapitalStrategyRevolver(CapitalStrategy):
    def __init__(self):
        CapitalStrategy.__init__(self)

    def capital(self, loan):
        return (loan.outstanding_risk_amount() * self.duration(loan) * self.risk_factor_for(loan)) \
               + (loan.unused_risk_amount() * self.duration(loan) * self.unused_risk_factor_for(loan))
```

Above we can see that the `Capital` methods of `CapitalStrategyAdvisedLine` and `CapitalStrategyTermLoan` are very similar:

```Python
class CapitalStrategyAdvisedLine(CapitalStrategy):
    def capital(self, loan):
        return loan.get_commitment() * loan.get_unused_percentage() \
               * self.duration(loan) * self.risk_factor_for(loan)
```

```Python
class CapitalStrategyTermLoan(CapitalStrategy):
    def capital(self, loan):
        return loan.get_commitment() * self.duration(loan) * self.risk_factor_for(loan)
```

The only difference here is that `CapitalStrategyAdvisedLine` multiplies the result by the loan's unused percentage. Here we have a similar sequence of steps with a slight variation which could be generalised by refactoring to Template Method.

## Steps to Refactor

1. Create a composed method by applying `Extract Method` on the risk calculating logic in `CapitalStrategyAdvisedLine` and `CapitalStrategyTermLoan`:

```Python
class CapitalStrategyAdvisedLine(CapitalStrategy):
    def capital(self, loan):
        return self.risk_amount_for(loan) * self.duration(loan) * self.risk_factor_for(loan)

    def risk_amount_for(self, loan):
        return loan.get_commitment() * loan.get_unused_percentage()
```

```Python
class CapitalStrategyTermLoan(CapitalStrategy):
    def capital(self, loan):
        return self.risk_amount_for(loan) * self.duration(loan) * self.risk_factor_for(loan)

    def risk_amount_for(self, loan):
        return loan.get_commitment()
```

2. The `capital` method in these two subclasses now have identical signatures and bodies:

```Python
def capital(self, loan):
        return self.risk_amount_for(loan) * self.duration(loan) * self.risk_factor_for(loan)
```

Because of this we can use `Pull Up Method` to move this logic into the super type `CapitalStrategy` and create an abstract method that subclasses will override with their unique `risk_amount_for` calculation:

```Python
class CapitalStrategy:
    @abstractmethod
    def risk_amount_for(self, loan):
        raise NotImplementedError

    def capital(self, loan):
        return self.risk_amount_for(loan) * self.duration(loan) * self.risk_factor_for(loan)
```

We have now made `capital` a template method as it delegates the `risk_amount_for` calculation to subclasses, allowing them to fill in the blank and vary the behavior.

3. `CapitalStrategyRevolver` is a little different, only the first half of it's capital calculation resembles the behaviour we've pulled up into `CapitalStrategy`:

```Python
class CapitalStrategyRevolver(CapitalStrategy):
    def capital(self, loan):
        return (loan.outstanding_risk_amount() * self.duration(loan) * self.risk_factor_for(loan)) \
               + (loan.unused_risk_amount() * self.duration(loan) * self.unused_risk_factor_for(loan))
```

This can be refactored to make use of the behaviour in `CapitalStrategy` as follows:

```Python
class CapitalStrategyRevolver(CapitalStrategy):
    def capital(self, loan):
        return super().capital(loan) \
               + loan.unused_risk_amount() * self.duration(loan) * self.unused_risk_factor_for(loan)

    def risk_amount_for(self, loan):
        return loan.outstanding_risk_amount()
```

Finally the second half of the calculation that deals with the unused portion of the loan can be extracted for readability:

```Python
class CapitalStrategyRevolver(CapitalStrategy):
    def capital(self, loan):
        return super().capital(loan) + self.unused_capital(loan)

    def unused_capital(self, loan):
        return loan.unused_risk_amount() * self.duration(loan) * self.unused_risk_factor_for(loan)

    def risk_amount_for(self, loan):
        return loan.outstanding_risk_amount()
```

This completes the refactoring.
