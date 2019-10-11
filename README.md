# SWStarships

Console application used to calculate the number of stops to resupply that a starship needs given a distance.

## How it works

When the application starts, you will be asked to enter a distance. If it is a valid distance, the app goes to [swapi.co](https://swapi.co/), an API with information about Star Wars movies and download all starships. The results will be shown in green if the MGLT of the starship is valid otherwise will be shown in red. The application finishes, when you type exit.

## Screenshot

![consoleapp](https://github.com/douglasbreda/SWStarships/blob/master/Docs/print.png)

## Technologies used

- .NET Core 3.0;
- C# 8.0;
- [Autofac](https://autofac.org/);
- [Newtonsoft JSON](https://www.newtonsoft.com/json);
- [xUnit](https://xunit.net/);
- [NSubstitute](https://nsubstitute.github.io/)
