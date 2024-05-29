

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;


namespace Aula1BLinq
{
    public class ReadFile
    {

        public static List<PenalidadesAplicadas> GetData(string path)
        {
            StreamReader r = new StreamReader(path);
            string jsonString = r.ReadToEnd();
            var objetoGeral = JsonConvert.DeserializeObject<MotoristaHabilitado>(jsonString, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
            
            if(objetoGeral != null) return objetoGeral.PenalidadesAplicadas;
            return null;
        }
    }
}
