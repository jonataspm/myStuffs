using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Program;

namespace EstruturaDeDados2
{
    public class Tree
    {
        public Tree(int value) => root = new Node(value);

        public Node root { get; set; }

        public void AddNode(int value, Node root)
        {

            if (root is null)
                root = new Node(value);

            else if (root.info == value) { 
                Console.WriteLine("numero ja inserido");
                return;
            }

            else if (value < root.info)
            {
                if (root.left is null)
                    root.left = new Node(value);

                else 
                    AddNode(value, root.left);
                
            }
            else if (value > root.info)
            {
                if (root.right is null)
                    root.right = new Node(value);
                else  
                    AddNode(value, root.right);
                
            }

        }

        public void InOrder(Node node)
        {
            if (node.left is not null)
                InOrder(node.left);
          
            Console.Write($" {node.info} ");
            
            if (node.right is not null)
                InOrder(node.right);
        }

        public void PreOrder(Node node)
        {
            Console.Write($" {node.info} ");

            if (node.left is not null)
                PreOrder(node.left);

            if (node.right is not null)
                PreOrder(node.right);
        }

        public void PosOrder(Node node)
        {
            if (node.left is not null)
                PosOrder(node.left);

            if (node.right is not null)
                PosOrder(node.right);

            Console.Write($" {node.info} ");
        }
    }
}
