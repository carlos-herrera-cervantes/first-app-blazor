using SPAWithBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPAWithBlazor.Server.DataAccess
{
    public class CitiesRepository
    {
        private SPAWithBlazorContext _context = new SPAWithBlazorContext();

        #region snippet_GetAllCities
        public IEnumerable<Cities> GetAll()
        {
            try
            {
                return _context.Cities.ToList();
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}
