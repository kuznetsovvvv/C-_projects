using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Xml.Linq;


public struct Weather
{
    public string Country { get; set; }
    public string Name { get; set; }
    public float Temp { get; set; }
    public string Description { get; set; }


    public void Print()
    {
        Console.WriteLine($"{Country}");
        Console.WriteLine($"{Name}");
        Console.WriteLine($"{Temp}");
        Console.WriteLine($"{Description}");
    }
}

class Program
{
    private static readonly HttpClient client = new HttpClient();
    private const string apiKey = "2d4e25e79f07ed7508618c0200d01ce6";

    static async Task Main(string[] args)
    {

        string filePath = "city.txt";

        // ������ �����
        string[] lines = File.ReadAllLines(filePath);

        // ���� �� �������
        for (int i = 0; i < lines.Length; i++)
        {
            // ���������� ������ �� 3 �������
            string[] parts = lines[i].Split(' ');

            // ��������, ��� � ������ 3 �������
            if (parts.Length != 3)
            {
                Console.WriteLine($"������: � ������ {i + 1} ������������ ������.");
                continue;
            }

            // �������� ��������� City � ���������� �����
            cities[i].city = parts[0];
            cities[i].latitude = double.Parse(parts[1]);
            cities[i].longitude = double.Parse(parts[2]);
        }

        // ������ � ��� ���� ������ �������� City � ������� �� �����
        // ����������� ���� ������ ��� ���������� ������
        foreach (City city in cities)
        {
            Console.WriteLine($"�����: {city.city}, ������: {city.latitude}, �������: {city.longitude}");
        }


        var weathers = new List<Weather>();
        var random = new Random();

        while (weathers.Count < 50)
        {
            double lat = random.NextDouble() * 180 - 90;
            double lon = random.NextDouble() * 360 - 180;

            var weather = await GetWeatherAsync(lat, lon);
            if (weather != null)
            {
                weathers.Add(weather.Value);
            }
        }

        var maxTempCountry = weathers.OrderByDescending(w => w.Temp).First();
        var minTempCountry = weathers.OrderBy(w => w.Temp).First();
        var averageTemp = weathers.Average(w => w.Temp);
        var countryCount = weathers.Select(w => w.Country).Distinct().Count();
        var specificDescription = weathers.FirstOrDefault(w =>
            w.Description == "clear sky" ||
            w.Description == "rain" ||
            w.Description == "few clouds");

        Console.WriteLine($"������ � ������������ ������������: {maxTempCountry.Country} ({maxTempCountry.Temp}�C)");
        Console.WriteLine($"������ � ����������� ������������: {minTempCountry.Country} ({minTempCountry.Temp}�C)");
        Console.WriteLine($"������� ����������� � ����: {averageTemp}�C");
        Console.WriteLine($"���������� ����� � ���������: {countryCount}");
        if (specificDescription.Name != null)
        {
            Console.WriteLine($"������ ��������� ������ � ��������� � ���������: {specificDescription.Country}, {specificDescription.Name}");
        }
        else
        {
            Console.WriteLine("�� ������� ���������� � ��������� 'clear sky', 'rain' ��� 'few clouds'.");
        }
        foreach (var item in weathers)
        {
            item.Print();
        }
    }

    private static async Task<Weather?> GetWeatherAsync(double lat, double lon)
    {
        var response = await client.GetStringAsync($"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={apiKey}&units=metric");
        var json = JObject.Parse(response);

        if (json["sys"] != null && json["name"] != null)
        {
            return new Weather
            {
                Country = (string)json["sys"]["country"],
                Name = (string)json["name"],
                Temp = (float)json["main"]["temp"],
                Description = (string)json["weather"][0]["description"]
            };
        }

        return null;
    }
}