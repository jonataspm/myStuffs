using DesingPatternsApplieds.ReadManyFiles.Entities;
using DesingPatternsApplieds.ReadManyFiles.Intefaces;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;

namespace DesingPatternsApplieds.ReadManyFiles.Processors
{
    public class FileProcessor : FileManager
    {
        public FileProcessor(IInterpreter interpreter) : base(interpreter) { }

        protected override void ProcessLine(List<ILine> lines)
        {
            string pathOut = @"C:\teste\Out";

            string json = JsonConvert.SerializeObject(lines);
            string filePathOut = Path.Combine(pathOut, "test.json");
            File.WriteAllText(filePathOut, json);
        }
    }
}
