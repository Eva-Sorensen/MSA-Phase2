# Pokemon Database
This database tracks Pokemon Trainers and the Pokemon they have caught. Create your trainer, then add it to their pokemon list.

## Section One
This project has two controllers, one controller for interacting with the Trainers table and one for the Pokemon. Both controllers implement the CRUD operations.

Trainers
* Read - /Trainers - Returns a list of all the basic data of the trainers in the database
* Read  - /Trainers{id} - Returns the details of a single trainer in the database
* Create - /Trainers - Adds the trainer to the database 
* Update - /Trainers{id} - Updates the selected trainer
* Delete - /Trainers{id} - Deletes the selected trainer

Pokemons
* Read - /Pokemons - Returns a list of all the basic data of the pokemons in the database
* Read  - /Pokemons{id} - Returns the details of a single pokemon in the database
* Create - /Pokemons - Adds the pokemon to the database 
* Update - /Pokemons{id} - Updates the selected pokemon
* Delete - /Pokemons{id} - Deletes the selected pokemon

I have used the Poke API to get the data for the pokemon in my database. For an update or to create a new pokemon, the client sends in the codex number of their new pokemon and the trainer id of the pokemon’s trainer. The rest of the pokemons data is requested then processed from the Poke API call.  The API will return a bad request response if the codex number is out of bounds. 

I have used two configuration files to make debugging easier during development by having access to different logging levels. The logging levels range from Trace to None. I have the Development environment that uses the default logging level, Infomation (Warning for Microsoft.AspNetCore). This is great for standard use as there will not be an overwhelming amount of log messages. However, there were times when I wanted more detailed log messages, so I created the Debugging environment that uses the logging level Debug. Having the two environments means that I can easily swap between them and have the level of logging that I need at that time.

## Section Two
In object-oriented programming, dependency injection is a useful process that simplifies your code by supplying a resource, called a dependency, that the code requires. 
The benefit of using dependency injection is that it allows you to code without worrying about the task of instantiating the dependencies. This has the added benefits of:
* Allowing the dependencies to be swapped out easily, making maintenance and unit testing easier.  
* Since the framework does the dependency instantiation, the configuration data is centralised, further making maintenance easier.

Middleware refers to the dependencies added to the ASP.Net API pipeline. These are available to be used in your custom classes through dependency injection. ASP.Net core injects these dependencies through the custom class’s constructor. This simplifies the code hugely because, as mentioned above, the dependencies are easy to set up and use, as we do not need to worry about instantiation. The dependencies are all in the same place and are simple to swap out.

## Section Three
I created a test project MSA.Phase2.API.Test which has test suites to unit test my controllers using NUnit. 

I used a substitute database, mapper, and a mock IHttpClientFactory to test my code. Having these dependencies mocked or substituted meant that I could run repeatable and consistent unit tests that do not affect the state of the actual database or dependencies.

The middleware libraries I used made my code much easier to test. Swagger allowed me to view and test the responses from my API easily. This made the development much easier as I could quickly test changes I had made in a clear view. In my unit testing, Moq and Microsoft.EntityFrameworkCore.InMemory libraries were vital. These libraries allowed me to create mock clients and a mock database context. This made it possible to create repeatable and consistent unit tests that do not affect the actual data. The middleware libraries made the testing process much cleaner and easier.


