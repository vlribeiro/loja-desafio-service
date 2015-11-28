using LojaDesafio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LojaDesafio.Web.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILojaDesafio" in both code and config file together.
    [ServiceContract]
    public interface ILojaDesafio
    {
        [OperationContract]
        [WebGet(RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Product/{id}")]
        Product GetProduct(string id);

        [OperationContract]
        [WebInvoke(Method ="POST",RequestFormat =WebMessageFormat.Json,ResponseFormat =WebMessageFormat.Json,UriTemplate ="/Product")]
        Product PostProduct(Product product);

        [OperationContract]
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, UriTemplate = "/Transaction")]
        Transaction PostTransaction(Transaction transaction);
    }
}
