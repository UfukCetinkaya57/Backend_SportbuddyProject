using CoreLayer.Entities.Concerete;
using CoreLayer.Utilities.Results;
using CoreLayer.Utilities.Security.JWT;
using EntityLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IDataResult<AccessToken> CreateAccessToken(User user);
        IResult UserExists(string Email);
       /* 
        IResult Update(User user);

        IResult Delete(int id);
       */

    }
}
