using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zFaculdade.Pilhas
{
    public class Pilha
    {
        private static int capacidade = 5;
        private int[] array = new int[capacidade];
        private int local = -1;

        public void Push(int valor)
        {
            if (Size() < capacidade)
                array[++local] = valor;
        }
        public int Pop()
        {

            if (!IsEmpety())
                return array[local--];
            else
                return 0;

        }
        public int Size() => local + 1;
        public int GetLocal() => local;
        public int Capacity() => capacidade;
        public int Top() => local >= 0 ? array[local] : -1;
        public bool IsEmpety() => local < 0;
        public bool IsFull() => local == capacidade;
    }
}