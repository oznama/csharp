using Exercise03.model;
using Exercise03.persistence;
using Exercise03.dto;
using System.Collections;


namespace Exercise03.controller
{
    class ProductsController
    {
        private IProductsDao productsDao;

        public bool Create(ProductsCreateDto productsDto)
        {
            productsDao = new ProductsDao();
            return productsDao.Save(new Products(productsDto.Name,productsDto.Description,productsDto.ShortName,productsDto.Price,productsDto.Stack));           
        }

        public bool Update(ProductsUpdateDto productsDto)
        {
            productsDao = new ProductsDao();
            return productsDao.Update(new Products(productsDto.Id,productsDto.Name,productsDto.Description,productsDto.ShortName,productsDto.Price,productsDto.Stack));
        }

        public bool Delete(int id)
        {
            productsDao = new ProductsDao();
            return productsDao.Delete(id);
        }

        public object Consult(int id)
        {
            productsDao = new ProductsDao();

            if (id == 0)
            {
                ArrayList products= new ArrayList();
                ArrayList result = productsDao.FindAll();

                foreach (Products p in result)
                {
                    products.Add(new ProductsReadDto(p.Id,p.Name,p.Description,p.ShortName,p.Price,p.Stack));
                }
                return products;        
            }
            else if(id>0)
            {
                Products products= productsDao.FindById(id);
                return new ProductsReadDto(products.Id,products.Name,products.Description,products.ShortName,products.Price,products.Stack);
            }
            else
            {
                return null;
            }
        }

    }
}
