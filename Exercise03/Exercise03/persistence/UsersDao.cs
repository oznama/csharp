using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Exercise03.model;

namespace Exercise03.persistence
{
    class UsersDao : BaseDao, IUsersDao
    {      
        public bool Delete(int id)
        {
            query = "DELETE FROM users WHERE id=@id";
            @params = new Dictionary<string, object>
            {
                {"@id",id}
            };
            return base.Execute();
        }

        public IList<Users> FindAll()
        {
            query = "SELECT id,username,pswd,fullname FROM users";
            IList<Users> users= new List<Users>();
            ArrayList result = base.SelectQuery();
            Users user;
            foreach (object[] r in result)
            {
                user = new Users
                {
                    Id = (int)r[0],
                    UserName = (string)r[1],
                    Pswd = (string)r[2],
                    FullName = (string)r[3]
                };
                users.Add(user);
            }
            return users;
        }

        public Users FindById(int id)
        {
            query = "SELECT id,username,pswd,fullname FROM users WHERE id=@id";
            @params = new Dictionary<string, object>
            {
                {"@id",id}
            };
            try
            {
                object[] result =(object[])base.SelectQuery()[0];
                Users user = new Users()
                {
                    Id = (int)result[0],
                    UserName = (string)result[1],
                    Pswd=(string)result[2],
                    FullName=(string)result[3]
                };
                return user;
            }
            catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Usuario con ID: {0} no encontrado", id);
            }
            return null;
        }

        public bool Save(Users users)
        {
            query = "INSERT INTO users (username,pswd,fullname) VALUES (@userName,@pswd,@fullName)";
            @params = new Dictionary<string, object>
            {
                {"@userName", users.UserName},
                {"@pswd", users.Pswd},
                {"@fullName", users.FullName}
            };
            return base.Execute();
        }

        public bool Update(Users users)
        {
            query = "UPDATE users SET username=@userName,pswd=@pswd,fullname=@fullName WHERE id=@id";
            @params = new Dictionary<string, object>
            {
                {"@id",users.Id},
                {"@userName",users.UserName},
                {"@pswd",users.Pswd},
                {"@fullName",users.FullName}
            };
            return base.Execute();
        }
    }
}
