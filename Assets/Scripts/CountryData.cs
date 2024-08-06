public struct CountryData
{
    private int id;
    private string name;
    private int population;
    private int area;
    private int gdp;
    private int longitude;
    private int latitude;

    public readonly int Id { get => id; }
    public readonly string Name { get => name; }
    public readonly int Population { get => population; }
    public readonly int Area { get => area; }
    public readonly int Gdp { get => gdp; }
    public readonly int Longitude { get => longitude; }
    public readonly int Latitude { get => latitude; }

    public void Set(int id,string name,int population,int area,int gdp,int longitude,int latitude)
    {
        this.id = id;
        this.name = name;
        this.population = population;
        this.area = area;
        this.gdp = gdp;
        this.longitude = longitude;
        this.latitude = latitude;
    }
}
