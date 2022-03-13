using DatabaseProject.DataAccess.Abstract;
using DatabaseProject.Entity.Concrete;
using DatabaseProject.Manager.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseProject.DisplayFunctions;
using System.Linq.Expressions;

namespace DatabaseProject.Manager.Concrete
{
    public class CarDetailManager : ICarDetailService, IManager
    {
        ICarDetailDal _carDetailDal;

        public CarDetailManager(ICarDetailDal carDetailDal)
        {
            _carDetailDal = carDetailDal;
        }
        public void Add(CarDetail t)
        {
            _carDetailDal.Add(t);
        }

        public void Delete(int id)
        {
            _carDetailDal.Delete(id);
        }

        public ICollection<CarDetail> GetAll()
        {
            return _carDetailDal.GetAll();
        }

        public CarDetail GetById(int id)
        {
            return _carDetailDal.GetById(id);
        }

        public void Update(CarDetail carDetail)
        {
            _carDetailDal.Update(carDetail);
        }

        public void Process(int islem)
        {
            ICollection<CarDetail> carDetails = GetAll();
            CarDetail carDetail = EntityGenerator();
            switch (islem)
            {
                case 1 : try
                         {
                            Add(carDetail);
                            DisplayFunc.IsSuccess();
                         }
                         catch (Exception)
                         {
                            DisplayFunc.IsError();
                         } break;

                case 2 : DisplayEntityList(carDetails);
                         try
                         {
                            Delete(DisplayFunc.DisplayDelete());
                            DisplayFunc.IsSuccess();
                         }
                         catch (Exception)
                         {
                            DisplayFunc.IsError();
                         } break;

                case 3 : DisplayEntityList(carDetails);
                         CarDetail updateCarDetail = GetById(DisplayFunc.DisplayUpdate());
                         updateCarDetail.CarType = "Tır";
                         try
                         {
                            Update(updateCarDetail);
                            DisplayFunc.IsSuccess();
                         }
                         catch (Exception)
                         {
                            DisplayFunc.IsError();
                         } break;

                default : break;
            };
        }
        
        public void DisplayEntityList(ICollection<CarDetail> carDetails) 
        {
            foreach (var item in carDetails)
            Console.WriteLine(item.ID + " - " + item.CarType + " - " + item.CarModel);
        }

        public CarDetail EntityGenerator() 
        {
            CarDetail carDetail = new CarDetail();
            carDetail.CarType = "Minivan";
            carDetail.CarModel = 2016;
            return carDetail;
        }


    }
}
