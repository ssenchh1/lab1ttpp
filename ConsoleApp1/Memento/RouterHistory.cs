using System.Collections.Generic;

namespace patterns1
{
    //Caretaker
    public class RouterHistory
    {
        public Stack<RouterMemento> History { get; private set; }
        public RouterHistory()
        {
            History = new Stack<RouterMemento>();
        }
    }
}
