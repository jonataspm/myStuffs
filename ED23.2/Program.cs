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

        grafo.Vertices.ForEach(prop => prop.Info = double.PositiveInfinity); //Define as infos como infinitas

        v2.Info = 0; //Define Origem

        List<Vertice> list = grafo.Vertices;

        while (list is not null) 
        {
            var position = list.OrderBy(prop => prop.Info).First(); //Orderna de forma crescete pelo os Info e pega o 1º
                
            list.Remove(position);

            foreach (var adj in position.Adjacentes)
            {
                if (!list.Contains(adj))
                    continue;

                var peso = grafo.GetPeso(position, adj);
                var distance = position.Info + peso;

                if (distance < adj.Info)
                    adj.Info = distance;
            }
        }
        
        grafo.Vertices.ForEach(prop => Console.WriteLine($" Vertcie: {prop} \nInfo: {prop.Info}"));
    }
}
       