using LojaDesafio.Model;
using LojaDesafio.Model.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDesafio.Business
{
    public class ProductBusiness : GenericBusiness<Product>
    {
        public ProductBusiness(Context context) : base(context) { }

        public IList<Product> Select()
        {
            using (this.Context)
            {
                return this.Context.Products.ToList();
            }
        }

        public Product SelectById(int id)
        {
            using (this.Context)
            {
                return this.Context.Products.FirstOrDefault(p => p.Id == id);
            }
        }

        public Product Save(Product product)
        {
            using (this.Context)
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
                    this.Context.Products.Add(product);
                }

                this.Context.SaveChanges();
            }

            return product;
        }
    }
}
