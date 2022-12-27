using System.Diagnostics;
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

# region Singular

var sw1 = new Stopwatch();
var sw2 = new Stopwatch();
var x = new SingularFirstOrDefault();

x.Mock(1000000);

sw1.Start();
var personEntry = x.GetPersonWithOneOrManyAddresses();
sw1.Stop();
var ts1 = sw1.Elapsed;
var elapsedTime1 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts1.Hours, ts1.Minutes, ts1.Seconds,
            ts1.Milliseconds / 10);

Console.WriteLine($"1 Elapsed: {elapsedTime1}");

sw2.Start();
var opt = x.OptimisedGetPersonWithOneOrManyAddresses();
sw2.Stop();
var ts2 = sw2.Elapsed;
var elapsedTime2 = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts2.Hours, ts2.Minutes, ts2.Seconds,
            ts2.Milliseconds / 10);

Console.WriteLine($"2 Elapsed: {elapsedTime2}");

#endregion

Console.WriteLine("LINQ Discoveries!");
Console.ReadKey();

