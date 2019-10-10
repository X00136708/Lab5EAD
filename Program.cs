using System;

namespace Lab5
{
    enum Currency
    {
        Euro, USD
    }
    struct Money
    {
        private const double EuroToDollarRate = 1.31;
        private const double DollarToEuroRate = 0.76;

        public Currency currency;
        public double amount { get; }

        public Money(Currency currency, double amount)
        {
            this.amount = amount;
            this.currency = currency;
        }
        public double Convert(Currency convert)
        {
            if (currency == convert)
            {
                return amount;
            }
            else
            {
                if (convert == Currency.Euro)
                {
                    return amount * DollarToEuroRate;
                }
                else if (convert == Currency.USD)
                {
                    return amount * EuroToDollarRate;
                }
                else
                {
                    return 0;
                }
            }

        }

        public Money Add(Money m1, Money m2)
        {
            return m1 + m2;            
        }

        public static Money operator +(Money m1, Money m2)
        {
            if (m1.currency == m2.currency)
            {
                return new Money(m1.currency, m1.amount + m2.amount);
            }
            else
            {
                return new Money(m1.currency, m1.amount + m2.Convert(m2.currency));
            }
        }

        public override string ToString()
        {
            return this.currency + ": " + this.amount;
        }

    }
    class Test
    {
        public static void Main()
        {
            Money m1 = new Money(Currency.Euro, 50);
            Money m2 = new Money(Currency.USD, 70);
            Money m3 = m1 + m2;
            Console.WriteLine(m3);
            Money m4 = m3 + (new Money(Currency.USD, 100));
            Console.WriteLine(m4);
        }
    }
}
