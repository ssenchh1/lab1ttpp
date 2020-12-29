using System.Collections.Generic;

namespace patterns1
{
    public abstract class Subject
    {
        List<Observer> observers = new List<Observer>();
        public void attach(Observer observer) 
        {
            observers.Add(observer);
        }
        public void NotifyAllObservers()
        {
            foreach(var obs in observers)
            {
                obs.update();
            }
        }
    }
}
