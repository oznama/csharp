using System;
using System.Collections;
using System.Text;
using Exercise03.persistence;
using Exercise03.dto;
using Exercise03.model;

namespace Exercise03.controller
{
    class ProvidersController
    {
        private IProvidersDao providersDao;

        public bool Create (ProvidersCreateDto providersDto)
        {
            providersDao = new ProvidersDao();
            return providersDao.Save(new Providers(providersDto.Name, providersDto.Description, providersDto.UserId));          
        }
        public bool Update(ProvidersUpdateDto providersDto)
        {
            providersDao = new ProvidersDao();
            return providersDao.Update(new Providers(providersDto.Id, providersDto.Name, providersDto.Description, providersDto.CreatedDate, providersDto.UserId));
        } 
        public bool Delete(int id)
        {
            providersDao = new ProvidersDao();
            return providersDao.Delete(id);
        }
        public object Consult (int id)
        {
            providersDao = new ProvidersDao();

            if (id == 0)
            {
                ArrayList r = new ArrayList();
                ArrayList rm = providersDao.FindAll();
                foreach(Providers p in rm)
                {
                    r.Add(new ProvidersReadDto(p.Id, p.Name, p.Description, p.CreatedDate, p.UserId));
                }
                return r;
            }
            else if (id > 0)
            {
                Providers provider = providersDao.FindById(id);
                return new ProvidersReadDto(provider.Id, provider.Name, provider.Description, provider.CreatedDate, provider.UserId);
            }
            else
            {
                return null;
            }

        }
    }
}
