using LojaDesafio.Model;
using LojaDesafio.Model.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDesafio.Business
{
    public class ProductBusiness
    {
        public IList<Product> Select()
        {
            using (var db = new Context())
            {
                return db.Products.ToList();
            }
        }

        public Product SelectById(int id)
        {
            using (var db = new Context())
            {
                return db.Products.FirstOrDefault(p => p.Id == id);
            }
        }

        public Product Save(Product product)
        {
            using (var db = new Context())
            {
                if (product.Id > 0)
                {
                    var existingProduct = this.SelectById(product.Id);

                    existingProduct.Description = product.Description;
                    existingProduct.Name = product.Name;
                    existingProduct.Price = product.Price;
                }
                else
                {
                    db.Products.Add(product);
                }

                db.SaveChanges();
            }

            return product;
        }
    }
}
