using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class FeatureCollection
{
    public List<Feature> features { get; set; }
}

public class Feature
{
    public Properties properties { get; set; }
}

public class Properties
{
    public string place { get; set; }
    public double? mag { get; set; }
}

public static class Earthquake
{
    public static async Task<List<string>> EarthquakeDailySummary()
    {
        using var client = new HttpClient();
        var url = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        var json = await client.GetStringAsync(url);

        var data = JsonSerializer.Deserialize<FeatureCollection>(json);
        var result = new List<string>();
        if (data?.features != null)
        {
            foreach (var feature in data.features)
            {
                var place = feature.properties.place;
                var mag = feature.properties.mag;
                if (place != null && mag != null)
                    result.Add($"{place} - Mag {mag}");
            }
        }
        return result;
    }
}