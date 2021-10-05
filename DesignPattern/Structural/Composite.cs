using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Structural
{
    //Composite lets you compose objects into tree structures and then work with these structures as if they were individual objects.

    public interface IComponent
    {
        void Execute();
    }

    public record LeafComponent(string Name) : IComponent
    {
        public void Execute()
            => Console.WriteLine($"{Name} executed");
    }

    public record CompositeComponent : IComponent
    {
        private readonly List<IComponent> _children = new();

        public void Add(IComponent child)
        {
            _children.Add(child);
        }

        public void Execute()
        {
            foreach (var component in _children)
                component.Execute();
        }
    }


    class CompositeExample
    {
        private readonly IComponent _component;

        public CompositeExample()
        {
            var composite = new CompositeComponent();
            composite.Add(new LeafComponent("Adam"));
            composite.Add(new LeafComponent("Lise"));
            composite.Add(new LeafComponent("Amine"));

            _component = composite;
        }

        public void Execute()
            => _component.Execute();
    }
}
