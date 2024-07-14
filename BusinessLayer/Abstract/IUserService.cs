using CoreLayer.Entities.Concerete;
using CoreLayer.Utilities.Results;
using EntityLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IUserService
    {
        IDataResult<User> GetById(int Id);
        List<OperationClaim> GetClaims(User user);
        User GetByEmail(string Email);
        IDataResult<List<User>> GetList();
        IResult Add(User user);
        IResult UpdateUser(User user, string password=null);
        IResult DeleteUser(User user);
        // IResult Delete(int id);

    }
}
