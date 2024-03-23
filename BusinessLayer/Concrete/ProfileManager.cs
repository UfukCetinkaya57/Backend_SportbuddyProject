using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using CoreLayer.Entities.Concerete;
using CoreLayer.Utilities.Results;
using CoreLayer.Utilities.Security.JWT;
using DataAccessLayer;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ProfileManager : IProfileService
    {
        IProfileDal _profileDal;
        public ProfileManager(IProfileDal profileDal)
        {
            _profileDal = profileDal;
        }

        public IResult AddProfile(Profile profile)
        {
            _profileDal.Add(profile);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult DeleteUpdate(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Profile> GetProfileById(int profileId)
        {
            return new IResult<Profile>(_profileDal.Get(p => p.ProfileId == profileId));
        }

        public IResult UpdateProfile(Profile user)
        {
            throw new NotImplementedException();
        }
    }
}
