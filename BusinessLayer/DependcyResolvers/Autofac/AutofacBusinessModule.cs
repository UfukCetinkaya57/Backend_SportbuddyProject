using Autofac;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using CoreLayer.Utilities.Security.JWT;
using DataAccessLayer;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DependcyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            /* builder.RegisterType<ProductManager>().As<IProductService>();
             builder.RegisterType<EfProductDal>().As<IProductDal>();

             builder.RegisterType<ProductCategoryManager>().As<IProductCategoryService>();
             builder.RegisterType<EfProductCategoryDal>().As<IProductCategoryDal>();
            */

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<ProfileManager>().As<IProfileService>();
            builder.RegisterType<ActivityManager>().As<IActivityService>();
            builder.RegisterType<JoinTheActivityManager>().As<IJoinTheActivityService>();
            builder.RegisterType<MessageManager>().As<IMessageService>();
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<ProductCategoryManager>().As<IProductCategoryService>();


            builder.RegisterType<EfJoinTheActivityDal>().As<IJoinTheActivityDal>();
            builder.RegisterType<EfEventDal>().As<IActivityDal>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<EfProfileDal>().As<IProfileDal>();
            builder.RegisterType<EfMessageDal>().As<IMessageDal>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();
            builder.RegisterType<EfProductCategoryDal>().As<IProductCategoryDal>();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
        }
    }
}
