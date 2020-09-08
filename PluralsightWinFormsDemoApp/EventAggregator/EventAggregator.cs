using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PluralsightWinFormsDemoApp.EventAggregator
{
    public interface IEventAggregator
    {
        void Publish<T>(T message) where T : IApplicationEvent;
        void Subscribe<T>(Action<T> action) where T : IApplicationEvent;
        void Unsubscribe<T>(Action<T> action) where T : IApplicationEvent;
    }

    public interface IApplicationEvent
    {

    }
    
    public class EventAggregator : IEventAggregator
    {
        private static readonly IEventAggregator _instance = new EventAggregator();
        public static IEventAggregator Instance => _instance;

        private readonly ConcurrentDictionary<Type, List<object>> _subscriptions = new ConcurrentDictionary<Type, List<object>>();
        
        public void Publish<T>(T message) where T : IApplicationEvent
        {
            List<object> subscribers;
            if (_subscriptions.TryGetValue(typeof(T), out subscribers))
            {
                // To Array creates a copy in case someone unsubscribes in their own handler
                foreach (var subscriber in subscribers.ToArray())
                {
                    ((Action<T>) subscriber)(message);
                }
            }
        }

        public void Subscribe<T>(Action<T> action) where T : IApplicationEvent
        {
            throw new NotImplementedException();
        }

        public void Unsubscribe<T>(Action<T> action) where T : IApplicationEvent
        {
            throw new NotImplementedException();
        }
    }
}
