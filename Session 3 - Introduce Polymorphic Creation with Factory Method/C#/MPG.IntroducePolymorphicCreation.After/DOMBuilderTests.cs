namespace MPG.IntroducePolymorphicCreation.After
{
    using System;
    using Xunit;

    public class DOMBuilderTests : OutputBuilderTests
    {
        protected override OutputBuilder CreateBuilder(string root)
        {
            return new DOMBuilder(root);
        }
    }
}