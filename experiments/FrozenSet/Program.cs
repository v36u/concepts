using System.Collections.Frozen;
using System.Collections.Immutable;
using BenchmarkDotNet.Running;
using FrozenSet.Benchmarks;

// Baseline
var normalList = new List<int> { 1, 2, 3 };

// A view of the object it was created from. So if the original list is updated, this one will also reflect that change.
// Whoever is using this view has no means of mutating the internal state of the list itself.
var readOnlyList = normalList.AsReadOnly();

var frozenSet = normalList.ToFrozenSet();
var immutableList = normalList.ToImmutableList();

normalList.Add(4);

Console.WriteLine($"List count: {normalList.Count}");
Console.WriteLine($"ReadOnlyList count: {readOnlyList.Count}");
Console.WriteLine($"FrozenSet count: {frozenSet.Count}");
Console.WriteLine($"ImmutableList count: {immutableList.Count}");

Console.WriteLine();
Console.WriteLine();
Console.WriteLine();

BenchmarkRunner.Run<CreateBenchmark>();

Console.WriteLine();
Console.WriteLine();
Console.WriteLine();

BenchmarkRunner.Run<TryGetValueBenchmark>();

Console.WriteLine();
Console.WriteLine();
Console.WriteLine();

BenchmarkRunner.Run<LookupBenchmark>();