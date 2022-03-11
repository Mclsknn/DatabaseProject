using DatabaseProject.DataAccess.Abstract;
using DatabaseProject.Entity.Concrete;
using DatabaseProject.Manager.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseProject.DisplayFunctions;
namespace DatabaseProject.Manager.Concrete
{
    public class DeliveryDetailManager : IDeliveryDetailService, IManager
    {
        IDeliveryDetailDal _deliveryDetailDal;
        public DeliveryDetailManager(IDeliveryDetailDal deliveryDetailDal)
        {
            _deliveryDetailDal = deliveryDetailDal;
        }
        public void Add(DeliveryDetail d)
        {
            _deliveryDetailDal.Add(d);
        }


        public void Delete(int id)
        {
            _deliveryDetailDal.Delete(id);
        }

        public ICollection<DeliveryDetail> GetAll()
        {
            return _deliveryDetailDal.GetAll();
        }

        public DeliveryDetail GetById(int id)
        {
            return _deliveryDetailDal.GetById(id);
        }

        public void Update(DeliveryDetail deliveryDetail)
        {
            _deliveryDetailDal.Update(deliveryDetail);
        }
        public void Process(int islem)
        {
            ICollection<DeliveryDetail> deliveryDetails = GetAll();
            DeliveryDetail deliveryDetail = EntityGenerator();

            switch (islem)
            {
                case 1 : Add(deliveryDetail); break;

                case 2 : DisplayEntityList(deliveryDetails);
                         try
                         {
                            Delete(DisplayFunc.DisplayDelete());
                            DisplayFunc.IsSuccess();
                         }
                         catch (Exception)
                         {
                            DisplayFunc.IsError();
                         } break;

                case 3: DisplayEntityList(deliveryDetails);
                        DeliveryDetail updateDelivery = GetById(DisplayFunc.DisplayUpdate());
                        updateDelivery.DeliveryEndDate = DateTime.Now;
                        try
                        {
                           Update(updateDelivery);
                           DisplayFunc.IsSuccess();
                        }
                        catch (Exception)
                        {
                           DisplayFunc.IsError();
                        } break;

                default: break;
            };

        }

        public void DisplayEntityList(ICollection<DeliveryDetail> deliveryDetails)
        {
            foreach (var item in deliveryDetails)
            { Console.WriteLine(item.DeliveryID); }
        }

        public DeliveryDetail EntityGenerator()
        {
            DeliveryDetail deliveryDetail = new DeliveryDetail();
            deliveryDetail.AddressDetail = "Anadolu bölgesi";
            deliveryDetail.CityDestinationId = 1;
            deliveryDetail.CityDepartureId = 2;
            deliveryDetail.CountryDepartureId = 1;
            deliveryDetail.CountryDestinationId = 1;
            deliveryDetail.DeliveryStartDate = DateTime.Now;
            deliveryDetail.DeliveryEndDate = DateTime.Now;
            return deliveryDetail;
        }

    }
}