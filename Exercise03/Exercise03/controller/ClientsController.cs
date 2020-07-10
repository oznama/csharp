using Exercise03.dto;
using Exercise03.model;
using Exercise03.persistence;
using System.Collections.Generic;

namespace Exercise03.controller
{
    class ClientsController
    {
        private IClientsDao clientDao;

        public bool Create(ClientCreateDto clientDto)
        {
            clientDao = new ClientsDao();
            return clientDao.Save(new Clients (clientDto.Name,clientDto.Address,clientDto.Phone,clientDto.UserId));
        }

        public bool Update(ClientUpdateDto clientDto)
        {
            clientDao = new ClientsDao();
            return clientDao.Update(new Clients(clientDto.ID,clientDto.Name,clientDto.Address,clientDto.Phone,clientDto.UserId,clientDto.CreateDate));
        }

        public IList<ClientReadDto> FindByUser(int id)
        {
            IList<ClientReadDto> listDto = new List<ClientReadDto>();
            clientDao = new ClientsDao();
            IList<Clients> listC = clientDao.FindByUser(id);
            foreach(Clients c in listC)
            {
                listDto.Add(new ClientReadDto(c.ID, c.Name, c.Address, c.Phone, c.CreatedDate));
            }

            return listDto;
        }
    }
}
