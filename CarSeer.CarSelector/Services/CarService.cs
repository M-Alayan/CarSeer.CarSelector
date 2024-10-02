using CarSeer.CarSelector.Models;
using CarSeer.CarSelector.Models.Response;
using Microsoft.Extensions.Options;

namespace CarSeer.CarSelector.Services
{
    public class CarService : ICarService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _apiSettings;

        public CarService(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _apiSettings = apiSettings.Value;
        }

        public async Task<List<CarMake>> GetAllMakesAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<VehiclesApiResponse<CarMake>>(_apiSettings.GetAllMakes);
            return response.Results;
        }

        public async Task<List<VehicleType>> GetVehicleTypesByMakeIdAsync(int makeId)
        {
            var url = _apiSettings.GetVehicleTypesForMakeId.Replace("{makeId}", makeId.ToString());
            var response = await _httpClient.GetFromJsonAsync<VehiclesApiResponse<VehicleType>>(url);
            return response.Results;
        }
        
        public async Task<List<CarModel>> GetModelsForMakeYearAndTypeAsync(int makeId, int year)
        {
            var url = _apiSettings.GetModelsForMakeIdYear
                .Replace("{makeId}", makeId.ToString())
                .Replace("{year}", year.ToString());

            var response = await _httpClient.GetFromJsonAsync<VehiclesApiResponse<CarModel>>(url);
            return response.Results;
        }
    }

}