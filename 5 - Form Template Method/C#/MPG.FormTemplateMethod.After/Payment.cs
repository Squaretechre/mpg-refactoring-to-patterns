﻿namespace MPG.FormTemplateMethod.After
{
    using System;

    public class Payment
    {
        public Payment(double amount, DateTime date)
        {
            Amount = amount;
            Date = date;
        }

        public double Amount { get; }
        public DateTime Date { get; }
    }
}