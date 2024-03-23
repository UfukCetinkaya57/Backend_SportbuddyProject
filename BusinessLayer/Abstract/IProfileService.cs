using CoreLayer.Entities.Concerete;
using CoreLayer.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IProfileService
    {
        IDataResult<Profile> GetProfileById(int profileId);
        IResult AddProfile(Profile profile);
        IResult UpdateProfile(Profile user);

        IResult DeleteUpdate(int id);

        
    }
}
