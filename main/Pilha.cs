using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main
{
	public class Pilha
	{
		// Pilha é 
        static int cap = 50;
		int[] vector = new int[cap];
		int topo = -1;

        void push(int elemenet)
		{
            vector[++topo] = topo < cap ? elemenet : throw new Exception();

		}
		void pop()
		{
			topo--;
		}
	}
}
