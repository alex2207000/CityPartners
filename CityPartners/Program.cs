// See https://aka.ms/new-console-template for more information
using CityPartners;


string cityTxt = "C:\\Users\\Alex\\source\\repos\\CityPartners\\CityPartners\\Städtepartner\\cities.txt";
string smallCityTxt = "C:\\Users\\Alex\\source\\repos\\CityPartners\\CityPartners\\Städtepartner\\cities-small.txt";
string partnershipsTxt = "C:\\Users\\Alex\\source\\repos\\CityPartners\\CityPartners\\Städtepartner\\partnerships.txt";
string smallpartnershipsTxt = "C:\\Users\\Alex\\source\\repos\\CityPartners\\CityPartners\\Städtepartner\\partnerships-small.txt";

var adjMatrixGraph = new AdjacencyMatrixGraph(9, false);
adjMatrixGraph.AddEdge(0, 8);
adjMatrixGraph.AddEdge(0, 3);
adjMatrixGraph.AddEdge(8, 4);
var adjacent = adjMatrixGraph.GetAdjacentVertices(0);

adjMatrixGraph.Display();

List<City> citylist = new List<City>();

foreach (string line in File.ReadLines(smallCityTxt))
{
    string[] parts = line.Split('"');
    var number = int.Parse(parts[0]);

    var city = new City(parts[1], number);

   citylist.Add(city);

}




Dictionary<string, List<string>> partnerships = new Dictionary<string, List<string>>();
string[] lines = File.ReadAllLines(smallpartnershipsTxt);
foreach (string line in lines)
{
    string[] parts = line.Split(',');
    string city = parts[0].Trim().Replace("\"", "");
    string partner = parts[1].Trim().Replace("\"", "");

    if (!partnerships.ContainsKey(city))
    {
        partnerships[city] = new List<string>();
    }
    partnerships[city].Add(partner);

}

List<PartnersCities> partnersCitiesList = new List<PartnersCities>();


foreach (var city in citylist)
{
    if (partnerships.ContainsKey(city.Name))
    {
        PartnersCities partnersCity = new PartnersCities(city, partnerships[city.Name]);
        partnersCitiesList.Add(partnersCity);
    }
}
foreach (var partnersCity in partnersCitiesList)
{
    Console.WriteLine($"City: {partnersCity.City.Name}, Kapazität: {partnersCity.City.PartyCapacity} , Partners: {string.Join(", ", partnersCity.Partners)}");
}