// See https://aka.ms/new-console-template for more information
using TopArticles.Business;

//TODO: Tratar erro de conversão de número em todos os ReadLine

Console.WriteLine("Enter article limit");
int limit = int.Parse(Console.ReadLine());

Console.WriteLine();
Console.WriteLine("Calculating the result");
Console.WriteLine();

List<string> articlesName = await new ArticleBusiness().TopArticles(limit);

Console.WriteLine($"Result = [ {string.Join(" / ", articlesName)} ]");