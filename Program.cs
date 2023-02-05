Calculate c = new Calculate();
double result = 0;
List<string> operationsStringList = new List<string>(new string[] 
{"1+1",
 "2*2",
 "1 + 2 + 3",
 "6 / 2",
 "11 + 23",
 "11.1 + 23",
 "1 + 1 * 3",
 "( 11.5 + 15.4 ) + 10.1",
 "23 - ( 29.3 - 12.5 )",
 "(1 / 2 ) - 1 + 1"
 });

foreach(string ops in operationsStringList)
{
    Console.WriteLine("Start Calculate: "+ ops);
    result = c.CalculateString(ops);
    Console.WriteLine("Results:" + result.ToString());
}
