using System;

namespace BranchingDemo
{
    class Active : IAccountState
    {
        private Action _onUnfreeze;

        public Active(Action onUnfreeze)
        {
            _onUnfreeze = onUnfreeze;
        }


        public IAccountState Withdraw() => this;
        public IAccountState Freeze() => new Frozen(_onUnfreeze);

        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountState Withdraw(Action subtractFromBalance)
        {
            subtractFromBalance();
            return this;
        }

        public IAccountState HolderVerified() => this;

        public IAccountState Close()
        {
            throw new NotImplementedException();
        }
    }
}