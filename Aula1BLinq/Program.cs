using Aula1BLinq;

var lst = ReadFile.GetData("C:\\Users\\João Mazzoni\\Desktop\\motoristas_habilitados.json");


Console.WriteLine("Quantidade de Linhas: " + TestFilters.getCountRecords(lst));


Console.WriteLine("Listar Registros que tenham o número do documento (CPF) iniciando com 237");
List<PenalidadesAplicadas> numCPF = TestFilters.FilterCPF(lst);
TestFilters.printData(numCPF);
Console.ReadLine();
Console.Clear();

Console.WriteLine("Listar Registros que tenham o ano de vigência igual 2021");
List<PenalidadesAplicadas> ano = TestFilters.FilterVigencia(lst);
TestFilters.printData(ano);
Console.ReadLine();
Console.Clear();

Console.WriteLine("Quantas empresa tem no nome da razão social a descrição LTDA");
List<PenalidadesAplicadas> razaoLTDA = TestFilters.FilterLTDA(lst);
TestFilters.printData(razaoLTDA);
Console.ReadLine();
Console.Clear();

Console.WriteLine("Ordenar a lista de registros pela razão social");
List<PenalidadesAplicadas> orderRazao = TestFilters.OrderByRazao(lst);
TestFilters.printData(orderRazao);
Console.ReadLine();
Console.Clear();

//Inserir Dados no Banco - Feito
Console.WriteLine("Inserir todos os registros no SQLServer");
TestFilters.InsertDB(lst);

Console.WriteLine("Gerar Arquivo XML");
Console.WriteLine(TestFilters.GenerateXML(lst));
Console.ReadLine();
Console.Clear();

Console.WriteLine("Transferindo Dados do SQL para o Mongo");
Mongo.TransferirDadosParaMongo();

Console.WriteLine("Gerando Informações na Tabela MetaDado");
Mongo.TransferirMetaDadoSQL();
