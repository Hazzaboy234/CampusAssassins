using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CampusAssassins
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CodeEntry : ContentPage
    {
        public CodeEntry()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (EntryPassword.Text == "12345")
            {
                await Navigation.PushAsync(new Lobby());
            }
            else
            {
                await DisplayAlert("Error", "This code does not relate to a current game, please try another.", "Ok");
            }
            
        }
    }
}