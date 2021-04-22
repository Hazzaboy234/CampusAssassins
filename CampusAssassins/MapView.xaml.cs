using BruTile.Predefined;
using BruTile.Web;
using Mapsui.Layers;
using Mapsui.Projection;
using Mapsui.UI.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapsui.Rendering.Skia;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CampusAssassins
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapView : ContentPage
    {
        private static readonly BruTile.Attribution OpenStreetMapAttribution = new BruTile.Attribution(
            "© OpenStreetMap contributors", "http://www.openstreetmap.org/copyright");
        public MapView()
        {
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
            mapView.MyLocationLayer.UpdateMyLocation(new Mapsui.UI.Forms.Position(51.37795, -2.32624));
            var pin = new Pin()
            {
                Position = new Position(51.38019, -2.33172),
                Label = "Target",
            }
            ;
            pin.Callout.Anchor = new Point(0, pin.Height * pin.Scale);
            pin.Callout.RectRadius = 5;
            pin.Callout.ArrowHeight = 5;
            pin.Callout.ArrowWidth = 5;
            pin.Callout.ArrowAlignment = 0;
            pin.Callout.ArrowPosition = 0.5;
            pin.Callout.StrokeWidth = 5;
            pin.Callout.BackgroundColor = Color.Transparent;
            pin.Callout.RotateWithMap = true;
            pin.Callout.Type = CalloutType.Detail;
            pin.Callout.TitleFontSize = 15;
            pin.Callout.TitleTextAlignment = TextAlignment.Center;
            pin.Callout.TitleFontColor = Color.Black;
            mapView.Pins.Add(pin);
            pin.ShowCallout();
        }

        public async void OnButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new SpinningWheel());
        }
    }
}