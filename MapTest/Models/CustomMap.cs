using Xamarin.Forms.Maps;
using System.Collections.Generic;
namespace MapTest.Models
{
    public class CustomMap: Map
    {
        public List<CustomPin> CustomPins { get; set; }
        public List<Position> RouteCoordinates { get; set; }
    }
}
