using BruTile.Predefined;
using BruTile.Web;
using Mapsui;
using Mapsui.Geometries;
using Mapsui.Layers;
using Mapsui.Projection;
using Mapsui.Providers;
using Mapsui.Styles;
using Mapsui.UI;
using Mapsui.UI.Forms;
using Mapsui.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Point = Mapsui.Geometries.Point;

namespace CampusAssassins
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Lobby : ContentPage
    {
        private static readonly BruTile.Attribution OpenStreetMapAttribution = new BruTile.Attribution(
            "© OpenStreetMap contributors", "http://www.openstreetmap.org/copyright");
        private int hours;
        private int minutes;
        private int seconds;
        public Lobby()
        {
            hours = 0;
            minutes = 0;
            seconds = 12;
            InitializeComponent();
            var map = new Mapsui.Map
            {
                CRS = "EPSG:3857",
                Transformation = new MinimalTransformation()
            };
            var tileLayer = new HttpTileSource(new GlobalSphericalMercator(),
                "https://api.maptiler.com/maps/hybrid/{z}/{x}/{y}.jpg?key=UNzmzzs5vM5fHNT7gBDM",
                new[] { "a", "b", "c" }, name: "OpenStreetMap",
                attribution: OpenStreetMapAttribution);
            map.Layers.Add(new TileLayer(tileLayer));
            map.Home = n => n.NavigateTo(SphericalMercator.FromLonLat(-2.32624, 51.37795), mapView.Map.Resolutions[14]);
            mapView.IsMyLocationButtonVisible = false;
            mapView.IsNorthingButtonVisible = false;
            mapView.Map = map;
            mapView.Drawables.Add(CreatePolygon());
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                if(seconds == 0 && hours == 0 && minutes == 0) {StartGame();}
                if(seconds == 0) { seconds = 60; minutes -= 1; };
                if(minutes == -1) { minutes = 59; hours -= 1; };
                seconds -= 1;
                string labelText;
                labelText = hours.ToString();
                labelText += ":";
                if(minutes < 10)
                {
                    labelText += "0" + minutes.ToString();
                } else
                {
                    labelText += minutes.ToString();
                }
                labelText += ":";
                if (seconds < 10)
                {
                    labelText += "0" + seconds.ToString();
                }
                else
                {
                    labelText += seconds.ToString();
                }
                Device.BeginInvokeOnMainThread(() => {
                   TimerLabel.Text = labelText;
                });

                return true; // True = Repeat again, False = Stop the timer
            });
        }

        public async void OnButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new Lobby());
        }

        public async void StartGame()
        {
            await Navigation.PushAsync(new MapView());
        }

        private static Mapsui.UI.Forms.Polygon CreatePolygon()
        {
            var polygon = new Mapsui.UI.Forms.Polygon { StrokeWidth = 4, StrokeColor = Xamarin.Forms.Color.Red, IsClickable = false, FillColor = Xamarin.Forms.Color.Transparent};
            polygon.Positions.Add(new Position(51.3785443, -2.3356602));
            polygon.Positions.Add(new Position(51.378392, -2.3348513));
            polygon.Positions.Add(new Position(51.3782115, -2.3342818));
            polygon.Positions.Add(new Position(51.3780787, -2.3339324));
            polygon.Positions.Add(new Position(51.3779293, -2.3335734));
            polygon.Positions.Add(new Position(51.377841, -2.3333351));
            polygon.Positions.Add(new Position(51.3783562, -2.3326487));
            polygon.Positions.Add(new Position(51.3782455, -2.3324529));
            polygon.Positions.Add(new Position(51.3778973, -2.3319701));
            polygon.Positions.Add(new Position(51.377529, -2.3315666));
            polygon.Positions.Add(new Position(51.377369, -2.3313413));
            polygon.Positions.Add(new Position(51.3770066, -2.3302857));
            polygon.Positions.Add(new Position(51.376967, -2.3301019));
            polygon.Positions.Add(new Position(51.3768057, -2.3288909));
            polygon.Positions.Add(new Position(51.376296, -2.3290339));
            polygon.Positions.Add(new Position(51.375948, -2.3256974));
            polygon.Positions.Add(new Position(51.3739931, -2.3271998));
            polygon.Positions.Add(new Position(51.3738775, -2.3268456));
            polygon.Positions.Add(new Position(51.373684, -2.3262857));
            polygon.Positions.Add(new Position(51.3734796, -2.3255709));
            polygon.Positions.Add(new Position(51.3732471, -2.3247536));
            polygon.Positions.Add(new Position(51.3727672, -2.3231128));
            polygon.Positions.Add(new Position(51.3730617, -2.3230142));
            polygon.Positions.Add(new Position(51.3730546, -2.3228941));
            polygon.Positions.Add(new Position(51.3741605, -2.3225475));
            polygon.Positions.Add(new Position(51.375608, -2.3221315));
            polygon.Positions.Add(new Position(51.375396, -2.3200945));
            polygon.Positions.Add(new Position(51.3738791, -2.3206619));
            polygon.Positions.Add(new Position(51.3729334, -2.3209871));
            polygon.Positions.Add(new Position(51.3725726, -2.3211308));
            polygon.Positions.Add(new Position(51.3724812, -2.320783));
            polygon.Positions.Add(new Position(51.3726272, -2.3206997));
            polygon.Positions.Add(new Position(51.3725297, -2.3202935));
            polygon.Positions.Add(new Position(51.3721767, -2.3205497));
            polygon.Positions.Add(new Position(51.3720563, -2.3198451));
            polygon.Positions.Add(new Position(51.3718198, -2.3200252));
            polygon.Positions.Add(new Position(51.3716821, -2.3196907));
            polygon.Positions.Add(new Position(51.3714695, -2.3191502));
            polygon.Positions.Add(new Position(51.3712823, -2.3187534));
            polygon.Positions.Add(new Position(51.3711087, -2.3185128));
            polygon.Positions.Add(new Position(51.3714227, -2.318341));
            polygon.Positions.Add(new Position(51.3719551, -2.3182192));
            polygon.Positions.Add(new Position(51.372197, -2.3181942));
            polygon.Positions.Add(new Position(51.3725071, -2.3182504));
            polygon.Positions.Add(new Position(51.3730571, -2.3183348));
            polygon.Positions.Add(new Position(51.373529, -2.3183004));
            polygon.Positions.Add(new Position(51.3741668, -2.3180161));
            polygon.Positions.Add(new Position(51.3745002, -2.3177818));
            polygon.Positions.Add(new Position(51.3747577, -2.31741));
            polygon.Positions.Add(new Position(51.3748938, -2.3168895));
            polygon.Positions.Add(new Position(51.3751692, -2.317738));
            polygon.Positions.Add(new Position(51.3752004, -2.3179317));
            polygon.Positions.Add(new Position(51.3752192, -2.3182296));
            polygon.Positions.Add(new Position(51.376378, -2.3179645));
            polygon.Positions.Add(new Position(51.3767929, -2.3178222));
            polygon.Positions.Add(new Position(51.3780499, -2.3191877));
            polygon.Positions.Add(new Position(51.3781127, -2.3189924));
            polygon.Positions.Add(new Position(51.379871, -2.3206131));
            polygon.Positions.Add(new Position(51.3798168, -2.320867));
            polygon.Positions.Add(new Position(51.3806809, -2.3216867));
            polygon.Positions.Add(new Position(51.3808309, -2.3219501));
            polygon.Positions.Add(new Position(51.3809929, -2.321923));
            polygon.Positions.Add(new Position(51.3813798, -2.3222407));
            polygon.Positions.Add(new Position(51.3814136, -2.3224422));
            polygon.Positions.Add(new Position(51.3817886, -2.3227929));
            polygon.Positions.Add(new Position(51.3822835, -2.3234966));
            polygon.Positions.Add(new Position(51.3821445, -2.323826));
            polygon.Positions.Add(new Position(51.3819634, -2.3245954));
            polygon.Positions.Add(new Position(51.381766, -2.3264702));
            polygon.Positions.Add(new Position(51.3818459, -2.3274857));
            polygon.Positions.Add(new Position(51.381844, -2.3287205));
            polygon.Positions.Add(new Position(51.381828, -2.3289437));
            polygon.Positions.Add(new Position(51.3818022, -2.3291881));
            polygon.Positions.Add(new Position(51.3816962, -2.3305057));
            polygon.Positions.Add(new Position(51.3817717, -2.3309192));
            polygon.Positions.Add(new Position(51.3817875, -2.3311721));
            polygon.Positions.Add(new Position(51.381659, -2.332151));
            polygon.Positions.Add(new Position(51.3815447, -2.3323622));
            polygon.Positions.Add(new Position(51.3814275, -2.3326036));
            polygon.Positions.Add(new Position(51.3812209, -2.3328671));
            polygon.Positions.Add(new Position(51.3810458, -2.333065));
            polygon.Positions.Add(new Position(51.3808381, -2.333405));
            polygon.Positions.Add(new Position(51.3805201, -2.3340198));
            polygon.Positions.Add(new Position(51.3798438, -2.3350176));
            polygon.Positions.Add(new Position(51.3796958, -2.3352065));
            polygon.Positions.Add(new Position(51.3795992, -2.3353298));
            polygon.Positions.Add(new Position(51.3794621, -2.3354629));
            polygon.Positions.Add(new Position(51.3791941, -2.335539));
            polygon.Positions.Add(new Position(51.3785443, -2.3356602));
            return polygon;
        }
    }
}