using System.Collections.Generic;

namespace DesignPattern.Structural
{
    //Flyweight lets you fit more objects into the available amount of RAM by sharing common parts of state between multiple objects
    //instead of keeping all of the data in each object.

    public record TreeType(string Name)
    {
        private readonly char[] _sprite = new char[1024];

        public void Display()
        {
            System.Console.WriteLine($"{Name}: {new string(_sprite)}");
        }
    }

    public class TreeTypeCache
    {
        private readonly Dictionary<string, TreeType> _treeDico = new();

        public TreeType GetTreeType(string name)
        {
            if (_treeDico.TryGetValue(name, out TreeType treeType))
                return treeType;

            treeType = new TreeType(name);
            _treeDico.Add(name, treeType);
            return treeType;
        }
    }

    public class Forest
    {
        private readonly List<Tree> _trees = new();
        private readonly TreeTypeCache _treeTypeCache = new();

        public void AddTree(double x, double y, string typeName)
        {
            _trees.Add(new Tree(_treeTypeCache.GetTreeType(typeName), x, y, typeName));
        }

        public void Display()
        {
            foreach (var tree in _trees)
                tree.Display();
        }
    }

    public class Tree
    {
        private readonly TreeType _treeType;

        public double X { get; }
        public double Y { get; }

        public string TypeName { get; }

        public Tree(TreeType treeType, double x, double y, string typeName)
        {
            _treeType = treeType;
            X = x;
            Y = y;
            TypeName = typeName;
        }

        public void Display()
        {
            System.Console.WriteLine($"Coord: ({X}, {Y})");
            _treeType.Display();
        }
    }

    public class FlyweightClient
    {
        private readonly Forest _forest;

        public FlyweightClient()
        {
            _forest = new Forest();
            _forest.AddTree(1, 1, "Sapin");
            _forest.AddTree(1, 72, "Pin");
        }

        public void Display()
        {
            _forest.Display();
        }
    }
}
