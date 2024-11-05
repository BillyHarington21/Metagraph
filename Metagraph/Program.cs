
using Metagraph.Models;
using Metagraph.Services;

class Program
{
    static void Main(string[] args)
    {
        
        string inputFilePath = "C:\\Users\\Константин\\Desktop\\Метаграф тестовое\\Metagraph\\Metagraph\\input.txt"; 
        string outputFilePath = "C:\\Users\\Константин\\Desktop\\Метаграф тестовое\\Metagraph\\Metagraph\\output.txt"; 

        try
        {
            // Чтение данных и построение графа
            var parser = new GraphParser(inputFilePath);
            Graph graph = parser.Parse();

            // Задаём количество узлов и рёбер для агент-функции
            int nodeCount = graph.Nodes.Count;
            int edgeCount = graph.Edges.Count;

            // Загружаем правила агент-функции
            List<string> rules = LoadRules(inputFilePath);

            // Применяем агент-функции для вычисления атрибутов
            var calculator = new AgentFunctionService(graph);
            calculator.Rules(rules, nodeCount);

            // Записываем результаты в файл
            var writer = new FileWriter(graph);
            writer.WriteAttributesToFile(outputFilePath);

            Console.WriteLine("Атрибуты успешно вычислены и записаны в файл.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }

    // Метод для загрузки правил из файла 
    static List<string> LoadRules(string filePath)
    {
        var rules = new List<string>();
        var lines = File.ReadAllLines(filePath);

        int emptyLineCount = 0; 

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                emptyLineCount++;
                continue;
            }

            if (emptyLineCount >= 2)
            {
                rules.Add(line);
            }
        }
        return rules;
    }
}
