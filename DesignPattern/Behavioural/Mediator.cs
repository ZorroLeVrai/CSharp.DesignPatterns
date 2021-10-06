using System;
using System.Collections.Generic;

namespace DesignPattern.Behavioural
{
    //Mediator lets you reduce chaotic dependencies between objects.
    //The pattern restricts direct communications between the objects and forces them to collaborate only via a mediator object.

    public interface IActor
    {
        void SendMessage(string message);

        void ReceiveMessage(string message);
    }

    public record ActorAlpha(string Name, Mediator Intermediate) : IActor
    {
        public void ReceiveMessage(string message)
        {
            Console.WriteLine($"(Alpha) {Name} received message: {message}");
        }

        public void SendMessage(string message)
        {
            Console.WriteLine($"(Alpha) {Name} sends message: {message}");
            Intermediate.SendMessage(message);
        }
    }

    public record ActorBeta(string Name, Mediator Intermediate) : IActor
    {
        public void ReceiveMessage(string message)
        {
            Console.WriteLine($"(Beta) {Name} received message: {message}");
        }

        public void SendMessage(string message)
        {
            Console.WriteLine($"(Beta) {Name} sends message: {message}");
            Intermediate.SendMessage(message);
        }
    }

    public class Mediator
    {
        private readonly List<IActor> _actors = new();

        public void Register(IActor actor)
        {
            _actors.Add(actor);
        }

        public void SendMessage(string message)
        {
            foreach (var actor in _actors)
                actor.ReceiveMessage(message);
        }
    }


    public class MediatorClient
    {
        private readonly Mediator mediator = new();

        public void UseMediator()
        {
            var adam = new ActorAlpha("Adam", mediator);
            var lise = new ActorAlpha("Lise", mediator);
            var amine = new ActorBeta("Amine", mediator);

            mediator.Register(adam);
            mediator.Register(lise);
            mediator.Register(amine);

            adam.SendMessage("Calin");
        }
    }
}
