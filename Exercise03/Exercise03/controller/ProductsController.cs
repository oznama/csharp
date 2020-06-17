using Exercise03.model;
using Exercise03.persistence;


namespace Exercise03.controller
{
    class ProductsController
    {
        private IProductsDao productsDao;

        public bool Save(string nombre, string description, string shortName, decimal price,int stack)
        {
            productsDao = new ProductsDao();
            return productsDao.Save(new Products(0,nombre,description,shortName,price,stack));           
        }

        public bool Update(int id, string name,string description,string shortName, decimal price, int stack)
        {
            productsDao = new ProductsDao();
            return productsDao.Update(new Products(id,name,description,shortName,price,stack));
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
                return productsDao.FindAll();
            }
            else if(id>0)
            {
                return productsDao.FindById(id);
            }
            else
            {
                return null;
            }
        }

    }
}
