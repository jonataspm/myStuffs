using DesingPatternsApplieds.ReadManyFiles.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesingPatternsApplieds.ReadManyFiles.FilesTypes.ACMP640
{
    public class DataType1 : ILine
    {
        public void Process(string data)
        {
            this.Title = data.Substring(0, 1);
            this.Description = data.Substring(2, 10);
        }

        public string Title { get; set; }
        public string Description { get; set; }

    }
}
