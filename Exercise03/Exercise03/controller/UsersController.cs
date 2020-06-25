using Exercise03.persistence;
using Exercise03.model;
using Exercise03.dto;

using System.Collections;

namespace Exercise03.controller
{
    class UsersController
    {
        private IUsersDao userDao;
        private ClientsController clientController;

        public bool Save(UserDto userDto)
        {
            userDao = new UsersDao();
            return userDao.Save(new Users(0,userDto.UserName,userDto.Pswd,userDto.FullName));
        }
        public bool Update(UserDto userDto)
        {
            userDao = new UsersDao();
            return userDao.Update(new Users(userDto.Id,userDto.UserName,userDto.Pswd,userDto.FullName));
        }
        public bool Delete(int id)
        {
            userDao = new UsersDao();
            return userDao.Delete(id);

        }

        public UserDto GetById(int id) {
            userDao = new UsersDao();
            Users user = userDao.FindById(id);
            return new UserDto(user.Id, user.UserName, user.Pswd, user.FullName);
        }

        public ArrayList GetAll() {
            ArrayList list = new ArrayList();
            userDao = new UsersDao();
            ArrayList listBD = userDao.FindAll();
            foreach (Users u in listBD) {
                list.Add( new UserReadDto(u.Id, u.UserName, u.FullName) );
            }
            return list;
        }

        public UserClientsDto GetUserWithClientsCreated(int id) {
            clientController = new ClientsController();
            UserClientsDto userClientsDto = new UserClientsDto
            {
                UserDto = GetById(id),
                MyClients = clientController.FindByUser(id)
            };
            return userClientsDto;
        }
    }
}
