using linq_discoveries.UseCases;

#region Unplanned Deferred Query Execution

Console.WriteLine("Unplanned deferred query execution:\n");

var deferredExecution = new QueryExecution();

var deferredCollection = deferredExecution.DeferredExecutionCollection();

foreach (var person in deferredCollection)
{
    Console.WriteLine($"Unplanned deferred people collection {person.FirstName}");
}

#endregion

#region Standard Query Execution

Console.WriteLine("\n\nStandard query execution:\n");
var immediateExecution = new QueryExecution();

var executedCollection = immediateExecution.ExecutedGetPeople();

foreach (var person in executedCollection)
{
    Console.WriteLine($"Executed person collection {person.FirstName}");
}
#endregion

#region Planned Deferred Query Execution

Console.WriteLine("\n\nPlanned deferred query execution:\n");

var plannedDeferredExecution = new QueryExecution();

var (totalPeople, strategicExecutedCollection) = plannedDeferredExecution.PlannedDeferredQueryExecution();

Console.WriteLine($"QTY: {totalPeople}, Multi qty: ${strategicExecutedCollection.Count}");

foreach (var person in strategicExecutedCollection)
{
    Console.WriteLine($"Strategically executed person collection {person.FirstName}");
}

#endregion

Console.WriteLine("LINQ Discoveries!");
Console.ReadKey();

