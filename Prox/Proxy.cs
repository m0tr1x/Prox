namespace Prox;

public class Proxy<TKey, TValue>
{
    private Cache<TKey, TValue> cache = new Cache<TKey, TValue>();
    private Func<TKey, TValue> fetchData;

    public Proxy(Func<TKey, TValue> fetchData)
    {
        this.fetchData = fetchData;
    }

    /// <summary>
    /// Получаем данные из прокси
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public TValue Get(TKey key)
    {
        // Получаем данные из кэша
        TValue value = cache.Get(key);

        // Проверяем, есть ли данные в кэше
        if (value == null)
        {
            // Если данных нет в кэше, запрашиваем их у основного источника данных
            value = fetchData(key);
            // Добавляем полученные данные в кэш
            cache.Add(key, value);
            Console.WriteLine("Data via fetch \n");
            return value;
        }
        else
        {
            Console.WriteLine("Data from cache \n");
            return value;
        }
    }


    /// <summary>
    /// Удаление данных из кэша
    /// </summary>
    /// <param name="key"></param>
    public void Remove(TKey key)
    {
        cache.Remove(key);
    }
}