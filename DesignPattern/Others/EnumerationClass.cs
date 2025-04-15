using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DesignPattern.Others;

/// <summary>
/// Class inspired by
/// https://lostechies.com/jimmybogard/2008/08/12/enumeration-classes/
/// https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/enumeration-classes-over-enum-types
/// </summary>
public abstract record Enumeration : IComparable
{
    public int Value { get; }
    public string DisplayName { get; }

    public Enumeration()
    {
        Value = -1;
        DisplayName = string.Empty;
    }

    public Enumeration(int value, string displayName)
    {
        Value = value;
        DisplayName = displayName;
    }

    public static IEnumerable<T> GetAll<T>() where T : Enumeration, new()
    {
        var type = typeof(T);
        //Retrieve only public static declaredonly fields
        var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

        foreach (var info in fields)
        {
            var instance = new T();
            var locatedValue = info.GetValue(instance) as T;

            if (locatedValue != null)
            {
                yield return locatedValue;
            }
        }
    }

    public static T FromValue<T>(int value) where T : Enumeration, new()
    {
        var matchingItem = Parse<T, int>(value, "value", item => item.Value == value);
        return matchingItem;
    }

    public static T FromDisplayName<T>(string displayName) where T : Enumeration, new()
    {
        var matchingItem = Parse<T, string>(displayName, "display name", item => item.DisplayName == displayName);
        return matchingItem;
    }

    private static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumeration, new()
    {
        var matchingItem = GetAll<T>().FirstOrDefault(predicate);

        if (matchingItem == null)
        {
            var message = string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof(T));
            throw new ApplicationException(message);
        }

        return matchingItem;
    }

    public override string ToString()
        => DisplayName;

    public int CompareTo(object other)
        => Value.CompareTo(((Enumeration)other).Value);
}

public record EmployeeType : Enumeration
{
    public static readonly EmployeeType Assistant = new EmployeeType(0, "Assistant", new AssistantEmployeeHandler());
    public static readonly EmployeeType LeadTeacher = new EmployeeType(1, "Lead Teacher", new LeadTeacherEmployeeHandler());

    public IEmployeeHandler Do { get; }

    public EmployeeType()
    {
        Do = new NullEmployeeHandler();
    }

    public EmployeeType(int value, string displayName, IEmployeeHandler handler)
        : base(value, displayName)
    {
        Do = handler;
    }

    public override string ToString()
        => base.ToString();
}

public interface IEmployeeHandler
{
    double GetSalary();

    string GetDescription();
}

public class AssistantEmployeeHandler : IEmployeeHandler
{
    public string GetDescription()
        => "This is an assistant";

    public double GetSalary()
        => 1500;
}

public class LeadTeacherEmployeeHandler : IEmployeeHandler
{
    public string GetDescription()
        => "This is a Lead Teacher";

    public double GetSalary()
        => 2500;
}

public class NullEmployeeHandler : IEmployeeHandler
{
    public string GetDescription()
        => string.Empty;

    public double GetSalary()
        => 0;
}

public class Employee
{
    public EmployeeType Type { get; }

    public Employee(EmployeeType type)
        => Type = type;

    public double GetSalary()
        => Type.Do.GetSalary();

    public string GetDescrption()
        => Type.Do.GetDescription();
}

/// <summary>
/// Client class
/// </summary>
public class EnumClassClient
{
    public void UseEmployee()
    {
        var assistant = new Employee(EmployeeType.Assistant);
        Console.WriteLine(assistant.GetSalary());
        Console.WriteLine(assistant.GetDescrption());

        Console.WriteLine();

        foreach (var itemType in Enumeration.GetAll<EmployeeType>())
        {
            Console.WriteLine(itemType);
        }

        Console.WriteLine();

        Console.WriteLine(Enumeration.FromDisplayName<EmployeeType>("Assistant"));
        Console.WriteLine(Enumeration.FromValue<EmployeeType>(1)); 
    }
}

//Example of a bad implementation using Enums - what happens if you add a new Enum in EmployeeTypes
/*
public enum EmployeeType
{
    Assistant,
    LeadTeacher
}

public class Employee
{
    public EmployeeType Type { get; }

    public Employee(EmployeeType type)
        => Type = type;

    public double GetSalary()
    {
        switch(Type)
        {
            case EmployeeType.Assistant:
                return 1500;
            case EmployeeType.LeadTeacher:
                return 2500;
            default:
                throw new NotImplementedException($"GetSalary: - EmployeeType '{Type}' not yet implemented");
        }
    }

    public string GetDescription()
    {
        switch (Type)
        {
            case EmployeeType.Assistant:
                return "This is an assistant";
            case EmployeeType.LeadTeacher:
                return "This is a Lead Teacher";
            default:
                throw new NotImplementedException($"GetSalary: - EmployeeType '{Type}' not yet implemented");
        }
    }
}
*/
