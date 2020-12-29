using System;

namespace patterns1
{
    public class DeleteObserver : Observer
    {
        public DeleteObserver(Subject subject)
        {
            this.subject = subject;
            this.subject.attach(this);
        }

        public override void update()
        {
            Console.WriteLine("OMG! Seems like you just deleted an item in the database");
        }
    }
}
