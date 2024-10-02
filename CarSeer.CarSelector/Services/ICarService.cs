using CarSeer.CarSelector.Models;

namespace CarSeer.CarSelector.Services
{
    public interface ICarService
    {
        Task<List<CarMake>> GetAllMakesAsync();
        Task<List<VehicleType>> GetVehicleTypesByMakeIdAsync(int makeId);
        Task<List<CarModel>> GetModelsForMakeYearAndTypeAsync(int makeId, int year);
    }
}
