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

        public void adicionarAresta(decimal peso, Vertice org, Vertice dst)
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
                Console.WriteLine($"Visitando vértice: {verticeAtual}");

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
            Console.WriteLine($"Visitando vértice {verticeAtual}");

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
                    vizinhos.ForEach(vizinho =>
                    {
                        if (!marks.Contains(vizinho)) { 
                            marks.Add(vizinho);
                            aux.Push(vizinho);
                            
                        }
                    });
                   
                }
                else
                    aux.Pop();
              
            }
            return marks;
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
                var verticeSelected = list.OrderBy(prop => prop.Info).First(); //Orderna de forma crescete pelo os Info e pega o 1º
                list.Remove(verticeSelected);

                foreach (var adj in verticeSelected.Adjacentes)
                {
                    if (!list.Contains(adj))
                        continue;

                    var distance = verticeSelected.Info;

                    if (distance < adj.Info)
                        adj.Info = distance;
                }
            }

            Vertices.ForEach(prop => Console.WriteLine($" Vertcie: {prop} \nInfo: {prop.Info}"));
        }

    }
}
