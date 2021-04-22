using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CampusAssassins
{
    public partial class MainMenu : ContentPage
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        
        public async void HostGame(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new CreateGame());
        }
        public async void JoinPublicGame(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Lobby());
        }
        public async void JoinPrivateGame(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new CodeEntry());
        }
        public async void Settings(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Options());
        }

    }
}
