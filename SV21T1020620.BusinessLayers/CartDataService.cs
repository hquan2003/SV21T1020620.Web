﻿using SV21T1020620.DataLayers.SQLServer;
using SV21T1020620.DataLayers;
using SV21T1020620.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SV21T1020620.BusinessLayers
{
    public static class CartDataService
    {
        private static readonly ICartDAL cartDB;

        static CartDataService()
        {
            cartDB = new CartDAL(Configuration.ConnectionString);
        }
        public static int AddCart(Cart Cart)
        {
            return cartDB.Add(Cart);
        }
        public static int AddCartDetail(Cartdetail data)
        {
            return cartDB.AddCartDetail(data);
        }
        public static int Count(int customerID)
        {
            return cartDB.Count(customerID);
        }
        public static Cart getCartByCustomerID(int customerID)
        {
            return cartDB.Get(customerID);
        }
        public static Cartdetail checkProductExists(int CartID, int productID)
        {
            return cartDB.checkProductExists(CartID, productID);
        }
        public static bool SaveCartdetail(int CartID, int ProductID, int Quantity)
        {
            return cartDB.SaveDetail(CartID, ProductID, Quantity);
        }
        public static bool SaveCart(Cart Cart)
        {
            return cartDB.Update(Cart);
        }
    }
}
