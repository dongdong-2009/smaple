using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationA1
{
    public class StrategyContext
    {
        public static void Main(string[] args)
        {
            Strategy str = new Strategy("3");
            double s = str.MoneyAfter(500);
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

    public class Strategy
    {
        IFee fee = null;

        public Strategy(string type)
        {
            switch (type)
            {
                case "1":
                    {
                        fee =  new NormalFee();
                        break;
                    }
                case "2":
                    {
                        fee = new DisCountFee(0.8);
                        break;
                    }
                case "3":
                    {
                        fee = new CutFee(500, 180);
                        break;
                    }
            }
        }

        public double MoneyAfter(double MoneyBefore)
        {
            return fee.MoneyAfter(MoneyBefore);
        }
    }
}
