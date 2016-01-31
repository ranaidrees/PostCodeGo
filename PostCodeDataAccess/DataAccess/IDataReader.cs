using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using PostCodeDataAccess.Models;
using PostCodeDataAccess.Models.General;
using System.Collections.Generic;

namespace PostCodeDataAccess.DataAccess
{
    public interface IDataReader<T>
    {
        Task<T> GetDetailsAsync(string outCode);
    }

   
   
}
