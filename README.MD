# The Using Directive
Should `using` directives be inside or outside the namespace?
When someone is refering to the `using` statement, they most likely mean the directive if they also refer to namespaces.
The `using` statemant, which help ensure that `IDisposable` objects such as database connections are handled correctly.. 
```cs
using(var connection = new SqlConnection()) {
    connection....
}
```
Just having a look at [Stack Overflow](http://stackoverflow.com/a/151560) to see what other poeple have to say in this matter.

So, the `using` directive has three uses:
- To allow the use of types in a namespace so that you do not have to qualify the use of a type in that namespace: `using System.Text;`
- To allow you to access static members of a type without having to qualify the access with the type name: `using static System.Math;`
- To create an alias for a namespace or a type. This is called a using alias directive: `using Project = PC.MyCompany.Project;`

This can be used for (alias) naming a Func delegates `using  A = System.Func<bool>;`

I couldn't resist having a look at [Ecma-334](http://www.ecma-international.org/publications/standards/Ecma-334.htm) par.16.2, this is what it tells us.

Namespaces are implicitly `public` and the declaration of a namespace cannot include any access modifiers. 

Within a _namespace-body_, the optional _using-directives_ import the names of other namespaces and types, allowing them to be referenced directly instead of through qualified names. The optional _namespacemember-declarations_ contribute members to the declaration space of the namespace. All _extern-aliasdirectives_ shall appear before any _using-directives_ and all _extern-alias-directives_ and _using-directives_ shall appear before any member declarations.

As shown in par 16.4.2 examples.

Example:
The following example shows how to define a **using** directive and a **using** alias for a class:
```cs
using System;

// Using alias directive for a class.
using AliasToMyClass = NameSpace1.MyClass;

// Using alias directive for a generic class.
using UsingAlias = NameSpace2.MyClass<int>;

namespace NameSpace1
{
    public class MyClass
    {
        public override string ToString()
        {
            return "You are in NameSpace1.MyClass.";
        }
    }

}

namespace NameSpace2
{
    class MyClass<T>
    {
        public override string ToString()
        {
            return "You are in NameSpace2.MyClass.";
        }
    }
}

namespace NameSpace3
{
    // Using directive:
    using NameSpace1;
    // Using directive:
    using NameSpace2;

    class MainClass
    {
        static void Main()
        {
            AliasToMyClass instance1 = new AliasToMyClass();
            Console.WriteLine(instance1);

            UsingAlias instance2 = new UsingAlias();
            Console.WriteLine(instance2);

        }
    }
}
// Output: 
//    You are in NameSpace1.MyClass.
//    You are in NameSpace2.MyClass.
```

### There are only subtle differences...
To wrap it all up.., it doesn't really matter where you place the using directives.

```cs
using Syatem;
using Sample.Lib.Data;
using Sample.Lib.Data.Annotation;
using Sample.Lib.Data.Linq;

namespace Sample.Lib {

    class Turbo {

    }
}
```
or

```cs
using Syatem;

namespace Sample.Lib {

    using Data;
    using Data.Annotation;
    using Data.Linq;

    class Turbo {

    }
}
```
