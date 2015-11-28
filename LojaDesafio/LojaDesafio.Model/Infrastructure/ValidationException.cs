using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaDesafio.Model.Infrastructure
{
    public class ValidationException : Exception
    {
        public IList<string> Errors { get; set; }

        public ValidationException(IList<string> errors)
        {
            this.Errors = errors;
        }

        public ValidationException(string error)
        {
            this.Errors = new List<string>();
            this.Errors.Add(error);
        }
    }
}
