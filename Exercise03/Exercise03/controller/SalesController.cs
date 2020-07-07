using Exercise03.dto;
using Exercise03.model;
using Exercise03.persistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

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
                foreach( SaleItemDto i in saleCreateDto.ProductList)
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
        public ArrayList Searchs(short option, int id)
        {
            salesDao = new SalesDao();
            salesItemDao = new SalesItemDao();
            ArrayList sales = new ArrayList();
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
            ArrayList salesDto = new ArrayList();
            SaleReadDto saleDto;
            ArrayList items;
            foreach(Sales s in sales)
            {
                saleDto = new SaleReadDto(s.Id, s.SaleDate, s.UserId, s.SaleTotal, s.ClientId, s.Trusted == 1 ? true : false);
                items = salesItemDao.FindBySaleId(s.Id);
                foreach( SalesItem i in items)
                {
                    saleDto.ProductList.Add(new SaleItemDto(i.ProductId, i.SaleId, i.Quantity));
                }
                salesDto.Add(saleDto);
            }

            return salesDto;
        }
    }
}
