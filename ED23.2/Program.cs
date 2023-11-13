// See https://aka.ms/new-console-template for more information
using ED23._2;
public class Program
{
    public static void Main(string[] args)
    {
        Vertice v1 = new Vertice(1);
        Vertice v2 = new Vertice(2);
        Vertice v3 = new Vertice(3);
        Vertice v4 = new Vertice(4);

        Grafo grafo = new Grafo();

        grafo.adicionarVertice(v1);
        grafo.adicionarVertice(v2);
        grafo.adicionarVertice(v3);
        grafo.adicionarVertice(v4);
        grafo.adicionarAresta(5, v1, v2);
        grafo.adicionarAresta(9, v1, v3);
        grafo.adicionarAresta(8, v1, v4);
        grafo.adicionarAresta(10, v3, v4);


    }
}
       