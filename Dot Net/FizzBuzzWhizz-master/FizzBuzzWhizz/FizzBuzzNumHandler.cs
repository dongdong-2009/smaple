namespace FizzBuzzWhizz
{
    internal class FizzBuzzNumHandler : NumHandler
    {
        public FizzBuzzNumHandler(NumHandler successor)
            : base(successor)
        {
        }

        public override string Translate(int num)
        {
            if (num % (FizzBuzzWhizzMaker.Fizz * FizzBuzzWhizzMaker.Buzz) == 0)
            {
                return Constant.Fizz + Constant.Buzz;
            }

            return Successor.Translate(num);
        }
    }
}