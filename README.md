# Checkout

The architecture proposes a microservice oriented architecture implementation with multiple autonomous microservices (each one owning its own data/db) and implementing different approaches within each microservice, using Http as the communication protocol between the client apps and the microservices.

#### Basket.Api 

This API will allow our users to set up and manage an order of items.  
The API will allow users to add and remove items and change the quantity of the items they want.  
They should also be able to simply clear out all items from their order and start again

#### Catalog.Api

Existing data storage solution that provides catalog-related functionalities.

#### Desktop.Api and Mobile.Api

Rather than have a general-purpose API backend, instead we have one backend per user experience - or backend for frontend (BFF). Conceptually, think of the user-facing application as being two components - a client-side application living outside our perimeter, and a server-side component (BFF) inside our perimeter.

The BFF is tightly coupled to a specific user experience, and will typically be maintained by the same team as the user interface, thereby making it easier to define and adapt the API as the UI requires, while also simplifying process of lining up release of both the client and server components.

https://samnewman.io/patterns/architectural/bff/
https://microservices.io/patterns/apigateway.html

Note: The Mobile.Api has not been fully implemented, it's just a placeholder project that could be extended in future versions of this prototype.

#### Desktop.Client

Client library that makes use of the API endpoints exposed in Desktop.Api, the purpose of this code to provide authors of client applications a simple framework to use in their applications.
In order to speed up the creation of the prototype I have decided to use the REST API client generated code but the resulting classes are marked as 'internal', this could make easier the refactoring into a different methodology or strategy.
