using System.IO;

namespace AT_DWNBD.Delegates
{
    public static class Logger
    {
        public static List<string> MemoryLogs = new List<string>();

        public static void LogToConsole(string message)
        {
            Console.WriteLine($"[Console Log] {DateTime.Now}: {message}");
        }

        public static void LogToFile(string message)
        {
            string logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "logs");
            Directory.CreateDirectory(logDirectory);

            string logFilePath = Path.Combine(logDirectory, "system_logs.txt");

            try
            {
                File.AppendAllText(logFilePath, $"[File Log] {DateTime.Now}: {message}{Environment.NewLine}");
                Console.WriteLine($"[Logger] Log salvo em arquivo: {logFilePath}"); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Logger Error] Falha ao salvar log em arquivo: {ex.Message}");
            }
        }

        public static void LogToMemory(string message)
        {
            MemoryLogs.Add($"[Memory Log] {DateTime.Now}: {message}");
            Console.WriteLine($"[Logger] Log salvo em memória. Total de logs em memória: {MemoryLogs.Count}");
        }
    }
}