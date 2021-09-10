using System;
using System.Collections.Generic;

public class EventDispatcherService
{
    private static EventDispatcherService _instance;
    public static EventDispatcherService Instance => _instance ??= new EventDispatcherService();
    
    private readonly Dictionary<Type, SignalDelegate> _events;

    public EventDispatcherService()
    {
        _events = new Dictionary<Type, SignalDelegate>();
    }

    public void Subscribe<T>(SignalDelegate callback) where T : Signal
    {
        var type = typeof(T);
        if (!_events.ContainsKey(type))
        {
            _events.Add(type, null);
        }

        _events[type] += callback;
    }

    public void Unsubscribe<T>(SignalDelegate callback) where T : Signal
    {
        var type = typeof(T);
        if (_events.ContainsKey(type))
        {
            _events[type] -= callback;
        }
    }

    public void Dispatch<T>(T signal) where T : Signal
    {
        var type = typeof(T);
        if (!_events.ContainsKey(type)) 
            return;

        _events[type](signal);
    }
}