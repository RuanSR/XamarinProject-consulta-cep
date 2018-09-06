using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ConsultaCep
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            btnBuscar.Clicked += BuscarCep;
		}

        private void BuscarCep(object sender, EventArgs args)
        {
            try
            {
                string cep = entryCep.Text.Trim();
                if (isValidCep(cep))
                {
                    Endereco end = ViaCep.BuscarEnderecoViaCep(cep);
                    if (end != null)
                    {
                        lblResultado.Text = string.Format("Endereço: Rua {0} Bairro {1}, {2} {3}", end.logradouro, end.bairro, end.localidade, end.uf);
                    }
                    else
                    {
                        DisplayAlert("ERRO!", string.Format("ENDEREÇO DO CEP: {0} NÂO ENCONTRADO!",cep), "OK");
                    }
                }
                else
                {
                    DisplayAlert("ERRO!", "DIGITE UM CEP VÁLIDO!", "OK");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("ERRO!", "ERRO: "+ex.Message, "OK");
            }
        }

        private bool isValidCep(string cep)
        {
            int novoCep = 0;
            if (cep.Length == 8 && int.TryParse(cep, out novoCep))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
	}
}
