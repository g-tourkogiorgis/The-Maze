# The Maze

A simple console app written in C# for solving mazes.

  - Run the app
  - Provide a Maze
  - See the correct path steps

### Algorithm

You can register any `IMazePathfinderAlgorithmExecutor` implementation in the IoC container or use the existing ones (a `recursive algorithm` is _registered by default_.

### Maze Source

You can also register your own `IMazeSource` implementation or make use of the provided ones: 
- `FileMazeSource` which is _registered by default_ will prompt you, when the app starts, for an `absolute path` pointing to a file that contains a string representation of a Maze.
 - `CommandLineMazeSource` accepts a maze as a string input.

### Maze definitions

A maze must be a valid `string` containing only the following characters:
`'X' for a wall`
`'_' for a free space`
`'S' for the starting point`
`'G' for the finishing point` 
or 
`.` when you're working with the CommandLineMazeSource. The `.` is interpreted as a new line.

Examples:

A file that contains:
```json
S___X
__XX_
__X__
_X__G
___X_
```

or the same Maze as raw string input: `S___X.__XX_.__X__._X__G.___X_`

### Libraries used

Dillinger uses a number of open source projects to work properly:

* [log4net](https://www.nuget.org/packages/log4net/) - for logging
* [Unity](https://www.nuget.org/packages/Unity/) - for DI
* [Moq](https://www.nuget.org/packages/Moq/) - for unit tests mocking
* [Nunit 3](https://www.nuget.org/packages/NUnit/) - for unit testing
* [Nunit 3 Test Adapter](https://marketplace.visualstudio.com/items?itemName=NUnitDevelopers.NUnit3TestAdapter) for running unit tests (Visual studio extension)

License
----

MIT
