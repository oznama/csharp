using Exercise03.dto;
using Exercise03.model;
using Exercise03.persistence;
using System;
using System.Collections;
using System.Text;

namespace Exercise03.controller
{
    class ClientsController
    {
        private IClientsDao clientDao;

        public bool Create(ClientCreateDto clientDto)
        {
            // TODO: Impl
            return false;
        }

        public bool Update(ClientUpdateDto clientDto)
        {
            // TODO: Impl
            return false;
        }

        public ArrayList FindByUser(int id)
        {
            ArrayList listDto = new ArrayList();
            clientDao = new ClientsDao();
            ArrayList listC = clientDao.FindByUser(id);
            foreach(Clients c in listC)
            {
                listDto.Add(new ClientReadDto(c.ID, c.Name, c.Address, c.Phone, c.CreatedDate));
            }

            return listDto;
        }
    }
}
