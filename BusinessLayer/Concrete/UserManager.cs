using BusinessLayer.Abstract;
using BusinessLayer.Constants;
using CoreLayer.Entities.Concerete;
using CoreLayer.Utilities.Results;
using CoreLayer.Utilities.Security.Hashing;
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
    public class UserManager: IUserService
    {
        IUserDal _userDal;
        IMessageDal _messageDal;
        IActivityDal _activityDal;

        public UserManager(IUserDal userDal, IMessageDal messageDal,IActivityDal activityDal)
        {
            _userDal = userDal;
            _messageDal = messageDal;
            _activityDal = activityDal;
           

        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public User GetByEmail(string Email)
        {
            return _userDal.Get(filter: u => u.Email == Email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
        public IDataResult<User> GetById(int Id)
        {
            var user = _userDal.Get(p => p.Id == Id);


            string directoryPath = Path.Combine("C:\\Users\\emirg\\OneDrive\\Masaüstü\\SportBuddyProject\\SportBuddyWebAPI\\Upload\\Photos\\" + user.Id + "\\UserPhoto");

            if (user.PhotoPath != null)
            {
                if (Directory.Exists(directoryPath))
                {
                    byte[] photoBytes = File.ReadAllBytes(user.PhotoPath);
                    user.PhotoBase64 = Convert.ToBase64String(photoBytes);
                }
            }


            return new IResult<User>(user);
        }
        public IDataResult<List<User>> GetList()
        {
            return new IResult<List<User>>(_userDal.GetList().ToList());
        }
        public IResult UpdateUser(User user, string password)
        {

            if (user.PhotoBase64 != null && user.PhotoBase64 != "string")
            {
                byte[] photoBytes = Convert.FromBase64String(user.PhotoBase64);

                // Kullanıcının fotoğrafını belirlediğiniz klasöre kaydet
                string photoFileName = user.Id + ".jpg"; // Fotoğraf dosya adını oluştur
                                                         //LİNKLERE DOĞRU BAKACAKSIN EN SON İŞLEMLERDE

                var userDirectory = Path.Combine("C:\\Users\\emirg\\OneDrive\\Masaüstü\\SportBuddyProject\\SportBuddyWebAPI\\Upload\\Photos\\" + user.Id + "\\UserPhoto");
                // Kullanıcının alt klasörünün var olup olmadığını kontrol edin; yoksa oluşturun
                if (!Directory.Exists(userDirectory))
                {
                    // Klasörü oluşturun
                    Directory.CreateDirectory(userDirectory);
                }
                // Dosyanın kaydedileceği tam yolu oluşturun
                var photoPath = Path.Combine(userDirectory, photoFileName);
                user.PhotoPath= photoPath;
                System.IO.File.WriteAllBytes(photoPath, photoBytes); // Byte dizisini dosyaya yaz
            }
            if(password != null)
            {
                byte[] passwdHash, passwdSalt;
                HashingHelper.CreatePasswordHash(password, out passwdHash, out passwdSalt);
                user.PasswdHash = passwdHash;
                user.PasswdSalt = passwdSalt;
            }
            
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
        public IResult DeleteUser(User user)
        {
            var messsages = new List<Message>();
            var activities = new List<Activity>();

            messsages = _messageDal.GetList(m => m.UserId == user.Id).ToList();

            foreach (var message in messsages)
            {

                _messageDal.Delete(message);
            }

            activities = _activityDal.GetList().ToList();
            foreach (var activity in activities)
            {
                var activityUsersIdList = JsonConvert.DeserializeObject<List<int>>(activity.UsersIdList);
                if (activityUsersIdList.First() == user.Id)
                {
                    _activityDal.Delete(activity);
                    
                }

                else
                {
                    if (activityUsersIdList.Contains(user.Id))
                    {
                        activityUsersIdList.Remove(user.Id);
                        activity.UsersIdList= JsonConvert.SerializeObject(activityUsersIdList);                      
                        _activityDal.Update(activity);

                    }
                }

            }

           
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserUpdated);
        }

    }
}
