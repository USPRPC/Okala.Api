namespace Okala.Application.DTOs;

public class WeatherAndAirQualityDto(
    double latitude,
    double longitude,
    double temperature,
    int humidity,
    double windSpeed,
    int aQi,
    double cO,
    double nO,
    double nO2,
    double o3,
    double sO2,
    double pM25,
    double pM10,
    double nH3,
    string cityName)
{
    public string CityName { get; set; } = cityName;
    public double Latitude { get; set; } = latitude;
    public double Longitude { get; set; } = longitude;
    public double Temperature { get; set; } = temperature;
    public int Humidity { get; set; } = humidity;
    public double WindSpeed { get; set; } = windSpeed;
    public int Aqi { get; set; } = aQi;
    public double Co { get; set; } = cO;
    public double No { get; set; } = nO;
    public double No2 { get; set; } = nO2;
    public double O3 { get; set; } = o3;
    public double So2 { get; set; } = sO2;
    public double Pm25 { get; set; } = pM25;
    public double Pm10 { get; set; } = pM10;
    public double Nh3 { get; set; } = nH3;
}