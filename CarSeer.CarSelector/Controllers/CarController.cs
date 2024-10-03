
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
            try
            {
                var makes = await _carService.GetAllMakesAsync();
                return Json(makes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving the car models.");
            }

        }

        public async Task<IActionResult> GetCarModels(int makeId, int year)
        {

            if (year < 1900 || year > DateTime.Now.Year)
            {
                return BadRequest($"Invalid year: {year}. The year must be between 1900 and {DateTime.Now.Year}.");
            }
            try
            {
                var carModels = await _carService.GetModelsForMakeYearAndTypeAsync(makeId, year);

                return Json(carModels);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving the car models.");
            }
        }
        public async Task<IActionResult> GetVehicleTypes(int makeId)
        {
            try
            {
                var carModels = await _carService.GetVehicleTypesByMakeIdAsync(makeId);
                return Json(carModels);
            }                      
              catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving the car models.");
            }
        }

    }
}

