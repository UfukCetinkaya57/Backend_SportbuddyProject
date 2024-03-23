using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using CoreLayer.Entities.Concerete;
using CoreLayer.Utilities.Results;
using DataAccessLayer.Abstract;
using Newtonsoft.Json;
using Activity = CoreLayer.Entities.Concerete.Activity;

namespace BusinessLayer.Concrete
{
    public class JoinTheActivityManager: IJoinTheActivityService
    {
        IJoinTheActivityDal _joinTheActivityDal;
        IUserDal _userDal;
        IActivityDal _activityDal;
        public JoinTheActivityManager(IJoinTheActivityDal joinTheActivityDal, IUserDal userDal, IActivityDal activityDal)
        {
            _activityDal = activityDal;
            _joinTheActivityDal = joinTheActivityDal;
            _userDal = userDal;
        }

        /* public IDataResult<Activity> GetActivityById(int activityId)
         {
             return new IResult<Activity>(_activityDal.Get(p => p.ActivityId == activityId));
         }
        */

        public IResult AddJoinTheActivity(JoinTheActivity joinTheActivity)
        {
            User user= _userDal.Get(p => p.Id == joinTheActivity.UserId);
            var activity = _activityDal.Get(p => p.ActivityId == joinTheActivity.ActivityId);
          
            List<int> ActivitiesIdList = new List<int>();
            List<int> UsersIdList = new List<int>();
            
            //Add Activity de DTO ekleyeceksin
            //Soru= SQL DE LİSTE OLARAK USER İSMİ YA DA ID Sİ Mİ TUTMAK DAHA MANTIKLI YOKSA USER ENTİTİY SİNİ TUTMAK MI DAHA MANTIKLI?
//Burda kaldın
            if(activity.UsersIdList != null)
            {
                ActivitiesIdList = JsonConvert.DeserializeObject<List<int>>(activity.UsersIdList);
                ActivitiesIdList.Add(user.Id);
             //   activities.Add(user);
            }
            else
            {
                ActivitiesIdList.Add(joinTheActivity.UserId);

            }
            if (user.JoinTheActivitesIdList != null)
            {
                UsersIdList = JsonConvert.DeserializeObject<List<int>> (user.JoinTheActivitesIdList);
                UsersIdList.Add(joinTheActivity.ActivityId);
            }
            else
            {
                UsersIdList.Add(joinTheActivity.ActivityId);
            }

            activity.UsersIdList= JsonConvert.SerializeObject(ActivitiesIdList);
            user.JoinTheActivitesIdList = JsonConvert.SerializeObject(UsersIdList);            
            
            _activityDal.Update(activity);
            _userDal.Update(user);

            _joinTheActivityDal.Add(joinTheActivity);

            return new IResult<User>(user);
        }
        public IResult Update(JoinTheActivity joinTheActivity)
        {
            _joinTheActivityDal.Update(joinTheActivity);
            return new SuccessResult(Messages.ProductCategoryUpdated);
        }

        public IResult Delete(int id)
        {
            JoinTheActivity joinTheActivity = _joinTheActivityDal.Get(p => p.JoinActivityId == id);
            _joinTheActivityDal.Delete(joinTheActivity);
            return new SuccessResult(Messages.ProductDeleted);
        }
    }
}
