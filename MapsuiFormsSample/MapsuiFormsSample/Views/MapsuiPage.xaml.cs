using System;
using Xamarin.Forms;
using BruTile.Predefined;
using Mapsui.UI.Forms;
using Mapsui.Utilities;

namespace MapsuiFormsSample.Views
{
    public partial class MapsuiPage : ContentPage
    {
        Mapsui.Layers.TileLayer activeLayer = null;

        static Random rnd = new Random();
        int markerNum = 1;

        public MapsuiPage()
        {
            InitializeComponent();

            ReplaceLayer(KnownTileSource.OpenCycleMap);

            mapView.RotationLock = false;
            mapView.UnSnapRotationDegrees = 30;
            mapView.ReSnapRotationDegrees = 5;
            mapView.MyLocationEnabled = false;

            //mapView.UseDoubleTap = true;
            //mapView.Map.CRS = "EPSG:3857";
            //mapView.Map.Transformation = new MinimalTransformation();

        }

        public void ReplaceLayer(KnownTileSource tileSource)
        {
            if (activeLayer != null)
            {
                mapView.Map.Layers.Remove(activeLayer);
                activeLayer = null;
            }

            var api = "YOUR_API_HERE";
            activeLayer = OpenStreetMap.CreateTileLayer();
            activeLayer.TileSource = KnownTileSources.Create(tileSource, api);
            mapView.Map.Layers.Add(activeLayer);
        }

        private void AddPin_Clicked(object sender, EventArgs e)
        {
            Position p = new Position(41.0f, -116.0f);
            var pin = new Pin(mapView)
            {
                Label = $"PinType.Pin {markerNum++}",
                Address = p.ToString(),
                Position = p,
                Type = PinType.Pin,
                Color = new Color(rnd.Next(0, 255) / 255.0, rnd.Next(0, 255) / 255.0, rnd.Next(0, 255) / 255.0),
                Transparency = 0.3f,
                Scale = rnd.Next(50, 130) / 100f,
            };
            mapView.Pins.Add(pin);
        }
    }
}
