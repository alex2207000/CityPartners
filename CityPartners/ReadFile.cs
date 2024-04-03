using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CityPartners
{
    public class ReadFile
    {

        string cityTxt = "C:\\Users\\Alex\\source\\repos\\CityPartners\\CityPartners\\Städtepartner\\cities.txt";
        string smallCityTxt = "C:\\Users\\Alex\\source\\repos\\CityPartners\\CityPartners\\Städtepartner\\cities-small.txt";
        string partnershipsTxt = "C:\\Users\\Alex\\source\\repos\\CityPartners\\CityPartners\\Städtepartner\\partnerships.txt";
        string smallpartnershipsTxt = "C:\\Users\\Alex\\source\\repos\\CityPartners\\CityPartners\\Städtepartner\\partnerships-small.txt";

        public List<(int, string)> ReadCityList()
        {
            List<(int, string)> data = new List<(int, string)>();

            // Datei zeilenweise lesen
            foreach (string line in File.ReadLines(smallCityTxt))
            {
               
                // Zeile in Teile aufteilen
                string[] parts = line.Split('"');

                var number = int.Parse(parts[0]);


                data.Add((number, parts[1]));



                
             
            }

            return data;
        }

        public List<(string, string)> ReadPartnerships()
        {
            List<(string, string)> data = new List<(string, string)>();

            foreach (string line in File.ReadLines(smallpartnershipsTxt))
            {
                string[] parts = line.Split('"');

                data.Add((parts[1], parts[3]));

            }




            return data;
        }
      


    }
}
