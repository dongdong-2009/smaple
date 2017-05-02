namespace FizzBuzzWhizz
{
    internal class FizzNumHandler : NumHandler
    {
        public FizzNumHandler(NumHandler successor)
            : base(successor)
        {
        }

        public override string Translate(int num)
        {
            if (num % FizzBuzzWhizzMaker.Fizz == 0)
            {
                return Constant.Fizz;
            }

            return Successor.Translate(num);
        }
    }
}