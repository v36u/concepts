using System.Collections.Frozen;
using System.Collections.Immutable;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace FrozenSet.Benchmarks;

[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[MarkdownExporter]
public class CreateBenchmark
{
    private const int itemsCount = 10_000;

    [Benchmark]
    public void CreateDictionary()
    {
        var dictionary = Enumerable.Range(0, itemsCount).ToDictionary(key => key);
    }

    [Benchmark]
    public void CreateImmutableDictionary()
    {
        var dictionary = Enumerable.Range(0, itemsCount).ToImmutableDictionary(key => key);
    }

    [Benchmark]
    public void CreateFrozenDictionary()
    {
        var frozenDictionary = Enumerable.Range(0, itemsCount).ToFrozenDictionary(key => key);
    }

    [Benchmark]
    public void CreateList()
    {
        var list = Enumerable.Range(0, itemsCount).ToList();
    }

    [Benchmark]
    public void CreateImmutableList()
    {
        var list = Enumerable.Range(0, itemsCount).ToImmutableList();
    }

    [Benchmark]
    public void CreateHashSet()
    {
        var hashSet = Enumerable.Range(0, itemsCount).ToHashSet();
    }

    [Benchmark]
    public void CreateImmutableHashSet()
    {
        var hashSet = Enumerable.Range(0, itemsCount).ToImmutableHashSet();
    }

    [Benchmark]
    public void CreateFrozenSet()
    {
        var frozenSet = Enumerable.Range(0, itemsCount).ToFrozenSet();
    }
}