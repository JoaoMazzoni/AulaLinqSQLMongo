using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula1Linq
{
    public class Person
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public string Telephone { get; set; }
        public int Age { get; set; }

        public override string? ToString() => $"ID: {Id}\nNome: {Name}\nIdade: {Age}\nTelefone: {Telephone}";
    
    }



}
