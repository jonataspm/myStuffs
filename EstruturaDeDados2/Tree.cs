using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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

        public void AddNode(int value, Node node)
        {

            if (node is null)
                node = new Node(value);

            else if (node.info == value)
            {
                Console.WriteLine("numero ja inserido");
                return;
            }

            else if (value < node.info)
            {
                if (node.left is null)
                {
                    node.left = new Node(value);
                    node.left.parent = node;
                }

                else
                    AddNode(value, node.left);

            }
            else if (value > node.info)
            {
                if (node.right is null)
                {
                    node.right = new Node(value);
                    node.right.parent = node;
                }
                else
                    AddNode(value, node.right);

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
        public Node? Search(int value)
        {
            return Search(value, root);
        }

        private Node? Search(int value, Node node)
        {
            if (node is null)
                return null;

            if (node.info == value)
                return node;
            else
            {
                Node? nodeFound;

                if (value < node.info)
                {
                    nodeFound = Search(value, node.left);
                }
                else
                {
                    nodeFound = Search(value, node.right);

                }
                return nodeFound;
            }

        }

        public bool Delete(int value)
        {
            return Delete(value, root);
        }

        private bool Delete(int value, Node node)
        {
            Node? aux = null;

            if (node.info > value)
            {
                if (node.left is null)
                    return false;

                if (node.left.info == value)
                {
                    aux = node.left;

                    // Sem filho
                    if (aux.left is null && aux.right is null)
                        node.left = null;

                    // 2 filhos
                    else if (aux.left is not null && aux.right is not null)
                    {
                        var sucessor = GetAntesseor(aux.right);
                        sucessor.left = aux.left;
                        aux.left.right = aux.right;
                        node.left = sucessor;
                    }

                    // 1 filho
                    else
                    {
                        if (aux.left is not null)
                            node.left = aux.left;
                        else
                            node.left = aux.right;
                    }

                    return true;
                }

                return Delete(value, node.left);
            }
            else if (node.info < value)
            {
                if (node.right is null)
                    return false;

                if (node.right.info == value)
                {
                    aux = node.right;

                    // Sem filho
                    if (aux.left is null && aux.right is null)
                        node.right = null;

                    // 2 filhos
                    else if (aux.left is not null && aux.right is not null)
                    {
                        var sucessor = GetSucessor(aux.right);
                        sucessor.left = aux.left;
                        sucessor.right.right = aux.right;
                        node.right = sucessor;
                    }

                    // 1 filho
                    else
                    {
                        if (aux.left is not null)
                            node.right = aux.left;
                        else
                            node.right = aux.right;
                    }

                    return true;
                }

                return Delete(value, node.right);
            }
            else
            {
                if (node.left is not null && node.right is not null || node.left is null && node.right is not null)
                {
                    var sucessor = GetSucessor(node.right);
                    sucessor.left = node.left;
                    sucessor.right = node.right;
                    root = sucessor;
                }
                else if (node.left is not null && node.right is null)
                {
                    var antessesor = GetAntesseor(node.left);
                    antessesor.left = node.left;
                    antessesor.right = node.right;
                    root = antessesor;
                }
                else
                    node = null;

                return true;
            }
        }


        public bool Delete2(int value)
        {
            var node = Search(value);

            if (node is null)
                return false;
            else if (node.parent is null)
                root = Delete2(node);
            else if (node.parent.info > node.info)
                node.parent.left = Delete2(node);
            else
                node.parent.right = Delete2(node);

            return true;
        }

        private Node? Delete2(Node node)
        {

            if (node.left is null && node.right is null)
            {
                return null;
            }
            else if (node.left is null)
            {
                node.right.parent = node.parent;
                return node.right;
            }
            else if (node.right is null)
            {
                node.left.parent = node.parent;
                return node.left;
            }
            else
            {
                var left = node.left;
                var right = node.right;

                var sucessor = GetSucessor2(right);

                sucessor.parent = node.parent;

                right.parent = sucessor;
                left.parent = sucessor;

                sucessor.right = right;
                sucessor.left = left;

                return sucessor;

            };


            return null;
        }
        private Node GetSucessor2(Node node)
        {
            Node aux = null;

            if (node.left is null)
            {
                node.parent.left = node.right;
                node.right.parent = node.parent;
                return node;
            }
            else
                return GetSucessor2(node.left);
        }

        private Node GetSucessor(Node node)
        {
            if (node.left is null)
            {
                var aux = node.left;
                node.left = aux.right;
                return aux;
            }
            else
                return GetSucessor(node.left);
        }

        private Node GetAntesseor(Node node)
        {
            Node aux = null;
            if (node.right is null)
                return node;
            else if (node.right.right is null)
            {
                aux = node.right;
                node.right = aux.left;
                return aux;
            }
            else
                return GetAntesseor(node.right);
        }

        public void SimpleRotation()
        {
            root = SimpleRotation(root);
        }

        private Node SimpleRotation(Node root)
        {
            Node right = root.right;

            root.right = right.left;
            root.right.parent = root;

            right.left = root;
            root.parent = right;

            return right;
        }

        public int Height()
        {
            return Height(root);
        }

        private int Height(Node node)
        {
            if (node.left is null && node.right is null)
                return -1;

            var h_left = node.left is not null ? GetHeight(node.left) : 0;
            var h_right = node.right is not null ? GetHeight(node.right) : 0;

            return h_left >= h_right ? h_left : h_right;
        }

        private int GetHeight(Node node)
        {
            var value1 = 0;
            var value2 = 0;
            if (node.left is not null)
            {
                value1 += GetHeight(node.left);
            }

            if (node.right is not null)
            {
                value2 += GetHeight(node.right);
            }

            if (value1 == value2)
                return 1;
            else if (value1 > value2)
                return value1 + 1;
            else
                return value2 + 1;
        }
    }
}
