using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using EF.Core.Data;
using EF.Data;

namespace EF.Web.Controllers
{
    public class CarController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private Repository<Car> CarRepository;

        public CarController()
        {
            
            CarRepository = unitOfWork.Repository<Car>();
        }

        public ActionResult Index()
        {
            IEnumerable<Car> Cars = CarRepository.Table.ToList();
            return View(Cars);
        }

        public ActionResult CreateEditCar(int? id)
        {
            Car model = new Car();
            if (id.HasValue)
            {
                model = CarRepository.GetById(id.Value);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateEditCar(Car car)
        {

            if (ModelState.IsValid)
            {


                if (car.ID == 0)
                {


                    CarRepository.Insert(car);
                }
                else
                {
                    var editModel = CarRepository.GetById(car.ID);
                    editModel.Make = car.Make;
                    editModel.Model = car.Model;



                    CarRepository.Update(editModel);
                }

                if (car.ID > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(car);
        }

        public ActionResult DeleteCar(int id)
        {
            Car model = CarRepository.GetById(id);
            return View(model);
        }

        [HttpPost,ActionName("DeleteCar")]
        public ActionResult ConfirmDeleteCar(int id)
        {
            Car model = CarRepository.GetById(id);
            CarRepository.Delete(model);
            return RedirectToAction("Index");
        }

        public ActionResult DetailCar(int id)
        {
            Car model = CarRepository.GetById(id);
            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
