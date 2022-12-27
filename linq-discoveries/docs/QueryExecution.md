# Query Execution

Whilst  `IEnumarable` and `IQueryable` are not the same and provide different features, what they both have in common is deferred execution.

Microsoft docs quote: *"LINQ queries are always executed when the query variable is iterated over, not when the query variable is created. This is called deferred execution. You can also force a query to execute immediately, which is useful for caching query results."*

Because of this, it is importand to understand the difference between `deferred` and `immediate` query execution strategies.

### Deferred

Varaibles of type: `IQueryable` or `IEnumarable` support deferred execution. 

1. If we do not intend to take advantage of this or other features provided by these types, it is recommended to immediatly execute queries to prevent unwanted or unplanned side effects
2. If we plan on performing other query operations on the results, we will cause multiple executions. Whilst the record count is low for this example, in real life examples, concurrent utilization and data growth can cause this query strategy to become a performance bottle neck. 


The bellow functions provide examples to demonstrate planned and unplanned query re-execution.  

```c#
//  Deferred query execution however we are not taking advantage of the deferred execution.
public IEnumerable<Person> UnplannedDeferredQueryExecution() 
{ ... }

//  Deferred query execution, query reuse, query composition and query termination.
public (int quantity, List<Person>) PlannedDeferredQueryExecution(bool mustHaveAddress = false) 
{ ... }

//  Initial query is executed and results are further queried without unplanned further duplicate query execution.
public List<Person> GetPeopleExecuted()
{ ... }
```

[Deferred query execution](https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/ef/language-reference/query-execution#deferred-query-execution)

### Immediate 

Any query that is executed with a ToList, ToArray or similar.

| Pro | Con |
| --- | --- |
| Simple and easy to understand | Static, defined once and cannot be further composed |
| The query is executed immediatly and results can be used in other queries or iterations without unexpected executions against the defined query |  |

[Immediate Query Execution](https://learn.microsoft.com/en-us/dotnet/framework/data/adonet/ef/language-reference/query-execution#immediate-query-execution)