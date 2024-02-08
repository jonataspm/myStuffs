using DesingPatternsApplieds.ReadManyFiles.Entities;
using DesingPatternsApplieds.ReadManyFiles.Intefaces;

namespace DesingPatternsApplieds.ReadManyFiles.Processors
{
    public class FileProcessor : FileManager
    {
        public FileProcessor(IInterpreter interpreter) : base(interpreter) { }
        public override void ProcessLine() 
        {
            
        }
    }
}
