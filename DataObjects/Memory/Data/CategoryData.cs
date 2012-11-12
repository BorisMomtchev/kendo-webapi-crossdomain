using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects;

namespace DataObjects
{
    public class CategoryData
    {
        public static List<Category> GetData()
        {
            List<Category> list = new List<Category>();

            list.Add(new Category() { Id = 1, CategoryName = "Household Items" });
            list.Add(new Category() { Id = 2, CategoryName = "Sporting Goods" });
            list.Add(new Category() { Id = 3, CategoryName = "Electronics" });

            return list;
        }
    }
}
