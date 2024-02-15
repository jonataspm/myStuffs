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
            var pathIn = @"C:\teste\In";

            var files = Directory.GetFiles(pathIn);
            if (files == null)
                return;

            foreach (var file in files)
            {
                if (file.Contains("ACMP640")) 
                {
                    var client = new FileInterpreter();
                    var processor = new FileProcessor(client);
                    processor.ProcessFile($"{file}");
                }
            }
        }
    }
}
