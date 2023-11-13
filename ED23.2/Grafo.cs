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

        public void BuscaEmLargura(Vertice origem)
        {
            List<Vertice> fila = new List<Vertice> { origem };
            HashSet<Vertice> visitados = new HashSet<Vertice>();
            visitados.Add(origem);

            while (fila.Count > 0)
            {
                Vertice verticeAtual = fila[0];
                fila.RemoveAt(0);
                Console.WriteLine($"Visitando vértice: {verticeAtual}");

                List<Vertice> vizinhos = verticeAtual.Adjacentes;
                foreach (Vertice vizinho in vizinhos)
                {
                    if (!visitados.Contains(vizinho))
                    {
                        fila.Add(vizinho);
                        visitados.Add(vizinho);
                    }
                }
            }
        }

        public void BuscaEmProfundidade(Vertice origens)
        {
            HashSet<Vertice> visitados = new HashSet<Vertice>();
            _BuscaProfundidadeRecursiva(origens, visitados);
        }

        private void _BuscaProfundidadeRecursiva(Vertice verticeAtual, HashSet<Vertice> visitados)
        {
            visitados.Add(verticeAtual);
            Console.WriteLine($"Visitando vértice {verticeAtual}");

            foreach (Vertice vizinho in verticeAtual.Adjacentes)
            {
                if (!visitados.Contains(vizinho))
                {
                    _BuscaProfundidadeRecursiva(vizinho, visitados);
                }
            }
        }

        public void GetPesos(Vertice? orn)
        {

            Vertices.ForEach(prop => prop.Info = double.PositiveInfinity); //Define as infos como infinitas

            if (orn is null)
                Vertices[0].Info = 0;
            else
            {
                var origem = Vertices.Find(prop => prop == orn);

                if (origem is not null)
                    origem.Info = 0;
                else
                { 
                    Console.Write("Verticie não Encontrada"); 
                    return; 
                }

            }

            List<Vertice> list = new List<Vertice>();
            list = Vertices;

            while (list is not null)
            {
                var position = list.OrderBy(prop => prop.Info).First(); //Orderna de forma crescete pelo os Info e pega o 1º
                list.Remove(position);

                foreach (var adj in position.Adjacentes)
                {
                    if (!list.Contains(adj))
                        continue;

                    var peso = GetPeso(position, adj);
                    var distance = position.Info + peso;

                    if (distance < adj.Info)
                        adj.Info = distance;
                }
            }

            Vertices.ForEach(prop => Console.WriteLine($" Vertcie: {prop} \nInfo: {prop.Info}"));
        }

    }
}
