using EstruturaDeDados2;

public class Program
{
    public static void Main(string[] args)
    {
        var continues = 1;
        Tree tree = new Tree(17); 
       do
       {
            Console.Write("Digite um valor: ");
            continues = int.Parse(Console.ReadLine());

            switch (continues) 
            { 
                case 0: // Fecha o codigo
                    break;

                case -1: // Vai chamar a Ordeação de arvore
                    tree.InOrder(tree.root);
                    Console.WriteLine();
                    tree.PreOrder(tree.root);
                    Console.WriteLine();
                    tree.PosOrder(tree.root);
                    Console.WriteLine();
                    break;

                case -2: // Vai chamar o Search
                    Console.Write("Buscar valor: ");
                    var searchValue = int.Parse(Console.ReadLine());
                    var searchNode = tree.Search(searchValue);
                    
                    if (searchNode is null)
                        Console.WriteLine("Not Found");
                    else
                        Console.WriteLine($"Value: {searchNode.info} {(searchNode.left != null ? $"\nLeft: {searchNode.left.info}" : "\nLeft: null")} {(searchNode.right != null ? $"\nRight: {searchNode.right.info}" : "\nRight: null ")}");

                    break;
                     
                case -3: // Vai Deletar um valor
                    Console.Write("Deletar valor: ");
                    var deleteValue = int.Parse(Console.ReadLine());
                    
                    Console.WriteLine($"Foi deletado: {tree.Delete2(deleteValue)}");
                    break;

                case -4: // vai dar altura da arvore
                    Console.WriteLine($"Altura: {tree.Height()}");
                    break;

                default:
                    tree.AddNode(continues, tree.root);
                    break;
            }
             

        } while (continues != 0) ;

    }
}