namespace _06.MoneyTransactions
{
    public class BankAccount
    {
        public BankAccount(int number, double balance)
        {
            this.AccountNumber = number;
            this.Balance = balance;
        }

        public int AccountNumber { get; private set; }
        public double Balance { get; set; }

        public override string ToString()
        {
            return $"Account {this.AccountNumber} has new balance: {this.Balance:f2}";
        }
    }
}
