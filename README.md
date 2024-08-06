<div align="center">

  [![Version](https://img.shields.io/github/v/release/georgekairis/flexible-object-reference?include_prereleases&color=F20519)](https://github.com/georgekairis/flexible-object-reference/releases)
  [![Unity](https://img.shields.io/badge/unity-2023.1%2B-FFFFFF)](https://unity.com/releases/editor/archive)

</div>

<br>




<div align="center">

  # Flexible Object Reference

  [![Manual](https://img.shields.io/badge/Manual-0038DE)](#manual)
  [![Changelog](https://img.shields.io/badge/Changelog-F57F18)](./CHANGELOG.md)
  [![Roadmap](https://img.shields.io/badge/Roadmap-C01985)](#roadmap)
  [![Contributing](https://img.shields.io/badge/Contributing-008FF5)](#contributing)
  [![Licanse](https://img.shields.io/badge/License-90C215)](#license)
  [![Support](https://img.shields.io/badge/Support-F52B37)](#support)

</div>

<br>




## Introduction

> [!WARNING]
> This is a preview package and is subject to significant changes.

Flexible Object Reference is a reference management system for Unity that provides a flexible approach to handling object references of both `System.Object` and `UnityEngine.Object` derived classes by allowing the smooth transition to a range of different linking methods, from direct references to more advanced APIs like Unity's Addressables, without the need for code modifications. 

<br>




## Features

- Customizable reference system via the Inspector.
- Synchronous & asynchronous loading operations.
- Direct & self-contained references.
- Supports Unity's Resources.
- Supports Unity's Addressables.
- Automatic type conversion.
- Scriptable containers for serializable classes.
- Internal object caching for optimization.

<br>




## Manual

> [!WARNING]
> This package requires Unity version 2023.1 or later.


### Table of Contents

- [Getting started](#getting-started)
  - [Installing the package](#installing-the-package)
  - [Setting up Addressables](#setting-up-addressables)
- [Setting up a flexible object reference](#setting-up-a-flexible-object-reference)
  - [Creating a flexible object reference](#creating-a-flexible-object-reference)
  - [Using with Unity Objects](#using-with-unity-objects)
  - [Using with System Objects](#using-with-system-objects)
- [Loading an object reference at runtime](#loading-an-object-reference-at-runtime)
  - [Using the standard loading methods](#using-the-standard-loading-methods)
  - [Using the generic loading methods](#using-the-generic-loading-methods)
  - [Using the conversion operators](#using-the-conversion-operators)
  - [Unloading an object reference](#unloading-an-object-reference)
- [Working with scriptable containers](#working-with-scriptable-containers)
  - [About scriptable containers](#about-scriptable-containers)
  - [Creating a scriptable container](#creating-a-scriptable-container)
  - [Reading data from scriptable containers](#reading-data-from-scriptable-containers)
  - [Creating a custom scriptable container](#creating-a-custom-scriptable-container)
- [Primitive object references](#primitive-object-references)
  - [About primitive object references](#about-primitive-object-references)
  - [Working with primitive object references](#working-with-primitive-object-references)

<br>


### Getting started

In this part of the manual you can find information on how to install the Flexible Object Reference package in a Unity project and enable Addressables support.

- [Installing the package](#installing-the-package)
- [Setting up Addressables](#setting-up-addressables)


#### Installing the package

To install the package in a Unity project:

1. Create or open a Unity project with `Unity 2023.1` or later.
1. Go to `Window > Package Manager` to open the Package Manager window.
1. Click the `+` button and select `Add package from git URL`.
1. Paste the repository URL `https://github.com/georgekairis/flexible-object-reference.git` and click `Add`.

Alternatively, [download the latest release](https://github.com/georgekairis/flexible-object-reference/releases) and follow these steps:

1. Create or open a Unity project with `Unity 2023.1` or later.
1. Go to `Window > Package Manager` to open the Package Manager window.
1. Click the `+` button and select `Add package from disk`.
1. Navigate to the root directory of your local package, select the `package.json` file and click `Add`.


#### Setting up Addressables

> [!NOTE]
> Enabling Addressables support is optional. If you do not plan on using Addressables you can skip this step.

Follow the next steps to install [Addressables](https://unity.com/how-to/simplify-your-content-management-addressables) and enable the addressable object reference:

1. Use this [guide](https://docs.unity3d.com/Packages/com.unity.addressables@1.21/manual/installation-guide.html) to install and setup Addressables in your Unity project.
1. Go to `Edit > Project Settings` to open the project settings window.
1. Navigate to `Player > Other Settings > Script Compilation > Scripting Define Symbols`.
1. Add the symbol `ADDRESSABLE_OBJECT_REFERENCE` and click `Apply`.

<br>


### Setting up a flexible object reference

In this part of the manual you can find information on how to create a flexible object reference and set it up it using the Inspector.

- [Creating a flexible object reference](#creating-a-flexible-object-reference)
- [Using with Unity Objects](#using-with-unity-objects)
- [Using with System Objects](#using-with-system-objects)


#### Creating a flexible object reference

To create a flexible object reference, on a [`MonoBehabior`](https://docs.unity3d.com/2023.1/Documentation/ScriptReference/MonoBehaviour.html) or a [`ScriptableObject`](https://docs.unity3d.com/2023.1/Documentation/ScriptReference/ScriptableObject.html) script, create a new serialized field for the generic `Flexible<T>` class and use the type of the object that you want to reference as type argument.

```csharp
[SerializeField]
private Flexible<Foo> _flexibleObjectReference;
```

> [!NOTE]
> Both `System.Object` and `UnityEngine.Object` derived classes are supported but require different setup. The custom property drawer that handles the `Flexible<T>` class detects the base class of the used type and adjusts the property accordingly.


#### Using with Unity Objects

You can use the generic `Flexible<T>` class to reference any object that derives from `UnityEngine.Object`, such as GameObjects and Components inside a scene or a prefab, or any type of Unity asset in your project. To do so, you first need to create a serialized field for the flexible Unity Object reference.

```csharp
[SerializeField]
private Flexible<GameObject> _flexibleGameObject;
```

Inside Unity, navigate to an instance of your script and examine it in the Inspector. The toolbar above the field allows you to select the type of linking method you want to use in order to reference the Unity Object.

<div align="center">
  <img src="Documentation~/Screenshots/Unity/unity_object-standard-0.png"><br>
  <em>Use the toolbar to select the way you want to reference your Unity Object.</em>
</div>

<br>

There are currently there three ways to link a Unity Object:

| Type | Description |
| --- | --- |
| <a href="#standard-unity-object-reference">Standard</a> | Stores a direct reference of the Unity Object. |
| <a href="#resources-unity-object-reference">Resources</a> | Stores the resources path of the Unity Object and loads it at runtime using Resources. |
| <a href="#addressable-unity-object-reference">Address</a> | Stores the addressable label of the Unity Object and loads it at runtime using Addressables. |


#### Using with System Objects

In a similar way, you can use the generic `Flexible<T>` class to reference an instance of any serializable class. To do so, create a serialized field for the flexible System Object reference.

<a name="foo"></a>

```csharp
[Serializable]
public class BaseFoo { }

[Serializable]
public class Foo : BaseFoo
{
    public string Name;
    public int Index;
}
```

```csharp
[SerializeField]
private Flexible<Foo> _flexibleFoo;
```

Inside Unity, navigate to an instance of your script and examine it in the Inspector. The toolbars above the field allows you to select the type of linking method you want to use in order to reference the System Object.

<div align="center">
  <img src="Documentation~/Screenshots/System/system_object-from_instance-0.png"><br>
  <em>Use the toolbar to select the way you want to reference your System Object.</em>
</div>

<br>

In this case there is one more toolbar which allows the selection between using a self-contained reference or an asset:

| Type | Description |
| --- | --- |
| <a href="#from-instance-object-reference">From Instance</a> | Stores a self-contained instance of the serializable class, which is then used as a reference. |
| <a href="#from-asset-object-reference">From Asset</a> | Stores a flexible reference for a scriptable container that holds an instance of the serializable class, which is then used as a reference. |

> [!IMPORTANT]
> In order to use an asset as a reference, you need to [create a scriptable container](#creating-a-scriptable-container) for the serializable class.

Once the scriptable container exists as an asset in your project, you can treat it as a Unity Object.

<div align="center">
  <img src="Documentation~/Screenshots/System/system_object-standard-0.png"><br>
  <em>Use the toolbar to select the way you want to reference your scriptable container.</em>
</div>

<br>

The same linking methods as the ones described for [Unity Objects](#using-with-unity-objects) are available in this case as well:

| Type | Description |
| --- | --- |
| <a href="#standard-unity-object-reference">Standard</a> | Stores a direct reference of the scriptable container. |
| <a href="#resources-unity-object-reference">Resources</a> | Stores the resources path of the scriptable container and loads it at runtime using Resources. |
| <a href="#addressable-unity-object-reference">Address</a> | Stores the addressable label of the scriptable container and loads it at runtime using Addressables. |

<br>


### Loading an object reference at runtime

In this part of the manual you can find information on how to load an object reference at runtime.

- [Using the standard loading methods](#using-the-standard-loading-methods)
- [Using the generic loading methods](#using-the-generic-loading-methods)
- [Using the conversion operators](#using-the-conversion-operators)
- [Unloading an object reference](#unloading-an-object-reference)

The following field is used in all the cases:

```csharp
[SerializeField]
private Flexible<Foo> _flexibleFoo;
```


#### Using the standard loading methods

To load an object reference at runtime use one of the following loading methods. The object will be loaded using the selected API and operation type. Both synchronous and asynchronous loading operations are supported.

```csharp
//Loads the reference synchronously.
var foo = _flexibleFoo.Load();
```

```csharp
//Loads the reference asynchronously.
var foo = await _flexibleFoo.LoadAsync();
```

```csharp
//Loads the reference asynchronously with a callback on 
//completion returning the loaded object reference.
_flexibleFoo.LoadAsync(foo => {
    //Do something with the loaded object reference...
});
```


#### Using the generic loading methods

There is also a set of generic loading methods, allowing type conversion of the loaded object reference. Similarly to the standard loading methods, the object will be loaded using the selected API and operation type. Both synchronous and asynchronous loading operations are supported.

```csharp
//Loads the reference synchronously and converts it to the target type.
var foo = _flexibleFoo.Load<Foo>();
```

```csharp
//Loads the reference asynchronously and converts it to the target type.
var foo = await _flexibleFoo.LoadAsync<Foo>();
```

```csharp
//Loads the reference asynchronously with a callback on 
//completion returning the loaded object reference converted to the target type.
_flexibleFoo.LoadAsync<Foo>(foo => {
    //Do something with the loaded object reference...
});
```


#### Using the conversion operators

In addition, automatic loading and conversion is supported when casting the flexible object reference. In this case the object is loaded synchronously and the type is converted to the linked object's type using a conversion operator. This applies to references stored inside scriptable containers as well, which also support automatic type conversion via the usage of conversion operators.

```csharp
//Loads and converts the reference synchronously.
Foo foo = _flexibleFoo;
```

```csharp
//Loads and converts the reference synchronously.
var foo = (Foo)_flexibleFoo;
```

> [!NOTE]
> In these cases the standard [`Load()`](#using-the-standard-loading-methods) method is used internally to load the object reference at runtime.


#### Unloading an object reference.

Object references are cached internally the first time they are loaded and can be unloaded at any time using the `Release()` method.

```csharp
//Cleans up the cached object reference.
_flexibleFoo.Release();
```

> [!NOTE]
> When you release an object reference, its internal cache gets cleaned up while the referenced object itself stays intact and can be loaded again using any of the loading methods.

<br>


### Working with scriptable containers

In this part of the manual you can find information on how to create and use scriptable containers.

- [About scriptable containers](#about-scriptable-containers)
- [Creating a scriptable container](#creating-a-scriptable-container)
- [Reading data from scriptable containers](#reading-data-from-scriptable-containers)
- [Creating a custom scriptable container](#creating-a-custom-scriptable-container)


#### About scriptable containers

A scriptable container is a [`ScriptableObject`](https://docs.unity3d.com/2023.1/Documentation/ScriptReference/ScriptableObject.html) that stores an instance of a serializable class. Their usage in this package is for wrapping objects that do not derive from `UnityEngine.Object`, so that they can be used as assets in a Unity project.

> [!TIP]
> Scriptable containers can be useful in a variety of situations and can be used independently of this package.


#### Creating a scriptable container

The most common way to create a scriptable container is by inheriting from the generic `GenericScriptableContainer<T>` class. Create a new script that declares a constructed type of this class and use the type of the object that you want to store as type argument.

```csharp
[CreateAssetMenu]
public class ScriptableFooContainer : GenericScriptableContainer<Foo> { }
```

> [!IMPORTANT]
> Since scriptable containers derive from `ScriptableObject`, the filename of the script must match the name of the declared class.

Inside Unity, navigate to `Assets > Create > Scriptable Foo Container` to create the container asset in your project. Select and examine the created asset in the Inspector. An instance of the [`Foo`](#foo) class is stored inside the container and can now be treated as a Unity asset.

<div align="center">
  <img src="Documentation~/Screenshots/Scriptables/generic_scriptable_container-0.png"><br>

  <em>Scriptable container that holds an instance of the [`Foo`](#foo) class.</em>
</div>


#### Reading data from scriptable containers

There are two ways of accessing the data of a scriptable container:

- [Using the Object read-only property](#using-the-object-read-only-property)
- [Using the conversion operators](#using-the-conversion-operators-1)

The following field is used in all the cases:

```csharp
private ScriptableFooContainer _scriptableFoo;
```

##### Using the Object read-only property

The simplest way to access the content of a scriptable container is by using the `Object` read-only property.

```csharp
//Returns the stored object of the scriptable container.
var foo = _scriptableFoo.Object;
```
##### Using the conversion operators

Alternatively, you access the content of a scriptable container by casting it to the contained object's type.

```csharp
//Converts the container type & returns the stored object.
Foo foo = _scriptableFoo;
```

```csharp
//Converts the container type & returns the stored object.
var foo = (Foo)_scriptableFoo;
```


#### Creating a custom scriptable container

The `GenericScriptableContainer<T>` class is a basic implementation of the `AbstractScriptableContainer<T>` class and serves as an out-of-the-box solution. In order to allow for custom implementations, the actual type that is being used to link scriptable containers is this underlying abstract class.

You can create and use custom implementations of scriptable containers by inheriting and implementing the `AbstractScriptableContainer<T>` class or by extending the `GenericScriptableContainer<T>` class.

```csharp
public class CustomScriptableContainer<T> : AbstractScriptableContainer<T>
    where T : class
{
    //The Object property needs to be implemented
    //in the derived class.
    public override T Object
    {
        get => _object;
    }

    //The instance of the contained object.
    private T _object;
}
```

The following scriptable container holds an instance of the [`Foo`](#foo) class and is compatible with `Flexible<Foo>`.

```csharp
[CreateAssetMenu]
public class CustomScriptableFooContainer : CustomScriptableContainer<Foo> { }
```

> [!NOTE]
> The conversion operator is implemented in the base abstract class and needs no additional implementation in the derived class.

<br>


### Primitive object references

In this part of the manual you can find information about primitive object references.

- [About primitive object references](#about-primitive-object-references)
- [Working with primitive object references](#working-with-primitive-object-references)


#### About primitive object references

Primitive object references are the building blocks of this system and are used internally to manage different APIs for storing and loading object references. These classes specify the type of linking method that is going to be used to link the target object and implements the loading operations based on the targeted API.

> [!TIP]
> All primitives can be used directly and independently of this package to simplify linking and loading objects at runtime.

The generic `Flexible<T>` class, as well as all the primitives, implement the `IObjectReference` and `IObjectReference<T>` interfaces via a set of abstract classes that provide the base functionality of a primitive object reference. This design principle establishes a foundation for modularity and extensibility. By using the underlying interfaces and abstract classes, you can create custom primitives that handle specific classes, data structures or assets, or integrate new APIs for storing and loading objects.


#### Working with primitive object references

> [!IMPORTANT]
> Since the generic `Flexible<T>` class and all the primtives implement the `IObjectReference` and `IObjectReference<T>` interfaces, all loading operations are the same as described [here](#loading-an-object-reference-at-runtime).

There are currently four types of primitive object references:

- [From Instance Object Reference](#from-instance-object-reference)
- [Standard Unity Object Reference](#standard-unity-object-reference)
- [Resources Unity Object Reference](#resources-unity-object-reference)
- [Addressable Unity Object Reference](#addressable-unity-object-reference)

##### From Instance Object Reference

The `FromInstanceObjectReference<T>` class is the primitive object reference that is used internally to reference any serializable class using a self-contained instance of the object. 

<div align="center">

  <img align="center" src="Documentation~/Screenshots/System/system_object-from_instance-0-cropped.png"><br>
  <em>A self-contained instance of the serializable [`Foo`](#foo) class is used as a reference.</em>
</div>

<a name="from-asset-object-reference"></a>

> [!IMPORTANT]
> The `FromAsset` option is not represented by a dedicated primitive class. Instead, when selected, the object is wrapped in a scriptable container and a primitive Unity Object reference is used to reference the targeted container. 

<div align="center">

  <img align="center" src="Documentation~/Screenshots/System/system_object-standard-0-cropped.png"><br>
  <em>A primitive Unity Object reference is used to reference the wrapped System Object.</em>
</div>

##### Standard Unity Object Reference

The `StandardUnityObjectReference<T>` class is the primitive object reference that is used internally to reference any Unity Object directly.

<div align="center">

  <img align="center" src="Documentation~/Screenshots/Unity/unity_object-standard-0-cropped.png"><br>
  <em>The Unity Object is stored directly and is used as a reference.</em>
</div>

##### Resources Unity Object Reference

The `ResourcesUnityObjectReference<T>` class is the primitive object reference that is used internally to reference any Unity Object using Unity's [Resources](https://docs.unity3d.com/2023.1/Documentation/ScriptReference/Resources.html) class.

<div align="center">

  <img align="center" src="Documentation~/Screenshots/Unity/unity_object-resources-0-cropped.png"><br>
  <em>The [`resources path`](https://docs.unity3d.com/2023.1/Documentation/ScriptReference/Resources.html) of the Unity Object is stored and the object is loaded using [`Resources.Load`](https://docs.unity3d.com/2023.1/Documentation/ScriptReference/Resources.Load.html).</em>
</div>

##### Addressable Unity Object Reference

> [!WARNING]
> In order to use the addressable object reference you need to [install the Addressables package and setup your project](#setting-up-addressables).

The `AddressableUnityObjectReference<T>` class is the primitive object reference that is used internally to reference any Unity Object using Unity's [Addressables](https://docs.unity3d.com/Packages/com.unity.addressables@0.3/api/UnityEngine.AddressableAssets.Addressables.html) class.

<div align="center">

  <img align="center" src="Documentation~/Screenshots/Unity/unity_object-addressable-0-cropped.png"><br>
  <em>The [`addressable label`](https://docs.unity3d.com/Packages/com.unity.addressables@1.21/manual/Labels.html) of the Unity Object is stored and the object is loaded using [`Addressables.LoadAssetAsync`](https://docs.unity3d.com/Packages/com.unity.addressables@1.21/api/UnityEngine.AddressableAssets.Addressables.LoadAssetAsync.html).</em>
</div>

<br>




## Roadmap

> [!WARNING]
> This package is a side project and is not actively supported. The features mentioned in this section do not have a scheduled release timeline. :anguished:

- [ ] Flexible scriptable containers & support for abstract classes.
- [ ] Dependency injection support using third-party frameworks.
- [ ] Streamlined primitive reference type generation workflow.
- [ ] Streamlined scriptable container generation workflow.
- [ ] Optional execution thread selection using the Inspector.
- [ ] Optional cache policy customization using the Inspector.
- [ ] Improved documentation hosted in a public wiki.

<br>




## Contributing

Pull requests, bug reports, and all other forms of contribution are welcome! Before contributing to this project, please read the [Code of Conduct](./.github/CODE_OF_CONDUCT.md) and [Contributing Guidelines](./.github/CONTRIBUTING.md).

<br>




## License

This project is licensed under the terms of the [MIT License](./LICENSE.md).

<br>




## Support

If you need help using this package, see the [Support Guide](./.github/SUPPORT.md).

<br>
