namespace Delegates_and_Events
{
    class Arithmetic
    {
        //a method, that will be assigned to delegate objects
        //having the EXACT signature of the delegate
        public int add(int value1, int value2)
        {
            return value1 + value2;
        }
        //a method, that will be assigned to delegate objects
        //having the EXACT signature of the delegate
        public int sub(int value1, int value2)
        {
            return value1 - value2;
        }
    }
}
