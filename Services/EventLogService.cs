using System;

namespace AT_DWNBD.Services
{
    public static class EventLogService
    {
        public static void LogCapacityAlert(string packageName, int currentParticipants, int maxCapacity)
        {
            Console.WriteLine($"\n--- [ALERTA DE CAPACIDADE] ---");
            Console.WriteLine($"Pacote: '{packageName}'");
            Console.WriteLine($"Status: Capacidade máxima ATINGIDA ou EXCEDIDA!");
            Console.WriteLine($"Detalhes: Participantes Atuais: {currentParticipants} / Capacidade Máxima: {maxCapacity}");
            Console.WriteLine($"--------------------------------\n");
        }
    }
}