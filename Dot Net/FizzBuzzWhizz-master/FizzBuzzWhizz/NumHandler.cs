namespace FizzBuzzWhizz
{
    internal abstract class NumHandler
    {
        protected NumHandler Successor = null;

        protected NumHandler(NumHandler successor)
        {
            Successor = successor;
        }

        public abstract string Translate(int num);
    }
}