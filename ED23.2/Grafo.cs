using System;
using System.Collections;
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

        public void adicionarAresta(double peso, Vertice org, Vertice dst)
        {
            Aresta novaAresta = new Aresta(peso, org, dst);
            org.Adjacentes.Add(dst);
            dst.Adjacentes.Add(org);
            Arestas.Add(novaAresta);
        }

        public List<Vertice> BuscaEmLargura(Vertice origem)
        {
            List<Vertice> marks = new List<Vertice> { origem };
            List<Vertice> aux = new List<Vertice>();
            aux.Add(origem);

            while (aux.Count > 0)
            {
                Vertice verticeAtual = aux[0];
                aux.RemoveAt(0);

                foreach (var vizinho in verticeAtual.Adjacentes)
                {
                    if (!marks.Contains(vizinho))
                    {
                        marks.Add(vizinho);
                        aux.Add(vizinho);
                    }
                }
            }
            return marks;
        }

        public void BuscaProfundidadeRecursiva(Vertice origens)
        {
            HashSet<Vertice> visitados = new HashSet<Vertice>();
            _BuscaProfundidadeRecursiva2(origens, visitados);
        }

        private void _BuscaProfundidadeRecursiva2(Vertice verticeAtual, HashSet<Vertice> visitados)
        {
            visitados.Add(verticeAtual);

            foreach (Vertice vizinho in verticeAtual.Adjacentes)
            {
                if (!visitados.Contains(vizinho))
                {
                    _BuscaProfundidadeRecursiva2(vizinho, visitados);
                }
            }
        }

        public List<Vertice> BuscaEmProfundidade(Vertice origem)
        {
            List<Vertice> marks = new List<Vertice> { origem };
            Stack<Vertice> aux = new Stack<Vertice>(); 
            aux.Push(origem);

            while (aux.Count > 0) 
            { 
                var top = aux.Peek();
                var vizinhos = top.Adjacentes;

                if (vizinhos != null) 
                {
                    int i=0;
                    for (i = 0 ; i < vizinhos.Count; i++) 
                    {
                        if (!marks.Contains(vizinhos[i])) 
                        {
                            marks.Add(vizinhos[i]);
                            aux.Push(vizinhos[i]);
                            break;
                        }
                        
                    }

                    if(i == vizinhos.Count)
                        aux.Pop();

                }
                else
                    aux.Pop();
              
            }
            return marks;
        }

        public List<Vertice> Dijkstra(Vertice orn)
        {
            List<Vertice> listVerticie = new List<Vertice>(Vertices); // Cria uma cópia
            listVerticie.ForEach(prop => prop.Info = double.PositiveInfinity);

            if (orn is null)
                listVerticie[0].Info = 0;
            else
            {
                var origem = Vertices.Find(prop => prop == orn);

                if (origem is not null)
                    origem.Info = 0;
                else
                {
                    throw new Exception("Vértice não encontrado");
                }
            }

            List<Vertice> listAux = new List<Vertice>(listVerticie);

            while (listAux.Count > 0)
            {
                var verticeSelected = listAux.OrderBy(prop => prop.Info).First();
                listAux.Remove(verticeSelected);

                foreach (var adj in verticeSelected.Adjacentes)
                {
                    if (!listAux.Contains(adj))
                        continue;

                    var peso = GetPeso(verticeSelected, adj);
                    var distance = verticeSelected.Info + peso;

                    if (distance < adj.Info)
                        adj.Info = distance;
                }
            }

            return listVerticie;
        }


        public double GetPeso(Vertice from, Vertice to) 
        {
            var aresta = Arestas.Find(prop => (prop.Vertice1 == from && prop.Vertice2 == to) || (prop.Vertice1 == to && prop.Vertice2 == from) );

            return aresta.Peso;
        }

        public void Print(List<Vertice> vertices)
        {
            string console = "";
            foreach (var vertcie in vertices)
                console += $"{vertcie.Info} ";

            Console.WriteLine(console);
        }

        public void PrintN(List<Vertice> vertices)
        {
            string console = "";
            foreach (var vertcie in vertices)
                console += $"{vertcie.Name} ";

            Console.WriteLine(console);
        }

        public void PrintNI(List<Vertice> vertices)
        {
            string console = "";
            foreach (var vertcie in vertices)
                console += $"{vertcie.Name} = {vertcie.Info} \n";

            Console.WriteLine(console);
        }
    }
}
