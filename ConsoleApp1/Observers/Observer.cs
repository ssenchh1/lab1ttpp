namespace patterns1
{
    public abstract class Observer
    {
        protected Subject subject;
        public abstract void update();
    }
}
