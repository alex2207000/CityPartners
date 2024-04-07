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

    Console.WriteLine(parts[1]);
  
    var city = new City(parts[1], number);

   citylist.Add(city);

}
citylist.Sort((city1, city2) => city2.PartyCapacity.CompareTo(city1.PartyCapacity));





Dictionary<string, List<string>> partnerships = new Dictionary<string, List<string>>();
string[] lines = File.ReadAllLines(smallpartnershipsTxt);
foreach (string line in lines)
{
    string[] parts = line.Split(',');
    string city1 = parts[0].Trim().Replace("\"", "");
    string city2 = parts[1].Trim().Replace("\"", "");

  
    if (!partnerships.ContainsKey(city1))
    {
        partnerships[city1] = new List<string>();
    }
    if (!partnerships.ContainsKey(city2))
    {
        partnerships[city2] = new List<string>();
    }

  
    partnerships[city1].Add(city2);
    partnerships[city2].Add(city1);
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

Console.WriteLine(partnersCitiesList.Count);


partnersCitiesList.Sort((city1, city2) =>
{
    int capacity1 = city1.City.PartyCapacity;
    int capacity2 = city2.City.PartyCapacity;

    return capacity2.CompareTo(capacity1);

}
);

foreach (var partnersCity in partnersCitiesList)
{
    Console.WriteLine($"City: {partnersCity.City.Name}, Kapazität: {partnersCity.City.PartyCapacity} , Partners: {string.Join(", ", partnersCity.Partners)}");
}

Console.WriteLine();
Console.WriteLine();

// Erstellen Sie eine Liste, um die organisierten Partys für jede Stadt zu speichern
List<(string City, List<string> Parties)> organizedParties = new List<(string City, List<string> Parties)>();

foreach (var partnersCity in partnersCitiesList)
{
    // Erstellen Sie eine leere Liste für die Partys dieser Stadt
    List<string> cityParties = new List<string>();

    // Überprüfen Sie, ob die Stadt Verbindungen zu anderen Städten hat
    foreach (var partner in partnersCity.Partners)
    {
        // Suchen Sie die Partnerstadt in der partnersCitiesList
        var partnerCity = partnersCitiesList.FirstOrDefault(pc => pc.City.Name == partner);

        // Überprüfen Sie, ob die Partnerstadt gefunden wurde und die Kapazität der veranstaltenden Stadt größer als 0 ist
        if (partnerCity != null && partnersCity.City.PartyCapacity > 0)
        {
            // Fügen Sie die Party in die Liste der Partys der veranstaltenden Stadt ein
            cityParties.Add($"Party with {partnerCity.City.Name}");

            // Reduzieren Sie die Kapazität der veranstaltenden Stadt
            partnersCity.City.PartyCapacity--;
        }
    }

    // Fügen Sie die organisierten Partys für diese Stadt zur Liste hinzu
    organizedParties.Add((partnersCity.City.Name, cityParties));
}

// Ausgabe der organisierten Partys für jede Stadt
foreach (var (city, parties) in organizedParties)
{
    Console.WriteLine($"City: {city}, Parties: {string.Join(", ", parties)}");
}