using System.Collections.Frozen;
using System.Collections.Immutable;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace FrozenSet.Benchmarks;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MarkdownExporter]
public class LookupBenchmark
{
    private const int itemsCount = 100_000;
    private const int iterations = 1_000;

    private readonly Dictionary<int, int> _dictionary = Enumerable.Range(0, itemsCount).ToDictionary(key => key);

    private readonly FrozenDictionary<int, int> _frozenDictionary =
        Enumerable.Range(0, itemsCount).ToFrozenDictionary(key => key);

    private readonly FrozenSet<int> _frozenSet = Enumerable.Range(0, itemsCount).ToFrozenSet();

    private readonly HashSet<int> _hashSet = Enumerable.Range(0, itemsCount).ToHashSet();

    private readonly ImmutableDictionary<int, int> _immutableDictionary =
        Enumerable.Range(0, itemsCount).ToImmutableDictionary(key => key);

    private readonly ImmutableHashSet<int> _immutableHashSet = Enumerable.Range(0, itemsCount).ToImmutableHashSet();
    private readonly ImmutableList<int> _immutableList = Enumerable.Range(0, itemsCount).ToImmutableList();

    private readonly List<int> _list = Enumerable.Range(0, itemsCount).ToList();

    [Benchmark]
    public void LookupDictionary()
    {
        for (var i = 0; i < iterations; i++)
            _ = _dictionary.ContainsKey(i);
    }

    [Benchmark]
    public void LookupImmutableDictionary()
    {
        for (var i = 0; i < iterations; i++)
            _ = _immutableDictionary.ContainsKey(i);
    }

    [Benchmark]
    public void LookupFrozenDictionary()
    {
        for (var i = 0; i < iterations; i++)
            _ = _frozenDictionary.ContainsKey(i);
    }

    [Benchmark]
    public void LookupList()
    {
        for (var i = 0; i < iterations; i++)
            _ = _list.Contains(i);
    }

    [Benchmark]
    public void LookupImmutableList()
    {
        for (var i = 0; i < iterations; i++)
            _ = _immutableList.Contains(i);
    }

    [Benchmark]
    public void LookupHashSet()
    {
        for (var i = 0; i < iterations; i++)
            _ = _hashSet.Contains(i);
    }

    [Benchmark]
    public void LookupImmutableHashSet()
    {
        for (var i = 0; i < iterations; i++)
            _ = _immutableHashSet.Contains(i);
    }

    [Benchmark]
    public void LookupFrozenSet()
    {
        for (var i = 0; i < iterations; i++)
            _ = _frozenSet.Contains(i);
    }
}