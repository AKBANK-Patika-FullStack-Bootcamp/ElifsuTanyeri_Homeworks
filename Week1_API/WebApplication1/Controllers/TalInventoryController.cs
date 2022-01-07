using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;


namespace WebApplication1.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class TalInventoryController : ControllerBase
    {

        List<Planes> planeList = new List<Planes>();
        Message _message = new Message();


        [HttpGet]

        //summary: GetPlane function, fills the inventory.
        public List<Planes> GetPlane()
        {

            planeList = AddPlane();
            return planeList;
        }

        [HttpGet("{Id}")]
        // summary: Find the plane by its id.
        public Planes GetPlane(int Id)
        {
            //List<Planes> planeList = new List<Planes>();
            planeList = AddPlane();

            Planes resultObject = new Planes();
            resultObject = planeList.FirstOrDefault(x => x.Id == Id);


            return resultObject;
        }

        [HttpPost]
        public Message Post(Planes newPlane)
        {
            

            planeList = AddPlane();

            // check if the plane you are trying to add already exists
            bool inventoryCheck = planeList.Select(x => x.ModelFamily == newPlane.ModelFamily || x.Id == newPlane.Id).FirstOrDefault();
            if (inventoryCheck == !true)
            {
                planeList.Add(newPlane);
                _message.status = 1;
                _message.message = "Plane uploaded to inventory successfully.";
                _message.planesList = planeList;
            }
            else
            {
                _message.status = 0;
                _message.message = "Fail: Plane already exists in the inventory";
                _message.planesList = planeList;
            }

            return _message;
        }

        [HttpPut("{Id}")]

        public Message Update(int Id, Planes newValue)
        {
            planeList = AddPlane();

            Planes? oldValue = planeList.Find( o => o.Id == Id );

            if (oldValue != null)
            {
                oldValue = newValue;

                planeList.Add(newValue);
                planeList.Remove(oldValue);

                _message.status = 1;
                _message.message = "Plane updated successfully.";
                _message.planesList = planeList;
            }

            else
            {
                _message.status = 0;
                _message.message = "Fail: Plane doesn't exist in the inventory";
                _message.planesList = planeList;

            }
            return _message;
            
        }

        [HttpDelete("{Id}")]

        public Message Delete(int Id)
        {
            planeList = AddPlane();

            Planes? oldValue = planeList.Find(o => o.Id == Id);
            if (oldValue != null)
            {
                planeList?.Remove(oldValue);
                _message.status = 1;
                _message.message = "Plane deleted successfully.";
                _message.planesList = planeList;
            }
            else
            {
                _message.status = 0;
                _message.message = "Fail: Plane doesn't exist in the inventory";
                _message.planesList = planeList;

            }

            return _message;
        }
        // Add Plane function fills the inventory.
        public List<Planes> AddPlane()
        {
            List<Planes> lst = new List<Planes>();
            lst.Add(new Model.Planes { Id = 123, Brand = "Airbus", ModelFamily = "A380", PassengerCapacity = 500, FuelCapacity = 230, FlightDuration = 18 });
            lst.Add(new Model.Planes { Id = 124, Brand = "Airbus", ModelFamily = "A350", PassengerCapacity = 410, FuelCapacity = 141, FlightDuration = 13 });
            lst.Add(new Model.Planes { Id = 125, Brand = "Airbus", ModelFamily = "A320", PassengerCapacity = 194, FuelCapacity = 26, FlightDuration = 6 });
            lst.Add(new Model.Planes { Id = 126, Brand = "Airbus", ModelFamily = "A220", PassengerCapacity = 135, FuelCapacity = 21, FlightDuration = 4 });
            
            return lst;
        }
    }

}

