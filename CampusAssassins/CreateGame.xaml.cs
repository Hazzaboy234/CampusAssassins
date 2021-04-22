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
    public partial class CreateGame : ContentPage
    {
        public CreateGame()
        {
            InitializeComponent();
        }
        public async void OnButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Lobby());
        }
    }
}