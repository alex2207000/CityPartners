using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityPartners
{
    internal class AdjacencyMatrixGraph : GraphBase
    {
        int[,] Matrix;


        public AdjacencyMatrixGraph(int numVertices, bool directed = false) : base(numVertices, directed)
        {
            GenerateEmptyMatrix(numVertices);
        }

        private void GenerateEmptyMatrix(int numVertrices)
        {
            this.Matrix = new int[numVertrices, numVertrices];
            for(int row = 0; row < numVertrices; row++)
            {
                for (int col = 0; col < numVertrices; col++)
                {
                    Matrix[row, col] = 0;
                }
            }
        }
        public override void AddEdge(int v1, int v2, int weight = 1)
        {
            if (v1 >= this.NumVertices || v2 >= this.NumVertices || v1 < 0 || v2 < 0)
                throw new ArgumentOutOfRangeException("Vertices are out of bounds");

            if (weight < 1) throw new ArgumentException("Weight cannot be less than 1");

            this.Matrix[v1, v2] = weight;

            //In an undirected graph all edges are bi-directional
            if (!this.Directed) this.Matrix[v2, v1] = weight;
        }

        public override int GetEdgeWeight(int v1, int v2)
        {
            return this.Matrix[v1, v2];
        }
        public override IEnumerable<int> GetAdjacentVertices(int v)
        {
            if (v < 0 || v >= this.NumVertices) throw new ArgumentOutOfRangeException("Cannot access vertex");

            List<int> adjacentVertices = new List<int>();
            for (int i = 0; i < this.NumVertices; i++)
            {
                if (this.Matrix[v, i] > 0)
                    adjacentVertices.Add(i);
            }
            return adjacentVertices;
        }
        public override void Display()
        {
            Console.WriteLine("Adjacency Matrix:");

            // Display column indices
            Console.Write("  ");
            for (int col = 0; col < NumVertices; col++)
            {
                Console.Write(col + " ");
            }
            Console.WriteLine();

            // Display rows
            for (int row = 0; row < NumVertices; row++)
            {
                Console.Write(row + " "); // Display row index
                for (int col = 0; col < NumVertices; col++)
                {
                    Console.Write(Matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

    }
}
