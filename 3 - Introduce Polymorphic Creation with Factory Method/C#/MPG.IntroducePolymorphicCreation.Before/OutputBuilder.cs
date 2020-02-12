namespace MPG.IntroducePolymorphicCreation.Before
{
    using System;

    public interface OutputBuilder
    {
        void AddBelow(string tag){}
        void AddAbove(string tag) => throw new InvalidOperationException();
    }
}