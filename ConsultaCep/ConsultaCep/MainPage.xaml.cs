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
            //TODO - Validações
            string cep = entryCep.Text.Trim();
            Endereco end = ViaCep.BuscarEnderecoViaCep(cep);

            lblResultado.Text = string.Format("Endereço: Rua {0} Bairro {1}, {2} {3}",end.logradouro,end.bairro, end.localidade, end.uf);
        }
	}
}
