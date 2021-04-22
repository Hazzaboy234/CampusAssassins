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
    public partial class Options : ContentPage
    {
        public Options()
        {
            InitializeComponent();
        }
        public async void OnButtonClicked(object sender, EventArgs args)
        {
            await DisplayAlert("Username changed", "You have successfully updated your username!", "Ok");
        }

        public async void OnSliderValueChanged(object sender, EventArgs args)
        {
            var slider = (Slider) sender;
            Radius.Text = $"Radius: {slider.Value}";
        }
    }
}