using System.Collections;

namespace EuroMillions.Application.Models;

public abstract class DrawItemDictionnary<TItem, TValue> : IReadOnlyDictionary<TItem, TValue>
    where TItem : notnull
{
    protected DrawItemDictionnary(IEnumerable<TItem> items, Func<TItem, TValue> valueFactory)
    {
        Items = items.ToDictionary(item => item, valueFactory);
    }

    internal Dictionary<TItem, TValue> Items { get; }

    public TValue this[TItem key] => Items[key];

    public IEnumerable<TItem> Keys => Items.Keys;

    public IEnumerable<TValue> Values => Items.Values;

    public int Count => Items.Count;

    public bool ContainsKey(TItem key) => Items.ContainsKey(key);

    public bool TryGetValue(TItem key, out TValue value) => Items.TryGetValue(key, out value!);

    public IEnumerator<KeyValuePair<TItem, TValue>> GetEnumerator() => Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
