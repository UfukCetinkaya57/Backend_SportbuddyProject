using CoreLayer.Entities.Concerete;
using CoreLayer.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Activity = CoreLayer.Entities.Concerete.Activity;

namespace BusinessLayer.Abstract
{
    public interface IActivityService
    {
        IDataResult<Activity> GetActivityById(int eventId);
        IResult AddActivity(Activity activity, int userId);
        IDataResult<List<Activity>> GetList();
        IResult UpdateActivity(Activity user);
        IResult JoinTheActivity(int activityId, int userId);
        IResult DeleteActivity(int id);

    }
}
