using System;

namespace RoboBrawl
{
    public class EventController
    {
        public event Action baseEvent;
        public void AddListener( Action listener )
        {
            baseEvent += listener;
        }
        public void RemoveListener( Action listener )
        {
            baseEvent -= listener;
        }
        public void InvokeEvent( )
        {
            baseEvent?.Invoke( );
        }
    }

    
}