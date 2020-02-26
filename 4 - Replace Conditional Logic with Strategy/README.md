# Replace Conditional Logic With Strategy

You can find the full chapter from Refactoring to Patterns with example code at http://www.informit.com/articles/article.aspx?p=1398607&seqNum=2.

## Steps to perform refactoring

Steps:

1. Create class CapitalStrategy
2. Declare Capital method in CapitalStrategy
3. Copy Capital and anything easy from Loan to CapitalStrategy
4. Figure out what is needed from a Loan instance and decide what to move whether to use a context object or pass data in parameters
5. Add getter methods for data that is needed from the context
6. Make Loan delegate to CapitalStrategy.Capital
7. Move YearsTo, WeightedAverageDuration and Duration to CapitalStrategy
8. Make Loan delegate to CapitalStrategy.Duration
9. Remove unused code from Loan
10. Extract CapitalStrategy to field
11. Extract parameter on field initialization so that CapitalStrategy is passed in via constructor
12. Create CapitalStrategyTermLoan, move WeightedAverageDuration to it
13. Swap CapitalStrategy for CapitalStrategyTerm loan in factory method
14. Delete WeightedAverageDuration from CapitalStrategy as it's only needed for term loans
15. Create CapitalStrategyAdvisedLine, move Capital logic, replace in factory method, remove unused code
16. Create CapitalStrategyRevolver, move Capital logic, replace in factory method, remove unused code
17. Make CapitalStrategy an abstract class, make Capital abstract
