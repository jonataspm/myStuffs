using EstruturaDeDados2;

public class Program
{
    public static void Main(string[] args)
    {
        var continues = 1;
        Tree tree = new Tree(15); 
       do
       {
            Console.Write("Digite um valor: ");
            continues = int.Parse(Console.ReadLine());

            switch (continues) 
            { 
                case 0:
                    break;
                case -1:
                    tree.InOrder(tree.root);
                    Console.WriteLine();
                    tree.PreOrder(tree.root);
                    Console.WriteLine();
                    tree.PosOrder(tree.root);
                    Console.WriteLine();
                    break;
                default:
                    tree.AddNode(continues, tree.root);
                    break;
            }
             

        } while (continues != 0) ;

    }
}