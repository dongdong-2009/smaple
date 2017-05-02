namespace FizzBuzzWhizz
{
    internal class BuzzWhizzNumHandler : NumHandler
    {
        public BuzzWhizzNumHandler(NumHandler successor)
            : base(successor)
        {
        }

        public override string Translate(int num)
        {
            if (num % (FizzBuzzWhizzMaker.Buzz * FizzBuzzWhizzMaker.Whizz) == 0)
            {
                return Constant.Buzz + Constant.Whizz;
            }

            return Successor.Translate(num);
        }
    }
}