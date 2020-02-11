namespace MPG.ChainConstructors.Before
{
    using System;
    using Xunit;

    public class Tests
    {
        [Fact]
        public void CreateTermROCLoan()
        {
            var loan = new Loan(0.0, 0.0, 0, DateTime.Now);
            Assert.Equal("Term loan", loan.TypeOfLoan());
        }
        
        [Fact]
        public void CreateRevolvingLoan()
        {
            var loan = new Loan(0.0, 0.0, 0, DateTime.Now, DateTime.Now);
            Assert.Equal("Revolving loan", loan.TypeOfLoan());
        }
        
        [Fact]
        public void CreateRCTLLoan()
        {
            var loan = new Loan(new RCTLTermROC(), 0.0, 0.0, 0, DateTime.Now, DateTime.Now);
            Assert.Equal("RCTL loan", loan.TypeOfLoan());
        }
    }
}