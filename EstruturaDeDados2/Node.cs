using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstruturaDeDados2
{
    public class Node
    {
        public Node() { }
        public Node(int value) => info = value;

        public int info;
        public Node left;
        public Node right;
        public Node parent;
    }
}
