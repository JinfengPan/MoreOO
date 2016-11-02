using System;

namespace BranchingDemo
{
    interface IAccountState
    {
        IAccountState Deposit(Action addToBalance);
        IAccountState Withdraw(Action subtractFromBalance);
        IAccountState Freeze();

        IAccountState HolderVerified();
        IAccountState Close();
    }

    class NotVerified: IAccountState
    {
        private Action OnUnfreeze { get; }


        public NotVerified(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
        }

        public IAccountState Deposit(Action addtoBalance)
        {
            addtoBalance();
            return this;
        }

        public IAccountState Withdraw(Action subtractFromBalance) => this;
        

        public IAccountState Freeze() => this;

        public IAccountState HolderVerified() => new Active(this.OnUnfreeze);

        public IAccountState Close() => new Closed();
    }

    class Closed : IAccountState
    {


        public IAccountState Freeze() => this;


        public IAccountState HolderVerified() => this;


        public IAccountState Close() => this;

        public IAccountState Deposit(Action addToBalance) => this;


        public IAccountState Withdraw(Action subtractFromBalance) => this;

    }
}