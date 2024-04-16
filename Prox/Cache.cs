using System;
using System.Collections.Generic;

namespace Prox;

/// <summary>
/// Класс для хранения кэша
/// </summary>
/// <typeparam name="TKey"></typeparam>
/// <typeparam name="TValue"></typeparam>
public class Cache<TKey, TValue>
{
    //Сам кэш
    private Dictionary<TKey, TValue> cache = new();
    
    
    /// <summary>
    /// Метод для добавления элемента в кеш
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    public void Add(TKey key, TValue value)
    {
        if (!cache.ContainsKey(key))
        {
            cache.Add(key, value);
        }
    }

    /// <summary>
    /// Получаем данные из кэша
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public TValue Get(TKey key)
    {
        return cache.ContainsKey(key) ? cache[key] : default(TValue);
    }

    /// <summary>
    ///  Удаляем данные из кэша
    /// </summary>
    /// <param name="key"></param>
    public void Remove(TKey key)
    {
        if (cache.ContainsKey(key))
        {
            cache.Remove(key);
        }
    }

}