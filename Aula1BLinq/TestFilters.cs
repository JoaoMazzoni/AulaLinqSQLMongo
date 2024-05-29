

using System.ComponentModel;
using System.Xml.Linq;

namespace Aula1BLinq
{
    public class TestFilters
    {
        public static void printData(List<PenalidadesAplicadas> penalidades)
        {
            foreach (var p in penalidades)
            {
                Console.WriteLine(p);
            }
        }
        public static int getCountRecords(List<PenalidadesAplicadas> lista) => lista.Count;

        public static List<PenalidadesAplicadas> FilterCPF(List<PenalidadesAplicadas> lista) => lista.Where(l => l.CPF.StartsWith("237")).ToList();
        
        public static List<PenalidadesAplicadas> FilterVigencia(List<PenalidadesAplicadas> lista) => lista.Where(l => l.VigenciaCadastro.Year == 2021).ToList();

        public static List<PenalidadesAplicadas> FilterLTDA(List<PenalidadesAplicadas> lista) => lista.Where(l => l.RazaoSocial.Contains("LTDA")).ToList();
    
        public static List<PenalidadesAplicadas> OrderByRazao(List<PenalidadesAplicadas> lista) => lista.OrderBy(l => l.RazaoSocial).ToList();
   
        public  static void InsertDB (List<PenalidadesAplicadas> lista)
        {
            foreach (var item in lista)
            {
                Banco.InserirNoBanco(item);
            }
        }
        
        public static string GenerateXML(List<PenalidadesAplicadas> lista)
        {
            if(lista.Count > 0)
            {
                var penalidadeAplicada = new XElement("Root", from data in lista
                select new XElement("motorista", new XElement("razao_social", data.RazaoSocial),
                new XElement("CNPJ", data.CNPJ), new XElement("nome_motorista", data.NomeMotorista),
                new XElement("cpf", data.CPF), new XElement("vigencia_do_cadastro", data.VigenciaCadastro)));


                return penalidadeAplicada.ToString();
            }
            else
            {
                return "Não existem registros";
            }
        }

    } 
}
