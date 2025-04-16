---
title: "Design Patterns"
---

# Design Patterns

This repo contains design patterns examples in C#.

Design patterns are typical solutions to common problems in software design.  
Online resources : 
[Refactoring Guru](https://refactoring.guru/design-patterns)

**Design patterns** are categorized into three main types: **Behavioral**, **Creational**, and **Structural patterns**.

## Behavioral Patterns
Behavioral patterns are concerned with how objects interact and communicate with one another.

### Chain of Responsibility
Passes a request along a chain of handlers. Each handler decides either to process the request or pass it to the next handler in the chain.

**Example Use Case**: Event handling systems, logging systems.

### Iterator
Provides a way to access elements of a collection sequentially without exposing its underlying structure.

**Example Use Case**: Traversing lists, trees, or custom collections.

### Mediator
Defines an object that encapsulates how a set of objects interact, promoting loose coupling by preventing objects from referring to each other explicitly.

**Example Use Case**: UI components coordination.

### Observer
Defines a one-to-many dependency between objects so that when one object changes state, all its dependents are notified.

**Example Use Case**: Event listeners, publish/subscribe systems.

### Strategy
Defines a family of algorithms, encapsulates each one, and makes them interchangeable.

**Example Use Case**: Sorting strategies, payment methods.

### Template Method
Defines the skeleton of an algorithm in a method, deferring some steps to subclasses.

**Example Use Case**: Framework methods with customizable steps.

### Visitor
Represents an operation (*usually a read only operation*) to be performed on the elements of an object structure without changing the classes on which it operates.

**Example Use Case**: Compilers, interpreters, document structure navigation.

## Creational Patterns
Creational patterns deal with object creation mechanisms, trying to create objects in a manner suitable to the situation.

### Abstract Factory
Provides an interface for creating families of related or dependent objects without specifying their concrete classes.

**Example Use Case**: Cross-platform UI libraries.

### Builder
Separates the construction of a complex object from its representation so that the same construction process can create different representations.

**Example Use Case**: Building complex documents or configurations.

### Factory Method
Defines an interface for creating an object, but lets subclasses alter the type of objects that will be created.

**Example Use Case**: Plugin architecture, extensible frameworks.

### Prototype
Specifies the kinds of objects to create using a prototypical instance, and create new objects by copying this prototype.

**Example Use Case**: Cloning, avoiding costly object creation.

### Singleton
Ensures a class has only one instance and provides a global point of access to it.

**Example Use Case**: Configuration objects, logging.

## Structural Patterns
Structural patterns focus on how classes and objects are composed to form larger structures.

### Adapter
Allows incompatible interfaces to work together by acting as a bridge between them.

**Example Use Case**: Legacy code integration, API compatibility.

### Bridge
Separates an object’s abstraction from its implementation so that the two can vary independently.

**Example Use Case**: GUI toolkits that separate abstraction and rendering platforms.

### Composite
Composes objects into tree structures to represent part-whole hierarchies.

**Example Use Case**: File systems, UI elements (menus, toolbars).

### Decorator
Attaches additional responsibilities to an object dynamically. Provides a flexible alternative to subclassing for extending functionality.

**Example Use Case**: Enhancing behavior of UI components or I/O streams.

### Facade
Provides a unified interface to a set of interfaces in a subsystem. Defines a higher-level interface that makes the subsystem easier to use.

**Example Use Case**: Simplifying complex libraries or APIs.

### Flyweight
Reduces the cost of creating and manipulating a large number of similar objects by sharing common parts of state.

**Example Use Case**: Rendering text, game development.

### Proxy
Provides a surrogate or placeholder for another object to control access to it.

**Example Use Case**: Virtual proxies, remote proxies, protection proxies.
