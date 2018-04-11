using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibr.Service
{
    public class UserService
    {
        public void Create(User item)
        {
            using (Cloud9Model context = new Cloud9Model())
            {
                context.Users.Add(item);
                context.SaveChanges();
            }
        }

        public List<User> SelectAll()
        {
            List<User> temp;
            using (Cloud9Model context = new Cloud9Model())
            {
                temp = context.Users.ToList();
            }
            return temp;
        }

        public User Select(int id)
        {
            User result = new User();
            using (Cloud9Model context = new Cloud9Model())
            {
                List<User> temp = context.Users.ToList();
                for (int i = 0; i < temp.Count; i++)
                {
                    if (temp[i].Id == id)
                    {
                        result = temp[i];
                    }
                }
            }
            return result;
        }

        public void Update(User product)
        {
            using (Cloud9Model context = new Cloud9Model())
            {
                context.Entry(product).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            User result = new User();
            using (Cloud9Model context = new Cloud9Model())
            {
                List<User> temp = context.Users.ToList();
                for (int i = 0; i < temp.Count; i++)
                {
                    if (temp[i].Id == id)
                    {
                        context.Users.Remove(temp[i]);
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
