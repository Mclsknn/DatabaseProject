using DatabaseProject.DataAccess.Abstract;
using DatabaseProject.DisplayFunctions;
using DatabaseProject.Entity.Concrete;
using DatabaseProject.Manager.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.Manager.Concrete
{
    public class TyreDetailManager : ITyreDetailService, IManager

    {
        ITyreDetailDal _tyreDetailDal;
        public TyreDetailManager(ITyreDetailDal tyreDetailDal)
        {
            _tyreDetailDal = tyreDetailDal;
        }
        public void Add(TyreDetail t)
        {
            _tyreDetailDal.Add(t);
        }

        public void Delete(int id)
        {
            _tyreDetailDal.Delete(id);
        }

        public ICollection<TyreDetail> GetAll()
        {
            return _tyreDetailDal.GetAll();
        }

        public TyreDetail GetById(int id)
        {
            return _tyreDetailDal.GetById(id);
        }

        public void Update(TyreDetail tyreDetail)
        {
            _tyreDetailDal.Update(tyreDetail);
        }

        public void Process(int islem)
        {
            ICollection<TyreDetail> tyreDetails = GetAll();
            TyreDetail tyreDetail = EntityGenerator();
            switch (islem)
            {
                case 1 : try
                         {
                           Add(tyreDetail);
                           DisplayFunc.IsSuccess();
                         }
                         catch (Exception)
                         {
                           DisplayFunc.IsError();
                         } break;

                case 2:  DisplayEntityList(tyreDetails);
                         try
                         {
                            Delete(DisplayFunc.DisplayDelete());
                            DisplayFunc.IsSuccess();
                         }
                         catch (Exception)
                         {
                            DisplayFunc.IsError();
                         } break;

                 case 3: DisplayEntityList(tyreDetails);
                         TyreDetail updateTyreDetail = GetById(DisplayFunc.DisplayUpdate());
                         updateTyreDetail.TyreType = "Kışlık";
                         try
                         {
                           Update(updateTyreDetail);
                           DisplayFunc.IsSuccess();
                         }
                         catch (Exception)
                         {
                            DisplayFunc.IsError();
                         } break;

                 default:  break;
            };
        }
     
        public void DisplayEntityList(ICollection<TyreDetail> tyreDetails)
        {
            foreach (var item in tyreDetails)
            Console.WriteLine("\n" + item.ID + " - " + item.TyreType + " - " + Convert.ToDateTime(item.ExpirationDate).ToString("dd-MM-yyyy"));
        }

        public TyreDetail EntityGenerator()
        {
            TyreDetail tyreDetail = new TyreDetail();
            tyreDetail.TyreType = "Mevsimlik";
            tyreDetail.ExpirationDate = DateTime.Now;
            tyreDetail.CarID = 1;
            return tyreDetail;
        }

    }
}
