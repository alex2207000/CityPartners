using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CityPartners
{
    public class PartnersCities
    {
        private City _city;
        private List<string> _partners;


        public PartnersCities(City city, List<string> partners)
        {
            _city = city;
            _partners = partners;

        }

        public City City
        {
            get { return _city; }
            set { _city = value; }
        }

        public List<string> Partners
        {
            get { return _partners; }
            set { _partners = value; }
        }


    }
}
