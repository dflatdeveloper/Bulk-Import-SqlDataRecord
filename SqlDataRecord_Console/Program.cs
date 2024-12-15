// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using SQLDataRecord_Lib;

Console.WriteLine("Hello, Bulk Insert!");

var serviceProvider = new ServiceCollection()
        .AddLogging()
        .AddBulkServices()
        .BuildServiceProvider();

var repo =serviceProvider
        .GetService<IADONetRepository>();


IList<ExampleDataObject> sample = [];

//add items to sample

repo?.BulkInsertPayload(sample);

Console.WriteLine("Goodbye, Bulk Insert!");