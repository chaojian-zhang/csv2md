using System.Text;

namespace csv2md
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2) 
            {
                Console.WriteLine("""
                    csv2md <Input File> <Output File>
                    """);
                return;
            }

            string input = args[0];
            string output = args[1];
            if (!File.Exists(input))
            {
                Console.WriteLine($"File {input} doesn't exist.");
                return;
            }

            StringBuilder md = new StringBuilder();
            foreach(var line in Csv.CsvReader.ReadFromText(File.ReadAllText(input), new Csv.CsvOptions()
            {
                HeaderMode = Csv.HeaderMode.HeaderAbsent
            }))
            {
                md.AppendLine("| " + string.Join(" | ", line) + " |");
            }
            File.WriteAllText(output, md.ToString());
        }
    }
}