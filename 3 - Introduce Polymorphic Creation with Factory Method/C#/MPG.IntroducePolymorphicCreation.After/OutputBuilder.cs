namespace MPG.IntroducePolymorphicCreation.After
{
    using System;

    public interface OutputBuilder
    {
        void AddBelow(string tag){}
        void AddAbove(string tag) => throw new InvalidOperationException();
    }
}