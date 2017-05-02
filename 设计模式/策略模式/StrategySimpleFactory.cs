using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationA
{
    public class StrategySimpleFactory
    {
        public static void Main1(string[] args)
        {
            IFee f = FeeFactory.CreateFee("3");
            double s = f.MoneyAfter(500);
            Console.WriteLine(s);
            Console.ReadLine();
        }
    }

    public interface IFee
    {
        double MoneyAfter(double MoneyBefore);
    }

    public class NormalFee : IFee
    {
        public double MoneyAfter(double MoneyBefore)
        {
            return MoneyBefore;
        }
    }

    public class DisCountFee:IFee
    {
        double discount = 0;
        public DisCountFee(double d)
        {
            discount = d;
        }
        public double MoneyAfter(double MoneyBefore)
        {
            return MoneyBefore * discount;
        }
    }

    public class CutFee : IFee
    {
        double condition = 0;
        double cut = 0;
        public CutFee(double c1,double c2)
        {
            condition = c1;
            cut = c2;
        }

        public double MoneyAfter(double MoneyBefore)
        {
            double result = MoneyBefore;
            if (MoneyBefore >= condition)
            { 
                result = MoneyBefore - Math.Floor(MoneyBefore / condition)*cut;               
            }
            return result;
        }
    }

    public class FeeFactory
    {
        public static IFee CreateFee(string type)
        {
            switch (type)
            {
                case "1":
                    {
                        return new NormalFee();
                    }
                case "2":
                    {
                        return new DisCountFee(0.8);
                    }
                case "3":
                    {
                        return new CutFee(500,180);
                    }
            }
            return null;
        }
    }

}
