using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPatternsApplieds.ReadManyFiles.Intefaces
{
    public interface ILine
    {
        public abstract void Process(string data);
    }
}
