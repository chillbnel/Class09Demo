using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Class09Demo.Classes;
using Newtonsoft;
using Newtonsoft.Json;

namespace Class09Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //LinqExample();
            LamdaExpressions();
        }

        static void LinqExample()
        {
            Console.WriteLine("=========== Numbers in List ================");
            List<int> myNumbers = new List<int>() { 4, 8, 15, 16, 23, 42, 54, 67, 89, 111 };

            foreach (int item in myNumbers)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("=========== Numbers That Are Even ================");
            IEnumerable<int> answer = from result in myNumbers
                         where result % 2 == 0
                         select result;

            foreach (int item in answer)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("=========== Numbers Less Than 20 and Even ================");
            IEnumerable<int> lessThan20 = from result in answer
                                          where result < 20
                                          select result;

            foreach (int item in lessThan20)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("============= Sort in Descending Order ==============");
            List<int> newNumbers = new List<int> { 1, 1, 1, 31, 1, 211, 2, 2, 2, 3, 4, 55, 5, 6, 6, 86, 6 };

            var sortDesc = from results in newNumbers
                           orderby results descending
                           select results;

            foreach (int item in newNumbers)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("============= Distinct Numbers (Option 1) ==============");
            var groupping = from num in newNumbers
                            group num by num;

            foreach (var item in groupping)
            {
                Console.WriteLine(item.Key);
            }

            Console.WriteLine("============= Distinct Numbers (Option 2) ==============");
            var getDistinct = (from number in newNumbers
                               select number).Distinct();

            foreach (var item in getDistinct)
            {
                Console.WriteLine(item);
            }


        }

        static void LamdaExpressions()
        {
            List<int> myNumbers = new List<int>() { 2, 2, 4, 8, 15, 16, 23, 42, 54, 54, 67, 89, 111 };

            Console.WriteLine("=========== Lambda Even ====================");
            var answer = myNumbers.Where(x => x % 2 == 0);

            foreach (var item in answer)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("=========== Lambda Less Than 20 ====================");
            var lessthan20 = answer.Where(x => x < 20);

            foreach (var item in lessthan20)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("=========== Lambda Unique ====================");
            var uniqueValues = myNumbers.Select(numbers => numbers)
                                        .Distinct() //makes distinct
                                        .Where(x => x % 2 == 0); //chained to filters out odd numbers

            foreach (var item in uniqueValues)
            {
                Console.WriteLine(item);
            }
        }

        static void JsonConversion()//Make sure to download a NuGet; tools -> NuGet -> Manage -> Browse -> Newtonsoft.json... add "using Newtonsoft;"
        {
            string path = "../../brooklyn_blocks.json";
            string text = "";
            using (StreamReader sr = File.OpenText(path))
            {
                text = sr.ReadToEnd();
            }

            IEnumerable<Blocks> brooklynBlock = JsonConvert.DeserializeObject<List<Blocks>>(text);

            //var someBlock = brooklynBlock.Where( x => x.Name == "Little Italy"), note .Name is just a property in the Block class

            //de-serialize JSON file, https://www.newtonsoft.com/json/help/html/SerializingJSON.html
        }
    }
}
