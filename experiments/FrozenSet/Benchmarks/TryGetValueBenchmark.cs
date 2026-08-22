using System.Collections.Frozen;
using System.Collections.Immutable;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace FrozenSet.Benchmarks;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MarkdownExporter]
public class TryGetValueBenchmark
{
    private const int itemsCount = 100_000;
    private const int keyToFind = 500;

    private readonly Dictionary<int, int> _dictionary = Enumerable.Range(0, itemsCount).ToDictionary(key => key);

    private readonly HashSet<int> _hashSet = Enumerable.Range(0, itemsCount).ToHashSet();

    private readonly FrozenDictionary<int, int> _frozenDictionary =
        Enumerable.Range(0, itemsCount).ToFrozenDictionary(key => key);

    private readonly FrozenSet<int> _frozenSet = Enumerable.Range(0, itemsCount).ToFrozenSet();

    private readonly ImmutableDictionary<int, int> _immutableDictionary =
        Enumerable.Range(0, itemsCount).ToImmutableDictionary(key => key);

    private readonly ImmutableHashSet<int> _immutableHashSet = Enumerable.Range(0, itemsCount).ToImmutableHashSet();

    [Benchmark]
    public void TryGetValueDictionary()
    {
        _dictionary.TryGetValue(keyToFind, out _);
    }

    [Benchmark]
    public void TryGetValueImmutableDictionary()
    {
        _immutableDictionary.TryGetValue(keyToFind, out _);
    }

    [Benchmark]
    public void TryGetValueFrozenDictionary()
    {
        _frozenDictionary.TryGetValue(keyToFind, out _);
    }

    [Benchmark]
    public void TryGetValueHashSet()
    {
        _hashSet.TryGetValue(keyToFind, out _);
    }

    [Benchmark]
    public void TryGetValueImmutableHashSet()
    {
        _immutableHashSet.TryGetValue(keyToFind, out _);
    }

    [Benchmark]
    public void TryGetValueFrozenSet()
    {
        _frozenSet.TryGetValue(keyToFind, out _);
    }
}