using System;

namespace patterns1
{
    public class CreateObserver : Observer
    {
        public CreateObserver(Subject subject)
        {
            this.subject = subject;
            this.subject.attach(this);
        }

        public override void update()
        {
            Console.WriteLine("WOW! Seems like you just created a new item in the database");
        }
    }
}
