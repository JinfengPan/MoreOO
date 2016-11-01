namespace BranchingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Account
    {
        private bool IsVerified { get; set; }
        private bool IsClosed { get; set; }
        public void Deposit(decimal amount)
        {
            
        }

        public void Withdraw(decimal amount)
        {
            if(!this.IsVerified)
                return; //or do something else...
            //Widthdraw money
            
        }

        public void HolderVerified()
        {
            this.IsVerified = true;
        }

        public void Close()
        {
            this.IsClosed = true;
        }
    }
}
