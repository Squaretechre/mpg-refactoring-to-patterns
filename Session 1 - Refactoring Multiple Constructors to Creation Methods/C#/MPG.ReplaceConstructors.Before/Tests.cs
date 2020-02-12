namespace MPG.ReplaceConstructors.Before
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
            var loan = new Loan(0.0, 0, null);
            Assert.Equal("Term loan", loan.TypeOfLoan());
        }

        [Fact]
        public void CreateTermLoanFromThreeArgs_2()
        {
            // duplicate of above to demonstrate refactoring
            var loan = new Loan(0.0, 0, null);
            Assert.Equal("Term loan", loan.TypeOfLoan());
        }

        [Fact]
        public void CreateTermLoanFromFourArgs()
        {
            var loan = new Loan(0.0, 0, null, null);
            Assert.Equal("Term loan", loan.TypeOfLoan());
        }

        [Fact]
        public void CreateTermLoanFromFiveArgs()
        {
            var loan = new Loan(0.0, 0.0, 0, null, null);
            Assert.Equal("Term loan", loan.TypeOfLoan());
        }

        [Fact]
        public void CreateTermLoanFromCapitalStrategy()
        {
            var loan = new Loan(null, 0.0, 0, null, null);
            Assert.Equal("Term loan", loan.TypeOfLoan());
        }

        [Fact]
        public void CreateTermLoanFromCoreConstructor()
        {
            var loan = new Loan(null, 0.0, 0.0, 0, null, null);
            Assert.Equal("Term loan", loan.TypeOfLoan());
        }
        
        [Fact]
        public void CreateRevolverLoanFromFourArgs()
        {
            var loan = new Loan(0.0, 0, null, DateTime.Now);
            Assert.Equal("Revolver loan", loan.TypeOfLoan());
        }
        
        [Fact]
        public void CreateRevolverLoanFromFiveArgs()
        {
            var loan = new Loan(0.0, 0.0, 0, null, DateTime.Now);
            Assert.Equal("Revolver loan", loan.TypeOfLoan());
        }
        
        [Fact]
        public void CreateRevolverLoanFromCapitalStrategy()
        {
            var loan = new Loan(null, 0.0, 0, null, DateTime.Now);
            Assert.Equal("Revolver loan", loan.TypeOfLoan());
        }
        
        [Fact]
        public void CreateRevolverLoanFromCoreConstructor()
        {
            var loan = new Loan(null, 0.0, 0.0, 0, null, DateTime.Now);
            Assert.Equal("Revolver loan", loan.TypeOfLoan());
        }
        
        [Fact]
        public void CreateRCTLLoanFromFourArgs()
        {
            var loan = new Loan(0.0, 0, DateTime.Now, DateTime.Now);
            Assert.Equal("RCTL loan", loan.TypeOfLoan());
        }
        
        [Fact]
        public void CreateRCTLLoan2FromFiveArgs()
        {
            var loan = new Loan(0.0, 0.0, 0, DateTime.Now, DateTime.Now);
            Assert.Equal("RCTL loan", loan.TypeOfLoan());
        }
        
        [Fact]
        public void CreateRCTLLoanFromCapitalStrategy()
        {
            var loan = new Loan(null, 0.0, 0, DateTime.Now, DateTime.Now);
            Assert.Equal("RCTL loan", loan.TypeOfLoan());
        }
        
        [Fact]
        public void CreateRCTLLoanCoreConstructor()
        {
            var loan = new Loan(null, 0.0, 0.0, 0, DateTime.Now, DateTime.Now);
            Assert.Equal("RCTL loan", loan.TypeOfLoan());
        }
        
        [Fact]
        public void CreateSpecificLoan()
        {
            var loan = new Loan(new CapitalStrategyRevolver(), 0.0, 0.0, 0, DateTime.Now, DateTime.Now);
            Assert.Equal("Revolver loan", loan.TypeOfLoan());
        }
    }
}