namespace CarSeer.CarSelector.Models.Response
{
    public class VehiclesApiResponse<T>
    {
        public int Count { get; set; }
        public string Message { get; set; }
        public string SearchCriteria { get; set; }
        public List<T> Results { get; set; }
    }
}
