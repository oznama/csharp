using Exercise03.persistence;
using Exercise03.model;

namespace Exercise03.controller
{
    class UsersController
    {
        private IUsersDao userDao;

        public bool Save(string userName, string pswd, string fullName)
        {
            userDao = new UsersDao();
            return userDao.Save(new Users(0,userName,pswd,fullName));
        }
        public bool Update(int id, string userName, string pswd, string fullName)
        {
            userDao = new UsersDao();
            return userDao.Update(new Users(id,userName,pswd,fullName));
        }
        public bool Delete(int id)
        {
            userDao = new UsersDao();
            return userDao.Delete(id);

        }
        public object Consult(int id)
        {
            userDao = new UsersDao();
            if (id == 0)
            {
                return userDao.FindAll();
            }else if (id > 0)
            {
                return userDao.FindById(id);
            }
            else
            {
                return null;
            }
        }
    }
}
