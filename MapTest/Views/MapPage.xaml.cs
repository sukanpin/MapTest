using Xamarin.Forms;
using Xamarin.Forms.Maps;
using MapTest.Models;
using System.Collections.Generic;
namespace MapTest.Views
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
            var customMap = new CustomMap()
            {  // <-4
                IsShowingUser = true,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            /*pin追加*/
            var pin = new CustomPin
            {
                Type = PinType.Place,
                Position = new Position(35.714722, 139.79675),
                Label = "Sensoji temple",
                Address = "〒111-0032 東京都台東区 浅草2丁目3番1号",
                Id = "Start",
                Url = ""
            };
            customMap.CustomPins = new List<CustomPin> { pin };
            customMap.Pins.Add(pin);
            /*root追加*/
            customMap.RouteCoordinates = new List<Position> {};
            customMap.RouteCoordinates.Add(new Position(35.714722, 139.79675));
            customMap.RouteCoordinates.Add(new Position(35.712083, 139.798417));
            /*map移動*/
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                new Position(35.714722, 139.79675), Distance.FromMeters(100)));
            Content = new StackLayout
            {
                Children = { customMap }
            };

        }
    }
}
