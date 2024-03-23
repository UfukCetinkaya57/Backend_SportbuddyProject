using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using CoreLayer.Entities.Concerete;
using CoreLayer.Utilities.Results;
using DataAccessLayer;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ActivityManager : IActivityService
    {
        IActivityDal _activityDal;
        public ActivityManager(IActivityDal eventDal)
        {
            _activityDal = eventDal;
        }

        public IDataResult<Activity> GetActivityById(int activityId)
        {
            return new IResult<Activity>(_activityDal.Get(p => p.ActivityId == activityId));
        }
        public IResult AddActivity(Activity activity)
        {
            if(activity.UsersIdList== "string")
            {
                activity.UsersIdList = null;
            }
            if(activity.JoinTheActivitesList== "string")
            {
                activity.JoinTheActivitesList = null;
            }
            _activityDal.Add(activity);
            return new SuccessResult(Messages.ProductAdded);
        }
        public IDataResult<List<Activity>> GetList()
        {
            return new IResult<List<Activity>>(_activityDal.GetList().ToList());
        }

        public IResult UpdateActivity(Activity activity)
        {
            _activityDal.Update(activity);
            return new SuccessResult(Messages.ProductCategoryUpdated);
        }

        public IResult DeleteActivity(int id)
        {
            Activity activity = _activityDal.Get(p => p.ActivityId == id);
            _activityDal.Delete(activity);
            return new SuccessResult(Messages.ProductDeleted);
        }

        
    }
}
