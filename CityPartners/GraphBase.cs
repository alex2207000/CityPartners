using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityPartners
{
    public abstract class GraphBase
    {
        protected readonly int NumVertices;
        protected readonly bool Directed;

        public GraphBase(int numVertices, bool directed = false)
        {
            this.NumVertices = numVertices;
            this.Directed = directed;
        }

        public abstract void AddEdge(int v1, int v2, int weight);

        public abstract IEnumerable<int> GetAdjacentVertices(int v);

        public abstract int GetEdgeWeight(int v1, int v2);

        public abstract void Display();

       // public int NumVertices { get { return this.NumVertices; } }
       public int GetNumVertices()
        {
            return this.NumVertices;
        }
    }
}
