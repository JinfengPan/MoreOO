using System;

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
        private decimal Balance { get; set; }
        private bool IsVerified { get; set; }
        private bool IsClosed { get; set; }

        private Action OnUnfreeze { get; }

        public Account(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
            this.ManageUnfreezing = this.StayUnfrozen;
        }
        public void Deposit(decimal amount)
        {
            if (this.IsClosed)
                return;
            this.ManageUnfreezing();
            this.Balance += amount;
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

        private  Action ManageUnfreezing { get; set; }

        private void Unfreeze()
        {
            this.ManageUnfreezing = this.StayUnfrozen;
        }

        private void Freeze()
        {
            if (this.IsClosed)
                return;
            if (!this.IsVerified)
                return;
            this.ManageUnfreezing = this.Unfreeze;
        }
        private void StayUnfrozen()
        {
            
        }
    }
}
