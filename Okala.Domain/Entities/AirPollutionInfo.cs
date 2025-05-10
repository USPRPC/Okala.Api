namespace Okala.Domain.Entities;


public class AirPollutionInfo
{
    public Coord Coord { get; set; }
    public List<List> List { get; set; }
}

public class Components
{
    public double Co { get; set; }
    public double No { get; set; }
    public double No2 { get; set; }
    public double O3 { get; set; }
    public double So2 { get; set; }
    public double Pm25 { get; set; }
    public double Pm10 { get; set; }
    public double Nh3 { get; set; }
}

public class List
{
    public AqiMain Main { get; set; }
    public Components Components { get; set; }
    public int Dt { get; set; }
}

public class AqiMain
{
    public int Aqi { get; set; }
}