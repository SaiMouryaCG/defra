using Microsoft.Extensions.Configuration;
using System;
using System.IO;
class Program
{
   static void Main(string[] args)
   {
       var config = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory()) // Load settings.json from output directory
           .AddJsonFile("settings.json", optional: false, reloadOnChange: true)
           .Build();
       var input1 = config.GetValue<int>("CalculatorSettings:Input1");
       var input2 = config.GetValue<int>("CalculatorSettings:Input2");
       Console.WriteLine($"Inputs: {input1}, {input2}");
       Console.WriteLine($"Add: {input1 + input2}");
       Console.WriteLine($"Subtract: {input1 - input2}");
       Console.WriteLine($"Multiply: {input1 * input2}");
       Console.WriteLine($"Divide: {(input2 != 0 ? input1 / input2 : 0)}");
       var csvPath = config.GetValue<string>("CsvReaderSettings:CsvSettings:FilePath");
       var conn = config.GetValue<string>("SqlSettings:ConnectionString");
       Console.WriteLine($"CSV File Path (Relative): {csvPath}");
	   Console.WriteLine($"CSV File Path (Full): {Path.GetFullPath(csvPath)}");
	   if (File.Exists(csvPath))
	   {
		   var lines= File.ReadAllLines(csvPath);
		   Console.WriteLine($"CSV Record Count:{lines.Length}");
		   
		   foreach ( var line in lines)
		   {
			   Console.WriteLine($"Row: {line}");
		   }
	   }
	   else
	   {
		   Console.WriteLine("Csv file not found");
	   }
       Console.WriteLine($"SQL Connection: {conn}");
   }
}