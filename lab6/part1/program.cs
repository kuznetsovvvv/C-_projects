using System;
using System.Text.Json;

struct Weather
{
    public string Country { get; set; }
    public string Name { get; set; }
    public double Temp { get; set; }
    public string Description { get; set; }

    public Weather(string country, string name, double temp, string desc)
    {
        Country = country;
        Name = name;
        Temp = temp;
        Description = desc;
    }


    public override string ToString()
    {
        return Country;
    }

}


public class Programm
{
    private static HttpClient client = new HttpClient();
    private const string api = "e530339d0b2f2f9e4140b2dda1013d41";
    public static async Task Main()
    {

        List<Weather> weateeeerrrr = new List<Weather>();
        Random randemor = new Random();
        while (weateeeerrrr.Count < 50)
        {
            double shirota = randemor.NextDouble() * 180 - 90;
            double dolgota = randemor.NextDouble() * 360 - 180;
            Console.WriteLine("query was send");
            Weather dobaveit = await GetPoluchRandWeather(shirota, dolgota);
            Console.WriteLine("query get");
            weateeeerrrr.Add(dobaveit);

        }

        foreach (var iiii in weateeeerrrr)
        {
            Console.WriteLine(iiii.ToString());
        }

        var maxtemparerert = weateeeerrrr.Max(elew => elew.Temp);
        var nemaxtemparerert = weateeeerrrr.Min(elew => elew.Temp);
        var srednayatemp = weateeeerrrr.Average(elew => elew.Temp);

        var countrycnt = weateeeerrrr.Select(elew => elew.Country).Distinct().Count();

        var clereclerk = weateeeerrrr.FirstOrDefault(elew => elew.Description == "clear sky");

        var clereclerk22 = weateeeerrrr.FirstOrDefault(elew => elew.Description == "rain");



        var clereclerk44 = weateeeerrrr.FirstOrDefault(elew => elew.Description == "few clouds");


    }

    private static async Task<Weather> GetPoluchRandWeather(double shirota, double dolgota)
    {
        string tudazapr = $"https://api.openweathermap.org/data/2.5/weather?lat={shirota}&lon={dolgota}&appid={api}";
        var resppoluchin = await client.GetStringAsync(tudazapr);

        JsonDocument aaaaoooo = JsonDocument.Parse(resppoluchin);
        var root = aaaaoooo.RootElement;
        if (root.TryGetProperty("sys", out JsonElement strana) && root.TryGetProperty("name", out JsonElement imyagoroda))
        {
            //string coco = strana.GetProperty("country").ToString() ;
            root.TryGetProperty("main", out JsonElement maintemp);
            double tempdlyastruct = maintemp.GetProperty("temp").GetDouble();
            root.TryGetProperty("weather", out JsonElement weatherr);
            string opisaniepogodiii = weatherr[0].GetProperty("description").ToString();
            Weather reusultreturin = new Weather(strana.ToString(), strana.ToString(), tempdlyastruct, opisaniepogodiii);
            return reusultreturin;

        }


        return default;
    }


}