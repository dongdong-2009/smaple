namespace FizzBuzzWhizz
{
    internal class FizzBuzzWhizzNumHandler : NumHandler
    {
        public FizzBuzzWhizzNumHandler(NumHandler successor)
            : base(successor)
        {
        }

        public override string Translate(int num)
        {
            if (num % (FizzBuzzWhizzMaker.Fizz * FizzBuzzWhizzMaker.Buzz * FizzBuzzWhizzMaker.Whizz) == 0)
            {
                return Constant.Fizz + Constant.Buzz + Constant.Whizz;
            }

            return Successor.Translate(num);
        }
    }
}