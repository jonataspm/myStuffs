using DesingPatternsApplieds.ReadManyFiles.Intefaces;

namespace DesingPatternsApplieds.ReadManyFiles.Processors
{
    public abstract class FileManager
    {
        private IInterpreter _interpreter;
        protected FileManager(IInterpreter interpreter) => _interpreter = interpreter;

        public void ProcessFile(string filePath)
        {
            var streamReader = new StreamReader(filePath);
            var line = streamReader.ReadLine(); 
            
            _interpreter.Parse(line);
        }
        public abstract void ProcessLine();
    }
}
