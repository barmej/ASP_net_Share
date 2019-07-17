using Share.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Business
{
  public  class UserRepository
    {
        public List<User> GetAllUsers()
        {
            ShareDBEntities context = new ShareDBEntities();
            List<User> users = context.Users.ToList();
            return users;
        }
        public User GetUserById(int id)
        {
            ShareDBEntities context = new ShareDBEntities();
            User user = context.Users.Find(id);
            return user;
        }
        public User GetUserByUserId(String id)
        {
            ShareDBEntities context = new ShareDBEntities();
            User user = context.Users.Where(p => p.user_id == id).FirstOrDefault();
            return user;
        }
        public void Add(User user)
        {
            ShareDBEntities context = new ShareDBEntities();
            context.Users.Add(user);
            context.SaveChanges();

        }
        public void Delete(int id)
        {
            ShareDBEntities context = new ShareDBEntities();
            User user = context.Users.Find(id);
            context.Users.Remove(user);
            context.SaveChanges();
        }

        public void Update(User User)
        {
            ShareDBEntities context = new ShareDBEntities();
            User oldUser = context.Users.Find(User.id);
            context.Entry(oldUser).CurrentValues.SetValues(User);
            context.SaveChanges();
        }
    }
}

