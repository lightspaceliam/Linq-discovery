// See https://aka.ms/new-console-template for more information


using linq_discoveries.UseCases;

var deferred = new ExecutedAndDeferred();

var deferredPeople = deferred.GetPeopleDeferred();

var deferredOrderd = deferredPeople
    .OrderBy(p => p.FirstName);
    //.ToList();

foreach(var person in deferredOrderd)
{
    Console.WriteLine($"Deferred person {person.FirstName}");
}

var executed = new ExecutedAndDeferred();

var executedPeople = executed.GetPeopleExecuted();

var executedOrdered = executedPeople
    .OrderBy(p => p.FirstName)
    .ToList();
foreach(var person in executedOrdered)
{
    Console.WriteLine($"Executed person {person.FirstName}");
}

Console.WriteLine("LINQ Discoveries!");
Console.ReadKey();

