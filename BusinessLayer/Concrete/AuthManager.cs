using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using CoreLayer.Entities.Concerete;
using CoreLayer.Utilities.Results;
using CoreLayer.Utilities.Security.Hashing;
using CoreLayer.Utilities.Security.JWT;
using EntityLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AuthManager: IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;
        public AuthManager(ITokenHelper tokenHelper, IUserService userService)
        {
            _tokenHelper = tokenHelper;
            _userService = userService;
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new IResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwdHash, passwdSalt;

            HashingHelper.CreatePasswordHash(password, out passwdHash, out passwdSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                UserName = userForRegisterDto.UserName,
                PasswdHash = passwdHash,
                PasswdSalt = passwdSalt,
                Roles= userForRegisterDto.Roles,
                JoinTheActivitesIdList = null,

        //   Status = true
            };

            // Base64 formatındaki fotoğrafı byte dizisine dönüştür



            _userService.Add(user);

            byte[] photoBytes = Convert.FromBase64String(userForRegisterDto.PhotoBase64);

            // Kullanıcının fotoğrafını belirlediğiniz klasöre kaydet
            string photoFileName = user.Id + ".jpg"; // Fotoğraf dosya adını oluştur
                                                            //LİNKLERE DOĞRU BAKACAKSIN EN SON İŞLEMLERDE
            var userDirectory = Path.Combine("C:\\Users\\Ufuk\\Desktop\\SportBuddyProject\\SportBuddyWebAPI\\Upload\\User\\Photos\\" + user.Id + "\\UserPhoto");
            // Kullanıcının alt klasörünün var olup olmadığını kontrol edin; yoksa oluşturun
            if (!Directory.Exists(userDirectory))
            {
                // Klasörü oluşturun
                Directory.CreateDirectory(userDirectory);
            }
            // Dosyanın kaydedileceği tam yolu oluşturun
            var photoPath = Path.Combine(userDirectory, photoFileName);
            System.IO.File.WriteAllBytes(photoPath, photoBytes); // Byte dizisini dosyaya yaz

            user.PhotoPath = photoPath;
            _userService.UpdateUser(user);

            return new IResult<User>(user, Messages.UserRegistered);
        }
        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByEmail(userForLoginDto.UserName);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            if (!HashingHelper.VerifyPasswdHash(userForLoginDto.Passwd, userToCheck.PasswdHash, userToCheck.PasswdSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }
            return new IResult<User>(userToCheck, Messages.SuccessfulLogin);
        }
        public IResult UserExists(string email)
        {
            if (_userService.GetByEmail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        
        /*public IResult Update(JoinTheActivity joinTheActivity)
        {
            _joinTheActivityDal.Update(joinTheActivity);
            return new SuccessResult(Messages.ProductCategoryUpdated);
        }
        public IResult Delete(int id)
        {
            JoinTheActivity joinTheActivity = _joinTheActivityDal.Get(p => p.JoinActivityId == id);
            _joinTheActivityDal.Delete(joinTheActivity);
            return new SuccessResult(Messages.ProductDeleted);
        }*/
    }
}