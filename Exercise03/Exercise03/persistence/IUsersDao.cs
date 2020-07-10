using System;
using System.Collections.Generic;
using System.Text;
using Exercise03.model;

namespace Exercise03.persistence
{
    interface IUsersDao
    {
        bool Save(Users users);
        bool Update(Users users);
        bool Delete(int id);
        Users FindById(int id);
        IList<Users> FindAll(); 
    }
}
