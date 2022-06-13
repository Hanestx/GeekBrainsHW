namespace Code.State
{
    public abstract class State
    {
        public abstract void Handle(Context context);
    }
}