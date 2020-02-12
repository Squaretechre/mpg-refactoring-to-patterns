namespace MPG.ReplaceConstructors.After
{
    using System;
    using Xunit;
    using Xunit.Abstractions;

    public class Tests
    {
        private readonly ITestOutputHelper outputHelper;

        public Tests(ITestOutputHelper outputHelper)
        {
            this.outputHelper = outputHelper;
        }

        [Fact]
        public void CreateTermLoanFromThreeArgs_1()
        {
            var loan = Loan.CreateTermLoan(0.0, 0, null);
            Assert.Equal("Term loan", loan.TypeOfLoan());
        }

        [Fact]
        public void CreateTermLoanFromThreeArgs_2()
        {
            // duplicate of above to demonstrate refactoring
            var loan = Loan.CreateTermLoan(0.0, 0, null);
            Assert.Equal("Term loan", loan.TypeOfLoan());
        }

        [Fact]
        public void CreateTermLoanFromFourArgs()
        {
            var loan = Loan.CreateTermLoan(0.0, 0, null);
            Assert.Equal("Term loan", loan.TypeOfLoan());
        }

        [Fact]
        public void CreateTermLoanFromFiveArgs()
        {
            var loan = Loan.CreateTermLoan(0.0, 0, null);
            Assert.Equal("Term loan", loan.TypeOfLoan());
        }

        [Fact]
        public void CreateTermLoanFromCapitalStrategy()
        {
            var loan = Loan.CreateTermLoan(0.0, 0, null);
            Assert.Equal("Term loan", loan.TypeOfLoan());
        }

        [Fact]
        public void CreateTermLoanFromCoreConstructor()
        {
            var loan = Loan.CreateTermLoan(0.0, 0, null);
            Assert.Equal("Term loan", loan.TypeOfLoan());
        }
        
        [Fact]
        public void CreateRevolverLoanFromFourArgs()
        {
            var loan = Loan.CreateRevolver(0.0, 0.0, 0, DateTime.Now);
            Assert.Equal("Revolver loan", loan.TypeOfLoan());
        }
        
        [Fact]
        public void CreateRevolverLoanFromFiveArgs()
        {
            var loan = Loan.CreateRevolver(0.0, 0.0, 0, DateTime.Now);
            Assert.Equal("Revolver loan", loan.TypeOfLoan());
        }

        [Fact]
        public void CreateRevolverLoanFromCapitalStrategy()
        {
            var loan = Loan.CreateRevolver(0.0, 0.0, 0, DateTime.Now);
            Assert.Equal("Revolver loan", loan.TypeOfLoan());
        }
        
        [Fact]
        public void CreateRevolverLoanFromCoreConstructor()
        {
            var loan = Loan.CreateRevolver(0.0, 0.0, 0, DateTime.Now);
            Assert.Equal("Revolver loan", loan.TypeOfLoan());
        }
        
        [Fact]
        public void CreateRCTLLoanFromFourArgs()
        {
            var loan = Loan.CreateRCTL(0.0, 0.0, 0, DateTime.Now, DateTime.Now);
            Assert.Equal("RCTL loan", loan.TypeOfLoan());
        }
        
        [Fact]
        public void CreateRCTLLoan2FromFiveArgs()
        {
            var loan = Loan.CreateRCTL(0.0, 0.0, 0, DateTime.Now, DateTime.Now);
            Assert.Equal("RCTL loan", loan.TypeOfLoan());
        }

        [Fact]
        public void CreateRCTLLoanFromCapitalStrategy()
        {
            var loan = Loan.CreateRCTL(0.0, 0.0, 0, DateTime.Now, DateTime.Now);
            Assert.Equal("RCTL loan", loan.TypeOfLoan());
        }
        
        [Fact]
        public void CreateRCTLLoanCoreConstructor()
        {
            var loan = Loan.CreateRCTL(0.0, 0.0, 0, DateTime.Now, DateTime.Now);
            Assert.Equal("RCTL loan", loan.TypeOfLoan());
        }
        
        [Fact]
        public void CreateSpecificLoan()
        {
            var loan = Loan.CreateRevolver(new CapitalStrategyRevolver(), 0.0, 0.0, 0, (DateTime?)DateTime.Now);
            Assert.Equal("Revolver loan", loan.TypeOfLoan());
        }
    }
}