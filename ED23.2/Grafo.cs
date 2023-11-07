using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED23._2
{
    public class Grafo
    {
        public List<Vertice> Vertices = new List<Vertice>();
        public List<Aresta> Arestas = new List<Aresta>();

        public void adicionarVertice(Vertice vertice)
        {
            Vertices.Add(vertice);
        }

        public void adicionarAresta(decimal peso, Vertice org, Vertice dst)
        {
            Aresta novaAresta = new Aresta(peso, org, dst);
            org.Adjacentes.Add(dst);
            dst.Adjacentes.Add(org);
            Arestas.Add(novaAresta);
        }
    }
}
