
using CarSeer.CarSelector.Services;
using Microsoft.AspNetCore.Mvc;



namespace CarSeer.CarSelector.Controllers
{
   
    public class CarController : Controller
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpGet]     
        public IActionResult Index()
        {
            return View();
        }
       
        public async Task<IActionResult> GetAllMakes()
        
        {
            var makes = await _carService.GetAllMakesAsync();
            return Ok(makes);
        }
        
        public async Task<IActionResult> GetModelsAndTypes(int makeId, int year)
        {
            var vehicleTypes = await _carService.GetVehicleTypesByMakeIdAsync(makeId);
            var carModels = await _carService.GetModelsForMakeYearAndTypeAsync(makeId, year);

            var Results = new
            {
                VehicleTypes = vehicleTypes,
                CarModels = carModels
            };

            return Ok(Results);
        }

    }
}

