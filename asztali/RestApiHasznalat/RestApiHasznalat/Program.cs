using RestApiHasznalat;

JokeApiHandler jokeApi = new("https://evilinsult.com/generate_insult.php");
CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
var jokeTask = jokeApi.GetJokeAsync("?lang=en&type=json", cancellationTokenSource.Token);
//cancellationTokenSource.Cancel();
var joke = jokeTask.Result;

if (joke == null)
{
    Console.WriteLine("Hiba történt");
}
else
{
    Console.WriteLine($"{joke.insult} \n\nKészült ekkor: {joke.created:yyyy-MM-dd}\n\nKészült itt: {joke.createdBy}");
}