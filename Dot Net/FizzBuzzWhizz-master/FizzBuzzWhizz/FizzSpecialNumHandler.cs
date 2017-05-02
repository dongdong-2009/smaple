namespace FizzBuzzWhizz
{
    internal class FizzSpecialNumHandler : NumHandler
    {
        public FizzSpecialNumHandler(NumHandler successor)
            : base(successor)
        {
        }

        public override string Translate(int num)
        {
            int tmp = num;

            while (tmp != 0)
            {
                if (tmp % 10 == FizzBuzzWhizzMaker.Fizz)
                {
                    return Constant.Fizz;
                }

                tmp /= 10;
            }

            return Successor.Translate(num);
        }
    }
}