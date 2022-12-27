# Singular Querying

Whilst performing comparisons between: 

1. `collection.FirstOrDefault( predicate )`
2. `collection.FirstOrDefault()`
3. `collection.Where( predicate ).FirstOrdefault()` 

I discovered .FirstOrDefault( predicate ) was slower, even without a predicate. Using the stopwatch and 1,000,000 records, `.FirstOrDefault()` was up to 8 milliseconds slower.