﻿using System.Collections.Generic;
using ProjectNA.Core.DTOs.Order;
using ProjectNA.DataLayer.Entities.Order;

namespace ProjectNA.Core.Services.Interfaces
{
    public interface IOrderService
    {
        int AddOrder(string userName, int clothesId);

        void UpdatePriceOrder(int orderId);
        Order GetOrderForUserPanel(string userName, int orderId);

        bool FinalyOrder(string userName, int orderId);
        List<Order> GetUserOrders(string userName);

        void UpdateOrder(Order order);
        Order GetOrderById(int orderId);
        #region DisCount

        DiscountUseType UseDiscount(int orderId, string code);
        void AddDiscount(Discount discount);
        List<Discount> GetAllDiscounts();
        Discount GetDiscountById(int discountId);
        void UpdateDiscount(Discount discount);
        bool IsExistCode(string code);

        #endregion
    }
}