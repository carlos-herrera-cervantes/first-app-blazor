using Microsoft.AspNetCore.Mvc;
using SPAWithBlazor.Server.DataAccess;
using SPAWithBlazor.Shared.Models;
using System.Collections.Generic;

namespace SPAWithBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    public class CitiesController : Controller
    {
        CitiesRepository _citiesRepository = new CitiesRepository();

        /// <summary>
        /// GET
        /// </summary>
        #region snippet_GetAll
        [HttpGet]
        public IEnumerable<Cities> GetAll() => _citiesRepository.GetAll();
        #endregion
    }
}