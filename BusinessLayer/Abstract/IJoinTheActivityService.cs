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
    public interface IJoinTheActivityService
    {
        IResult AddJoinTheActivity(JoinTheActivity JoinTheActivity);
        IResult Update(JoinTheActivity JoinTheActivity);

        IResult Delete(int id);


    }
}
