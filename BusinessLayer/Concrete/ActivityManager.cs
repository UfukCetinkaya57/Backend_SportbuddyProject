using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using CoreLayer.Entities.Concerete;
using CoreLayer.Utilities.Results;
using DataAccessLayer;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Dtos;
using Newtonsoft.Json;
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

        public IResult JoinTheActivity(int activityId, int userId)
        {

            // User user = _userDal.Get(p => p.Id == joinTheActivity.UserId);
            var activity = _activityDal.Get(p => p.ActivityId == activityId);

            List<int> ActivitiesIdList = new List<int>();
            List<int> UsersIdList = new List<int>();

            //Add Activity de DTO ekleyeceksin
            //Soru= SQL DE LİSTE OLARAK USER İSMİ YA DA ID Sİ Mİ TUTMAK DAHA MANTIKLI YOKSA USER ENTİTİY SİNİ TUTMAK MI DAHA MANTIKLI?
            //Burda kaldın
            if (activity.UsersIdList != null)
            {
                ActivitiesIdList = JsonConvert.DeserializeObject<List<int>>(activity.UsersIdList);
                ActivitiesIdList.Add(userId);
                //   activities.Add(user);
            }
            else
            {
                ActivitiesIdList.Add(userId);

            }
           /* if (user.JoinTheActivitesIdList != null)
            {
                UsersIdList = JsonConvert.DeserializeObject<List<int>>(user.JoinTheActivitesIdList);
                UsersIdList.Add(joinTheActivity.ActivityId);
            }
            else
            {
                UsersIdList.Add(joinTheActivity.ActivityId);
            }
           */
            activity.UsersIdList = JsonConvert.SerializeObject(ActivitiesIdList);
        //    user.JoinTheActivitesIdList = JsonConvert.SerializeObject(UsersIdList);

            _activityDal.Update(activity);
        //    _userDal.Update(user);

        //    _joinTheActivityDal.Add(joinTheActivity);

            return new IResult<Activity>(activity);
        }
        public IResult AddActivity(Activity activity, int userId)
        {
            //  User user = _userDal.Get(p => p.Id == joinTheActivity.UserId);
            //  var activity = _activityDal.Get(p => p.ActivityId == joinTheActivity.ActivityId);

            
           // List<int> ActivitiesIdList = new List<int>();
            List<int> UsersIdList = new List<int>();

            //Add Activity de DTO ekleyeceksin
            //Soru= SQL DE LİSTE OLARAK USER İSMİ YA DA ID Sİ Mİ TUTMAK DAHA MANTIKLI YOKSA USER ENTİTİY SİNİ TUTMAK MI DAHA MANTIKLI?
            //Burda kaldın
            if (activity.UsersIdList != null)
            {
                UsersIdList = JsonConvert.DeserializeObject<List<int>>(activity.UsersIdList);
                UsersIdList.Add(userId);
             //   activities.Add(user);
            }
            else
            {
                UsersIdList.Add(userId);
            }
            activity.UsersIdList = JsonConvert.SerializeObject(UsersIdList);
            _activityDal.Add(activity);

            /*if (user.JoinTheActivitesIdList != null)
            {
                UsersIdList = JsonConvert.DeserializeObject<List<int>>(user.JoinTheActivitesIdList);
                UsersIdList.Add(joinTheActivity.ActivityId);
            }
            else
            {
                UsersIdList.Add(joinTheActivity.ActivityId);
            }
            */
            //        user.JoinTheActivitesIdList = JsonConvert.SerializeObject(UsersIdList);

            //  _activityDal.Update(activity);
            // _userDal.Update(user);

            if (activity.UsersIdList== "string")
            {
                activity.UsersIdList = null;
            }
            if(activity.JoinTheActivitesList== "string")
            {
                activity.JoinTheActivitesList = null;
            }
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
