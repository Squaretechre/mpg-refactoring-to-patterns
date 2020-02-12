static internal class Money
{
    public static MPG.EncapsulateClassesWithFactory.Before.Money GBP(decimal amount)
    {
        return new MPG.EncapsulateClassesWithFactory.Before.Money(amount, "GBP");
    }
}