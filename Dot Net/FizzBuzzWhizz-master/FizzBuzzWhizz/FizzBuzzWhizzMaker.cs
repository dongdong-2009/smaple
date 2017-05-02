using System;

namespace FizzBuzzWhizz
{
    public class FizzBuzzWhizzMaker
    {
        private static int fizz;

        private static int buzz;

        private static int whizz;

        public static int Fizz
        {
            get { return fizz; }
            set
            {
                if ((value < 1) || (value > 9))
                {
                    throw new ArgumentOutOfRangeException("fizz", "fizz should be non-negative and less than 10");
                }

                if ((value == buzz) || (value == whizz))
                {
                    throw new ArgumentException("the same value with fizz already exists", "fizz");
                }

                fizz = value;
            }
        }

        public static int Buzz
        {
            get { return buzz; }
            set
            {
                if ((value < 1) || (value > 9))
                {
                    throw new ArgumentOutOfRangeException("buzz", "buzz should be non-negative and less than 10");
                }

                if ((value == fizz) || (value == whizz))
                {
                    throw new ArgumentException("the same value with buzz already exists", "buzz");
                }

                buzz = value;
            }
        }

        public static int Whizz
        {
            get { return whizz; }
            set
            {
                if ((value < 1) || (value > 9))
                {
                    throw new ArgumentOutOfRangeException("whizz", "whizz should be non-negative and less than 10");
                }

                if ((value == fizz) || (value == buzz))
                {
                    throw new ArgumentException("the same value with whizz already exists", "whizz");
                }

                whizz = value;
            }
        }

        public FizzBuzzWhizzMaker(int fizz, int buzz, int whizz)
        {
            Fizz = fizz;
            Buzz = buzz;
            Whizz = whizz;
        }

        public string Translate(int num)
        {
            NumHandler commonNumHandler = new CommonNumHandler(null);
            NumHandler whizzNumHandler = new WhizzNumHandler(commonNumHandler);
            NumHandler buzzNumHandler = new BuzzNumHandler(whizzNumHandler);
            NumHandler fizzNumHandler = new FizzNumHandler(buzzNumHandler);
            NumHandler buzzWhizzNumHandler = new BuzzWhizzNumHandler(fizzNumHandler);
            NumHandler fizzWhizzNumHandler = new FizzWhizzNumHandler(buzzWhizzNumHandler);
            NumHandler fizzBuzzNumHandler = new FizzBuzzNumHandler(fizzWhizzNumHandler);
            NumHandler fizzBuzzWhizzNumHandler = new FizzBuzzWhizzNumHandler(fizzBuzzNumHandler);
            NumHandler fizzSpecialNumHandler = new FizzSpecialNumHandler(fizzBuzzWhizzNumHandler);

            return fizzSpecialNumHandler.Translate(num);
        }
    }
}