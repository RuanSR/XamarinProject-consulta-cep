using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Newtonsoft.Json;

namespace ConsultaCep
{
    public static class ViaCep
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCep(string cep)
        {
            string novoEnderecoURL = string.Format(EnderecoURL, cep);
            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(novoEnderecoURL);
            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);
            if (end.cep == null) return null;
            return end;
        }
    }
}
