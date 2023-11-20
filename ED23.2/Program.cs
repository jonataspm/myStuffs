// See https://aka.ms/new-console-template for more information
using ED23._2;
public class Program
{
    public static void Main(string[] args)
    {
        Vertice v1 = new Vertice(1, "A");
        Vertice v2 = new Vertice(2, "B");
        Vertice v3 = new Vertice(3, "C");
        Vertice v4 = new Vertice(4, "D");
        Vertice v5 = new Vertice(5, "E");
        Vertice v6 = new Vertice(6, "F");
        Vertice v7 = new Vertice(7, "G");

        Grafo grafo = new Grafo();

        grafo.adicionarVertice(v1);
        grafo.adicionarVertice(v2);
        grafo.adicionarVertice(v3);
        grafo.adicionarVertice(v4);
        grafo.adicionarVertice(v5);
        grafo.adicionarVertice(v6);
        grafo.adicionarVertice(v7);

        grafo.adicionarAresta( 7, v1, v2); //A
        grafo.adicionarAresta( 5, v1, v4);

        grafo.adicionarAresta( 8, v2, v3); //B
        grafo.adicionarAresta( 9, v2, v4);
        grafo.adicionarAresta( 7, v2, v5);

        grafo.adicionarAresta( 5, v3, v5); //C

        grafo.adicionarAresta(15, v4, v5); //D
        grafo.adicionarAresta( 6, v4, v6);

        grafo.adicionarAresta( 8, v5, v6); //E
        grafo.adicionarAresta( 9, v5, v7);

        grafo.adicionarAresta(11, v6, v7); //F


        try
        {
            grafo.Print(grafo.BuscaEmLargura(v1));
            grafo.Print(grafo.BuscaEmProfundidade(v1));
            grafo.PrintN(grafo.BuscaEmProfundidade(v1));
            grafo.PrintNI(grafo.Dijkstra(v1));
        }
        catch (Exception ex) 
        { 
            Console.WriteLine(ex.Message);
        }

        Console.ReadKey();
    }
}
       