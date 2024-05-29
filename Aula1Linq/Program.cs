using Aula1Linq;

Console.WriteLine("Inicio do Processamento");

var people = Adm.loadData(); 
Adm.printData(people);

Console.WriteLine("\n\nListar Maiores de 18 anos: ");
Adm.printOlderThan18(people);

Console.WriteLine("\n\nListar Nomes que Começam com a Letra A");
List<Person> auxA = Adm.FilterByNameStartsA(people);
Adm.printData(auxA);

Console.WriteLine("\n\nListar Pessoas Ordenadas por Nome");
List<Person> orderName = Adm.OrderByName(people);
Adm.printData(orderName);

Console.WriteLine("\n\nListar Nomes com a Letra A e mais de 3 caracteres");
List<Person> name3A = Adm.FilterByNumCaracterA(people);
Adm.printData(name3A);

