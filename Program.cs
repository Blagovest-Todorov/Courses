using System;
using System.Collections.Generic;
using System.Linq;

namespace Cources
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> studentsByCourse = new Dictionary<string, List<string>>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == "end")
                {
                    break;
                }

                string[] parts = line.Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string course = parts[0];
                string student = parts[1];

                if (!studentsByCourse.ContainsKey(course))
                {
                    studentsByCourse.Add(course, new List<string>());
                }

                studentsByCourse[course].Add(student);
            }

            Dictionary<string, List<string>> sorted = studentsByCourse
                .OrderByDescending(c => c.Value.Count)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in sorted)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value.Count}");

                kvp.Value.Sort(); // We sort the list kvp.Vaslue and change/records its content to sorted ascending ! 

                foreach (var student in kvp.Value ) // kvp.Value --is the List of students !!!
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
