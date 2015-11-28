using LojaDesafio.Model.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDesafio.Business
{
    public class GenericBusiness<T> where T : class
    {
        public Context Context { get; set; }

        public GenericBusiness(Context context)
        {
            this.Context = context;
        }
    }
}
