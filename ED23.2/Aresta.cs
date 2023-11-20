using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED23._2
{
    public class Aresta
    {
        public double Peso;
        public Vertice Vertice1;
        public Vertice Vertice2;

        public Aresta()
        {
        }

        public Aresta(double p, Vertice v1, Vertice v2)
        {
            Peso = p;
            Vertice1 = v1;
            Vertice2 = v2;
        }
    }
}
