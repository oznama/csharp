using Exercise03.dto;
using Exercise03.model;
using Exercise03.persistence;
using System.Collections.Generic;

namespace Exercise03.controller
{
    class SalesController
    {
        private ISalesDao salesDao;
        private ISalesItemDao salesItemDao;

        public bool DoSale(SaleCreateDto saleCreateDto)
        {
            salesDao = new SalesDao();
            salesItemDao = new SalesItemDao();

            // Registrar la venta
            Sales sale = new Sales(saleCreateDto.UserId, saleCreateDto.Total, saleCreateDto.ClientId, saleCreateDto.Trusted ? (byte) 1 : (byte) 0 );
            int saleId = salesDao.Save(sale);
            if ( saleId > 0 )
            {
                foreach( SaleItemCreateDto i in saleCreateDto.ProductList)
                {
                    SalesItem si = new SalesItem(i.ProductId, saleId, i.Quantity);
                    salesItemDao.Save(si);
                }
            }
            
            return false;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="option"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public IList<SaleReadDto> Searchs(short option, int id)
        {
            salesDao = new SalesDao();
            salesItemDao = new SalesItemDao();
            IList<Sales> sales = new List<Sales>();
            switch(option){
                case 1:
                    // User
                    sales = salesDao.FindByUserId(id);
                    break;
                case 2:
                    // Client
                    sales = salesDao.FindByClientId(id);
                    break;
                default:
                    // All
                    sales = salesDao.FindAll();
                    break;
            }
            IList<SaleReadDto> salesDto = new List<SaleReadDto>();
            SaleReadDto saleDto;
            IList<SalesItem> items;
            foreach(Sales s in sales)
            {
                saleDto = new SaleReadDto(s.Id, s.SaleDate, s.UserId, s.SaleTotal, s.ClientId, s.Trusted == 1 ? true : false);
                items = salesItemDao.FindBySaleId(s.Id);
                foreach( SalesItem i in items)
                {
                    saleDto.ProductList.Add(new SaleItemCreateDto(i.ProductId, i.SaleId, i.Quantity));
                }
                salesDto.Add(saleDto);
            }

            return salesDto;
        }
    }
}
