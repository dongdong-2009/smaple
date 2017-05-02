namespace FizzBuzzWhizz
{
    internal class FizzWhizzNumHandler : NumHandler
    {
        public FizzWhizzNumHandler(NumHandler successor)
            : base(successor)
        {
        }

        public override string Translate(int num)
        {
            if (num % (FizzBuzzWhizzMaker.Fizz * FizzBuzzWhizzMaker.Whizz) == 0)
            {
                return Constant.Fizz + Constant.Whizz;
            }

            return Successor.Translate(num);
        }
    }
}