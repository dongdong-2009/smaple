namespace FizzBuzzWhizz
{
    internal class WhizzNumHandler : NumHandler
    {
        public WhizzNumHandler(NumHandler successor)
            : base(successor)
        {
        }

        public override string Translate(int num)
        {
            if (num % FizzBuzzWhizzMaker.Whizz == 0)
            {
                return Constant.Whizz;
            }

            return Successor.Translate(num);
        }
    }
}