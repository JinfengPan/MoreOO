using System;

namespace BranchingDemo
{
    class Account
    {
        private decimal Balance { get; set; }
        private IAccountState State { get; set; }

        public Account(Action onUnfreeze)
        {
            State = new NotVerified(onUnfreeze);
        }

        //存钱
        public void Deposit(decimal amount)
        {
            this.State = State.Deposit(() => { this.Balance += amount; });
            
        }

        //取钱
        public void Withdraw(decimal amount)
        {
            this.State = this.State.Withdraw(() =>
            {
            this.Balance -= amount;

            });

        }

        public void HolderVerified()
        {
            this.State.HolderVerified();
        }

        public void Close()
        {
            this.State.Close();
        }

        private  Action ManageUnfreezing { get; set; }


        private void Freeze()
        {
            this.State.Freeze();
        }

    }
}