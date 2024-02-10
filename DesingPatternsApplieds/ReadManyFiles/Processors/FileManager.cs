using DesingPatternsApplieds.ReadManyFiles.Intefaces;

namespace DesingPatternsApplieds.ReadManyFiles.Processors
{
    public abstract class FileManager
    {
        private IInterpreter _interpreter;
        protected FileManager(IInterpreter interpreter) => _interpreter = interpreter;

        public void ProcessFile(string filePath)
        {
           var file = File.OpenRead(filePath);
            
            if (file == null)
                throw new Exception("Arquivo Vazio");

            StreamReader reader = new StreamReader(filePath);
            
            string? line;
            List<ILine> list = new List<ILine>();
            while ((line = reader.ReadLine()) != null)
            {
                list.Add(_interpreter.Parse(line));
            }

            ProcessLine(list);
        }
        protected abstract void ProcessLine(List<ILine> line);
    }
}
