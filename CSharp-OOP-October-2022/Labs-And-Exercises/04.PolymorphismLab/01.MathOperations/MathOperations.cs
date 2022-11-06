namespace Operations
{
    public class MathOperations
    {
        public int Add(int firstNumber, int secondNumber)
            => firstNumber + secondNumber;

        public double Add(double firstNumber, double secondNumber, double thirdNumber)
            => firstNumber + secondNumber + thirdNumber;

        public decimal Add(decimal firstNumber, decimal secondNumber, decimal thirdNumber) 
            => firstNumber + secondNumber + thirdNumber;
    }
}