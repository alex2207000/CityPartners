using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityPartners
{
    public  class City
    {
        private string _name;
        private int _partyCapacity;


        public City(string name, int partyCapacity) {
        
            _name = name;
            _partyCapacity = partyCapacity;
        }

        public string Name
        {
            get{  return _name; }
            set{ _name = value; }
        }

        public int PartyCapacity
        {
            get { return _partyCapacity; }
            set { _partyCapacity = value; }
        }

    
       

        
    }
}
