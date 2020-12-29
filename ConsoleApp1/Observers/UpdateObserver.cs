using System;

namespace patterns1
{
    public class UpdateObserver : Observer
    {
        public UpdateObserver(Subject subject)
        {
            this.subject = subject;
            this.subject.attach(this);
        }

        public override void update()
        {
            Console.WriteLine("WOW! Seems like you just updated a new item in the database");
        }
    }
}
