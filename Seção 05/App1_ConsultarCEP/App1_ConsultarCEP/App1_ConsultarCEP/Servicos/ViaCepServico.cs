using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App1_ConsultarCEP.Servicos.Modelo;
using Newtonsoft.Json;

namespace App1_ConsultarCEP.Servicos
{
    public class ViaCepServico
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo) ;

            if (end.Cep == null) return null;

            return end;

        }
    }
}
