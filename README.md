# 3DWorld / Exercise

REQUIREMENTS

Cube intersection
Design and start and application (or test project) which accepts as input dimensions and coordinates of two cubic objects (considering a 3D space).
The application must determine whether the two objects collide and calculate the intersected volume.
It's not a math exercise, so it is acceptable to consider the two cubes are parallel, so there is no rotation among themselves.
The input coordinates define the center of the cube.
The purpose of this exercise is to define the application design and architecture, focusing on the parts which ensure the correctness, performance and code clarity. 
Any design pattern is accepted and should be justified.

MY APPROACH

I have modeled following the DDD methodology, for this to be evident I have specially developed an aspect of the domain that has to do with the representation of the units, in order to apply, in addition to the concepts of OOP and hence SOLID principles, various DDD patterns.
It's also true that by doing so, I might be walking a bit on the ledge of Cargo Cult's Programming Chasm. :-)
But it is clear that the idea is to show, within the limits of an exercise, mastery of some techniques and adherence to certain practices.

But the code is limited to reflecting a domain model and the functionality is limited to a few methods.

In any case, following the DDD methodology, I have kept the domain model intact for everything related to persistence, execution, communication, etc. 
This makes the domain model pure and keeps you focused on the business. (A principle that saves me from coding everything else that would be quite long :-)

However, in the real world, we still need to build the whole system around it, keeping the domain model as the core of the system.
If we want to think a little about the architecture of what an application or system that surrounds our domain would be, what would be missing is:
(I assume and go on the service creation side ...) expose the web API.

Thinking of having flexibility of frontends, that is, that services can be consumed from, for example, a web application, a mobile application, etc. it is convenient to create the API.
Then we have to make calls to our domain via HTTP (an option, if instead of frontends we point to internal services it could be gRPC).
Here the most important thing is to define the endpoints and API Calls (contracts), since once published and consumed by third parties, any change is cumbersome, especially if it is not backward compatible :-( 

Implementation wise, there is not much to say, I would add an ASP.NET Web API handler.
And something else to accept strongly typed request requests, and the collection of those requests will be our public API and the templates for those requests will be our contracts.
