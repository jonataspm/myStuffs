﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPatternsApplieds.ReadManyFiles.Intefaces
{
    public interface IInterpreter
    {
        abstract ILine Parse(string data);
    }
}
