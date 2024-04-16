namespace Prox;

class Program
{
    static void Main(string[] args)
    {
        // Пример использования
        // Создаем функцию для получения данных
        Func<string, string> fetchData = (key) =>
        {
            Console.WriteLine($"Fetching data for key '{key}' from the main source.");
            return $"Data for key '{key}'";
        };

        // Создаем прокси
        Proxy<string, string> proxy = new Proxy<string, string>(fetchData);

        // Получаем данные через прокси, если они есть
        Console.WriteLine(proxy.Get("key1")); // Данных нет в кэше, будут запрошены из основного источника
        Console.WriteLine(proxy.Get("key1")); // Данные уже есть в кэше, будут получены из кэша

        // Удаляем данные из кэша
        proxy.Remove("key1");

        // Повторный запрос после удаления из кэша
        Console.WriteLine(proxy.Get("key1")); // Данных нет в кэше, будут запрошены из основного источника
    }
}