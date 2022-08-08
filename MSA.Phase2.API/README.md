# Pokemon Database
This database tracks Pokemon Trainers and the Pokemon they have caught. Create your trainer, then add to their pokemon list.

## Section One
This project has two controllers. One for interacting with the Trainers table and one for the Pokemon. Both controllers implement the CRUD operations.

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

I have used the Poke API to get the data for the pokemon in my database. For an update or create the client sends in the codex number of the new pokemon and the rest of the data is requested then processed from the Poke API call.  If the codex number is incorrect then a bad request response will be returned. 

I have used two configuration files to make debugging easier during development, by having access to different levels of logging. The logging levels range from Trace to None. I have the Development enviroment that uses the default logging level, Infomation (Warning for Microsoft.AspNetCore). This is great for standard use as there will not be an overwelming amount of log messages. However there were times when I wanted more detailed log messages so I created the Debugging enviroment that uses the logging level Debug. Having the two enviroments means that I can easily swap between them and have the level of logging that I need at that time.

## Section Two
In object-oriented programming, dependency injection is a useful process that simplifies your code by supplying a resource, called a dependency, that the code requires. 
The benefit of using dependency injection is that it allows you to code without worrying about the task of instantiating the dependencies. This has the added benefits of:
* Allowing the dependencies to be swapped out easily, making maintenance and unit testing easier.  
* Since the framework does the dependency instantiation, the configuration data is centralised, further making maintenance easier.

Middleware refers to the dependencies added to the ASP.Net API pipeline. These are available to be used in your custom classes through dependency injection. ASP.Net core injects these dependencies through the custom class’s constructor. This simplifies the code hugely because, as mentioned above, the dependencies are easy to set up and use, as we do not need to worry about instantiation. The dependencies are all in the same place and are simple to swap out.

## Section Three

