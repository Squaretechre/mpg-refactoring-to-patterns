namespace MPG.IntroducePolymorphicCreation.After
{
    using System;
    using Xunit;

    public abstract class OutputBuilderTests
    {
        protected OutputBuilder builder;
        protected abstract OutputBuilder CreateBuilder(string root);

        [Fact]
        public void TestAddAboveRoot()
        {
            builder = CreateBuilder("orders");
            builder.AddBelow("order");
            Assert.Throws<InvalidOperationException>(() => builder.AddAbove("customer"));
        }
    }
}