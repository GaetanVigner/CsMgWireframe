namespace InputMgr.Abstract
{
    public abstract class Command<T>
    {
        public abstract void Execute(T arg);
    }
}
