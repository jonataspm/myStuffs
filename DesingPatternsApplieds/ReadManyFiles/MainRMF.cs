using DesingPatternsApplieds.ReadManyFiles.Interpreters;
using DesingPatternsApplieds.ReadManyFiles.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPatternsApplieds.ReadManyFiles
{
    public class MainRMF
    {
        public void Start()
        {
            var client = new FileInterpreter();
            var processor = new FileProcessor(client);
            processor.ProcessFile("C//teste");

        }
    }
}
