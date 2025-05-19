using System;
using System.Collections.Generic;

public interface IObserver
{
    void Update(string message);
}

public class ChatUser : IObserver
{
    private string _name;

    public ChatUser(string name) => _name = name;

    public void Update(string message)
    {
        Console.WriteLine($"{_name} отримав повідомлення: {message}");
    }
}

public class ChatRoom
{
    private List<IObserver> _subscribers = new List<IObserver>();

    public void Subscribe(IObserver observer) => _subscribers.Add(observer);
    public void Unsubscribe(IObserver observer) => _subscribers.Remove(observer);

    public void Notify(string message)
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.Update(message);
        }
    }

    public void SendMessage(string message)
    {
        Console.WriteLine($"Нове повідомлення: {message}");
        Notify(message);
    }
}
