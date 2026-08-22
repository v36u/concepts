# FrozenSet experiments

FrozenSet provides an immutable, read-only set optimized for fast lookup and enumeration.

It is optimized for situations where a set is created infrequently but is used frequently at run time.

It has a relatively high cost to create but provides excellent lookup performance. Thus, it is ideal for cases where a set is created once, potentially at the startup of an application, and is used throughout the remainder of the life of the application.

## What does it mean to be frozen?

Unlike `ReadOnlyList`, which is just a view of the object it was created from, `FrozenSet`s are immutable by their nature because when they are created, some one-time optimizations are performed for the most efficient possible future lookups. This requires some internal setup first which makes them expensive to create, but worth it for extensive reading from them.

Some of these optimizations include:

1. **Length-based hashing**: Hashing is based on string length when appropriate.
2. **Key Analysis on Construction**: During construction, keys are analyzed to determine if a substring provides sufficient variance. For instance, keys like `Item1`, `Item2` ... `Item7` are hashed only on the last character, speeding up the process compared to hashing the entire string.
3. **Deterministic Hashing**: Faster hashing methods are used where determinism is safe.
4. **ASCII Optimizations**: For case-insensitive keys, faster ASCII-based hashing is sometimes used.
5. **Safe Case Sensitivity**: In some cases, even a case-insensitive dictionary can use case-sensitive comparisons if deemed safe. For example, a case-insensitive dictionary with keys `["678", "139", ..., "801"]` can safely use case-sensitive hashing.

## What are the differences from Immutable collections?

The main difference comes from the fact that Immutable collections are designed for being updated by creating new versions, whereas `FrozenSet`s (or frozen collections in general) are optimized for maximum read performance after being created once.

## References

1. ["Frozen collections in .NET 8" by Steven Giesel](https://steven-giesel.com/blogPost/34e0fd95-0b3f-40f2-ba2a-36d1d4eb5601)
2. ["Readonly, Immutable, and Frozen Collections in .NET" by NDepend](https://blog.ndepend.com/readonly-immutable-and-frozen-collections-in-net/)
3. ["Exploring Frozen Collections in .NET 8 With Benchmarking" by
Jitendra Mesavaniya](https://www.c-sharpcorner.com/article/exploring-frozen-collections-in-net-8-with-benchmarking/)
