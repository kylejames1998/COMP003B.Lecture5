// TODO: Add a using directive to include the Models namespace
using COMP003B.Lecture5.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.Lecture5.Controllers
{
    // api/Vehicles
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : Controller
    {
        // TODO: create a list of vehicles
        private List<Vehicle> _vehicles = new List<Vehicle>();

        //TODO: add default constuctor to pre-fill
        public VehiclesController()
        {
            _vehicles.Add(new Vehicle { Id = 1, Make = "Toyota", Model = "Corolla", Year = 2018 });
            _vehicles.Add(new Vehicle { Id = 2, Make = "Honda", Model = "Civic", Year = 2019 });
            _vehicles.Add(new Vehicle { Id = 3, Make = "Ford", Model = "Fusion", Year = 2020 });
        }

        // TODO: create CRUD operations

        // TODO: GET ALL (READ): api/Vehicles
        [HttpGet]
        public ActionResult<IEnumerable<Vehicle>> GetAllVehicles()
        {
            return _vehicles;
        }
        // TODO: GET by ID (READ): api/Vehicles/{id}
        [HttpGet("{id}")]
        public ActionResult<Vehicle> GetVehicleById(int id)
        {
            // TODO: find vehicle by id
            var vehicle = _vehicles.FirstOrDefault(v => v.Id == id);
            // TODO: return 404 if not found
            if (vehicle == null)
            {
                return NotFound();
            }
            return vehicle;
        }

        // TODO: POST (CREATE): api/Vehicles
        [HttpPost]
        public ActionResult<Vehicle> CreateVehicle(Vehicle vehicle)
        {
            // TODO: automatically assign an ID
            vehicle.Id = _vehicles.Max(v => v.Id) + 1;

            //TODO: add to list
            _vehicles.Add(vehicle);

            return CreatedAtAction(nameof(GetVehicleById), new { id = vehicle.Id }, vehicle);
        }

        // TODO: PUT (UPDATE): api/Vehicles/{id}
        [HttpPut]
        public ActionResult UpdateVehicle(int id, Vehicle updatedVehicle)
        {
            // TODO: find vehicle by id
            var vehicle = _vehicles.Find(v => v.Id == id);

            // TODO: return BadRequest if not found
            if (vehicle == null)
            {
                return BadRequest();
            }

            // TODO: update vehicle
            vehicle.Make = updatedVehicle.Make;
            vehicle.Model = updatedVehicle.Model;
            vehicle.Year = updatedVehicle.Year;

            return NoContent();
        }

        //TODO: DELETE (DELETE): api/Vehicles/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteVehicle(int id)
        {
            // TODO: find vehicle by id
            var vehicle = _vehicles.Find(v => v.Id == id);

            // TODO: return NotFound if not found
            if (vehicle == null)
            {
                return NotFound();
            }

            // TODO: remove from list
            _vehicles.Remove(vehicle);
            return NoContent();
        }


    }
}
