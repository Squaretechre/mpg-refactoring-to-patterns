namespace MPG.IntroducePolymorphicCreation.After
{
    public class XMLBuilderTests : OutputBuilderTests
    {
        protected override OutputBuilder CreateBuilder(string root)
        {
            return new XMLBuilder(root);
        }
    }
}