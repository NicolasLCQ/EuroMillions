using System.Collections;

namespace EuroMillions.Application.Models;

public abstract class DrawItemDictionnary<TItem> : IReadOnlyDictionary<TItem, int>
    where TItem : notnull
{
    protected DrawItemDictionnary(IEnumerable<TItem> items)
    {
        Items = items.ToDictionary(item => item, _ => 0);
    }

    internal Dictionary<TItem, int> Items { get; }

    public int this[TItem key] => Items[key];

    public IEnumerable<TItem> Keys => Items.Keys;

    public IEnumerable<int> Values => Items.Values;

    public int Count => Items.Count;

    public bool ContainsKey(TItem key) => Items.ContainsKey(key);

    public bool TryGetValue(TItem key, out int value) => Items.TryGetValue(key, out value);

    public IEnumerator<KeyValuePair<TItem, int>> GetEnumerator() => Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
