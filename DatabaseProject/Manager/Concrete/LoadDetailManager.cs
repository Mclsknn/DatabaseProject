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
    public class LoadDetailManager : ILoadDetailService, IManager

    {
        ILoadDetailDal _loadDetailDal;
        public LoadDetailManager(ILoadDetailDal loadDetailDal)
        {
            _loadDetailDal = loadDetailDal;
        }
        public void Add(LoadDetail t)
        {
            _loadDetailDal.Add(t);
        }

        public void Delete(int id)
        {
            _loadDetailDal.Delete(id);
        }

        public ICollection<LoadDetail> GetAll()
        {
           return _loadDetailDal.GetAll();
        }

        public LoadDetail GetById(int id)
        {
            return _loadDetailDal.GetById(id);
        }

        public void Update(LoadDetail loadDetail)
        {
            _loadDetailDal.Update(loadDetail);
        }
        public void Process( int islem)
        {
            ICollection<LoadDetail> loadDetails = GetAll();
            LoadDetail loadDetail = EntityGenerator();
          
            switch (islem)
            {
                case 1 : try
                         {
                            Add(loadDetail);
                            DisplayFunc.IsSuccess();
                         }
                         catch (Exception)
                         {
                            DisplayFunc.IsError();
                         } break;

                case 2 : DisplayEntityList(loadDetails);
                         try
                         {
                            Delete(DisplayFunc.DisplayDelete());
                            DisplayFunc.IsSuccess();
                         }
                         catch (Exception)
                         {
                            DisplayFunc.IsError();
                         } break;

                case 3 : DisplayEntityList(loadDetails);
                         LoadDetail updateLoadDetail = GetById(DisplayFunc.DisplayUpdate());
                         updateLoadDetail.LoadType = "Temizlik Malzemeleri";
                         try
                         {
                            Update(updateLoadDetail);
                            DisplayFunc.IsSuccess();
                         }
                         catch (Exception)
                         {
                            DisplayFunc.IsError();
                         } break;

                default: break;
            };
        }
    
        public void DisplayEntityList(ICollection<LoadDetail> loadDetails)
        {
            foreach (var item in loadDetails)
            Console.WriteLine(item.ID + " - " + item.LoadType);
        }
        public LoadDetail EntityGenerator()
        {
            LoadDetail loadDetail = new LoadDetail();
            loadDetail.LoadType = "Züccaciye";
            loadDetail.LoadDepth = 12.2m;
            loadDetail.LoadWidth = 17.55m;
            loadDetail.DeliveryDetailID = 8;
            return loadDetail;
        }

    }
}
