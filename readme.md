# Demo of Microsoft Orleans
Orleans is a cross-platform framework for building robust, scalable distributed applications. Distributed applications are defined as apps that span more than a single process, often beyond hardware boundaries using peer-to-peer communication.

## The Action Model
> Orleans is based on the "actor model". The actor model originated in the early 1970s and is now a core component of Orleans. The actor model is a programming model in which each actor is a lightweight, concurrent, immutable object that encapsulates a piece of state and corresponding behavior. Actors communicate exclusively with each other using asynchronous messages. Orleans notably invented the Virtual Actor abstraction, wherein actors exist perpetually.
>
>> Actors are purely logical entities that always exist, virtually. An actor cannot be explicitly created nor destroyed, and its virtual existence is unaffected by the failure of a server that executes it. Since actors always exist, they are always addressable.
>

## What are Grains?
The grain is one of several Orleans primitives. In terms of the actor model, a grain is a virtual actor. The fundamental building block in any Orleans application is a grain. Grains are entities comprising user-defined identity, behavior, and state. Consider the following visual representation of a grain:

![](https://docs.microsoft.com/en-us/dotnet/orleans/media/grain-formulation.svg)

Grains can have volatile or persistent state data that can be stored in any storage system. As such, grains implicitly partition application states, enabling automatic scalability and simplifying recovery from failures. The grain state is kept in memory while the grain is active, leading to lower latency and less load on data stores.

![](https://docs.microsoft.com/en-us/dotnet/orleans/media/grain-lifecycle.svg#lightbox)

## What are Silos?
A silo is another example of an Orleans primitive. A silo hosts one or more grains. The Orleans runtime is what implements the programming model for applications.

Typically, a group of silos runs as a cluster for scalability and fault tolerance. When run as a cluster, silos coordinate with each other to distribute work and detect and recover from failures.

![](https://docs.microsoft.com/en-us/dotnet/orleans/media/cluster-silo-grain-relationship.svg#lightbox)

In addition to the core programming model, silos provide grains with a set of runtime services such as timers, reminders (persistent timers), persistence, transactions, streams, and more. 
---
## Useful Links:
- Original document: https://docs.microsoft.com/en-us/dotnet/orleans/overview
- Original source code: https://github.com/dotnet/orleans/tree/main/samples/BankAccount
