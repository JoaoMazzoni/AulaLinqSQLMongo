using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula1Linq
{
    public class Adm
    {

        public static List<Person> loadData()
        {
            var people = new List<Person>();
            people.Add(new Person() { Id = 1, Name = "João Mazzoni", Age = 19, Telephone = "16 992663385" });
            people.Add(new Person() { Id = 1, Name = "Maria", Age = 18, Telephone = "16 992663385" });
            people.Add(new Person() { Id = 1, Name = "Ana", Age = 12, Telephone = "16 992663385" });
            people.Add(new Person() { Id = 1, Name = "Vitória", Age = 30, Telephone = "16 992663385" });
            people.Add(new Person() { Id = 1, Name = "Juliana", Age = 15, Telephone = "16 992663385" });
            people.Add(new Person() { Id = 1, Name = "Maiara", Age = 20, Telephone = "16 992663385" });
            return people;
        }

        public static void printData(List<Person> people)
        {
            foreach(var p in people)
            {
                Console.WriteLine(p);
            }
        }

        public static List<Person> FilterByAgeUseLinq(List<Person> people) => people.Where(p => p.Age >= 18).ToList();
        


        public static void printOlderThan18(List<Person> people)
        {
            foreach (var p in people)
            {
                if(p.Age >= 18)
                {
                    Console.WriteLine(p);
                }
            }
        }

        public static List<Person> FilterByNameStartsA (List<Person> people) => people.Where (p => p.Name.StartsWith("A", StringComparison.OrdinalIgnoreCase)).ToList();
   
        public static List<Person> OrderByName (List<Person> people) => people.OrderBy(p => p.Name).ToList();

        public static List<Person> FilterByNumCaracterA(List<Person> people) => people.Where(p => p.Name.Contains("A", StringComparison.OrdinalIgnoreCase) && p.Name.Length > 3).ToList();
    
    }
}
