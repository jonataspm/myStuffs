using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ED23._2
{
    public class Vertice
    {
        public double Info;
        public List<Vertice> Adjacentes = new List<Vertice>();

        public Vertice()
        {
        }

        public Vertice(double i)
        {
            Info = i;
        }
    }
}
