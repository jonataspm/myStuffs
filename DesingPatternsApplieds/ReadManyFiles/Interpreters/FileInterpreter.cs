using DesingPatternsApplieds.ReadManyFiles.FilesTypes.ACMP640;
using DesingPatternsApplieds.ReadManyFiles.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPatternsApplieds.ReadManyFiles.Interpreters
{
    public class FileInterpreter : IInterpreter
    {
        private readonly Dictionary<char, ILine> lineInterpreterMap;

        public FileInterpreter()
        {
            lineInterpreterMap = new Dictionary<char, ILine>
            {
                { '0', new Header() }
            };
        }

        public ILine Parse(string data)
        {
            var line = lineInterpreterMap[data[0]];
            line.Process(data);
            return line;
        }
    }
}
