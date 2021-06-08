
namespace API.Dtos.Response
{
    public class CarDto : VehicleBasicDto
    { 
        public string HeadlightsStatus { get; set; }
        public int WheelsCount { get; set; }
    }
}
