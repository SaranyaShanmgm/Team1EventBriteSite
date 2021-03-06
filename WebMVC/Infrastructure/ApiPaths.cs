﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Infrastructure
{
    public class ApiPaths
    {
        public static class Event
        {
            public static string GetAllEventItems(string baseUri, int page, int take,int? type,int? category,int?location, int?price)
            {
                var filterQs = string.Empty;
                if(type.HasValue || category.HasValue || location.HasValue || price.HasValue)
                {
                    var categoryQs = (category.HasValue) ? category.Value.ToString() : "0";
                    var typeQs = (type.HasValue) ? type.Value.ToString() : "0";
                    var locationQs = (location.HasValue) ? location.Value.ToString() : "0";
                    var priceQs = (price.HasValue) ? price.Value.ToString() : "0";

                    filterQs = $"/type/{typeQs}/category/{categoryQs}/location/{locationQs}/price/{priceQs}";
                }
                return $"{baseUri}items{filterQs}?pageIndex={page}&pageSize={take}";
            }

            public static string GetAllTypes(string baseUri)
            {
                return $"{baseUri}eventtypes";
            }

            public static string GetAllCategories(string baseUri)
            {
                return $"{baseUri}eventcategories";
            }

            public static string GetAllLocations(string baseUri)
            {
                return $"{baseUri}eventlocations";
            }

            public static string GetAllPrices(string baseUri)
            {
                return $"{baseUri}eventprices";
            }
        }


        public static class Basket
        {
            public static string GetBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }

            public static string UpdateBasket(string baseUri)
            {
                return baseUri;
            }

            public static string CleanBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }
        }

        public static class Order
        {
            public static string GetOrder(string baseUri, string orderId)
            {
                return $"{baseUri}/{orderId}";
            }

            //public static string GetOrdersByUser(string baseUri, string userName)
            //{
            //    return $"{baseUri}/userOrders?userName={userName}";
            //}
            public static string GetOrders(string baseUri)
            {
                return baseUri;
            }
            public static string AddNewOrder(string baseUri)
            {
                return $"{baseUri}/new";
            }
        }
    }
}
