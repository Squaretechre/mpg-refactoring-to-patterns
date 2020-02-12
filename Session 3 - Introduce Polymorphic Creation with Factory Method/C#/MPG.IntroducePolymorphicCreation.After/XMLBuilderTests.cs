namespace MPG.IntroducePolymorphicCreation.After
{
    using System;
    using Xunit;

    public class XMLBuilderTests
    {
        private OutputBuilder builder;
        
        [Fact]
        public void TestAddAboveRoot()
        {
            builder = CreateBuilder("orders");
            builder.AddBelow("order");
            Assert.Throws<InvalidOperationException>(() => builder.AddAbove("customer"));
        }

        private OutputBuilder CreateBuilder(string root)
        {
            return new XMLBuilder(root);
        }
    }
}