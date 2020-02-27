# IoC

My take on Inversion of Control and Dependency Injection.

There are definitely much more powerful and flexible IoC/DI solutions out there, my IoC aims to be as lightweight as possible while serving the needs for 90% of my projects.

# Example

```c#

var container = new Container();

// Register dependencies
container.Register<ITestService>(() => new GuiService());
container.Register<ITestService>(typeof(StringService));
container.Register<ITestService>(new GuiService());

// Resolve dependencies
var service = container.Resolve<ITestService>();

// Check registered dependencies
Console.WriteLine("Is registered? {0}", container.IsRegistered<ITestService>());
// or
Console.WriteLine("Is registered? {0}", container.IsRegistered(typeof(ITestService)));

Console.WriteLine("What's the scope? {0}", container.GetRegistrationScope<ITestService>());
// or
Console.WriteLine("What's the scope? {0}", container.GetRegistrationScope(typeof(ITestService)));

```

There's a few options for the registration of dependencies:
  * Call `Register<T>(Funct<T>)` to binds the generic parameter type to the the factory function
  * Call `Register<T>(Type)` to bind the generic parameter to a type. The first constructor will be used
  * Call `Register<T>(Object)` to bind an existing object to the generic parameter - Can only have singleton scope

# Scope
For the `Register<T>(Type)` and `Register<T>(Funct<T>)` calls, there's an optional singleton boolean value to control the dependency's scope. The `Register<T>(Object)` call is always a singleton.

```c#

container.Register<ITestService>(() => new GuiService(), true); // Singleton
container.Register<ITestService>(() => new GuiService(), false); // Transient - Default

container.Register<ITestService>(typeof(StringService), true); // Singleton
container.Register<ITestService>(typeof(StringService), false); // Transient - Default

```

# TODO
  * Add a search for another constructor if a public on can't be found to `Register<T>(Type)`
  * Add parameter support for `Register<T>(Type)`
  * Add a benchmark project and check performance
