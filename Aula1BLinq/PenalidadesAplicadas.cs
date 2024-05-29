using Newtonsoft.Json;


namespace Aula1BLinq
{
    
    public class PenalidadesAplicadas
    {
        [JsonProperty("razao_social")]
        public string RazaoSocial { get; set; }


        [JsonProperty("cnpj")]
        public string CNPJ { get; set; }


        [JsonProperty("nome_motorista")]
        public string NomeMotorista { get; set; }


        [JsonProperty("cpf")]
        public string CPF { get; set; }


        [JsonProperty("vigencia_do_cadastro")]
        public DateTime VigenciaCadastro { get; set; }

        public override string? ToString() => $"\nRazão Social: {RazaoSocial}\nCNPJ: {CNPJ}\nNome Motorista: {NomeMotorista}\nCPF: {CPF}\nVigência: {VigenciaCadastro}";
        
        
        
    }
}
