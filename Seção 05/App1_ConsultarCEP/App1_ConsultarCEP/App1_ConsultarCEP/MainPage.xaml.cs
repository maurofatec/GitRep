using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App1_ConsultarCEP.Servicos.Modelo;
using App1_ConsultarCEP.Servicos;

namespace App1_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Bt_BuscarCEP.Clicked += BuscarCEP;
        }

        private void BuscarCEP(Object sender, EventArgs args)
        {
            string cep = CEP.Text.Trim();
            
            if (IsValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCepServico.BuscarEnderecoViaCEP(cep);
                    if (end != null)
                    {
                        Resultado.Text = string.Format("Endereço: {1}, {2}, {0},{3}", end.Localidade, end.Logradouro, end.Bairro, end.Uf);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O endereço não foi encontrado para o CEP informado" + cep, "OK");
                    }
                }
                catch (Exception ex)
                {
                    DisplayAlert("ERRO CRÍTICO", ex.Message, "OK");
                }
            }
        }

        private Boolean IsValidCEP(string cep)
        {
            bool valid = true;
            if (!(cep.Length == 8))
            {
                valid = false;
                DisplayAlert("ERRO", "CEP inválido! O CEP deverá conter 8 caracteres.", "OK");
                
            }    
            if(!int.TryParse(cep, out int NovoCEP))
            {
                valid = false;
                DisplayAlert("ERRO", "CEP inválido! o CEP deverá conter somente números.", "OK");
            }
            return valid;
        }
    }
}
