using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp46
{
    internal static class ExceptionHandling
    {
        // Метод для обработки исключения
        public static void HandleException(Exception ex) //добавлен static
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
}
