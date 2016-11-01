namespace BranchingDemo
{
    interface IFreezable
    {
        IFreezable Deposit();
        IFreezable Withdraw();
        IFreezable Freeze();

    }

    class Active : IFreezable
    {
        public IFreezable Deposit()
        {
            throw new System.NotImplementedException();
        }

        public IFreezable Withdraw()
        {
            throw new System.NotImplementedException();
        }

        public IFreezable Freeze()
        {
            throw new System.NotImplementedException();
        }
    }

    class Frozen : IFreezable
    {
        public IFreezable Deposit()
        {
            throw new System.NotImplementedException();
        }

        public IFreezable Withdraw()
        {
            throw new System.NotImplementedException();
        }

        public IFreezable Freeze()
        {
            throw new System.NotImplementedException();
        }
    }
}