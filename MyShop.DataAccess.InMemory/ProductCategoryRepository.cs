using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
   public class ProductCategoryRepository
   {
      ObjectCache cache = MemoryCache.Default;
      List<ProductCategory> productCategories = new List<ProductCategory>();

      public ProductCategoryRepository()
      {
         productCategories = cache["ProductCategories"] as List<ProductCategory>;

         if (productCategories == null)
         {
            productCategories = new List<ProductCategory>();
         }
      }

      public void Commit()
      {
         cache["ProductCategories"] = productCategories;
      }

      public void Insert(ProductCategory p)
      {
         productCategories.Add(p);
      }

      public void Update(ProductCategory productCategory)
      {
         ProductCategory productCategoryToUpdate = productCategories.Find(p => p.Id == productCategory.Id);

         if (productCategoryToUpdate != null)
         {
            productCategoryToUpdate = productCategory;
         }
         else
         {
            throw new Exception("Product Category is not found");
         }
      }

      public ProductCategory Find(string Id)
      {
         ProductCategory productCategorytoFind = productCategories.Find(p => p.Id == Id);

         if (productCategorytoFind != null)
         {
            return productCategorytoFind;
         }
         else
         {
            throw new Exception("Product not found");
         }
      }

      public IQueryable<ProductCategory> Collection()
      {
         return productCategories.AsQueryable();
      }

      public void delete(string Id)
      {
         ProductCategory productCategoryToDelete = productCategories.Find(p => p.Id == Id);

         if (productCategoryToDelete != null)
         {
            productCategories.Remove(productCategoryToDelete);
         }
         else
         {
            throw new Exception("Product Category not found");
         }

      }


   }

}
