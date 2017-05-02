namespace FizzBuzzWhizz
{
    internal class CommonNumHandler : NumHandler
    {
        public CommonNumHandler(NumHandler successor)
            : base(successor)
        {
        }

        public override string Translate(int num)
        {
            return num.ToString();
        }
    }
}