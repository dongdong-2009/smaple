namespace FizzBuzzWhizz
{
    internal class BuzzNumHandler : NumHandler
    {
        public BuzzNumHandler(NumHandler successor)
            : base(successor)
        {
        }

        public override string Translate(int num)
        {
            if (num % FizzBuzzWhizzMaker.Buzz == 0)
            {
                return Constant.Buzz;
            }

            return Successor.Translate(num);
        }
    }
}