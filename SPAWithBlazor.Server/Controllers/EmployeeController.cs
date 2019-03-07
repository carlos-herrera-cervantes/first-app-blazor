using Microsoft.AspNetCore.Mvc;
using SPAWithBlazor.Server.DataAccess;
using SPAWithBlazor.Shared.Models;
using System.Collections.Generic;

namespace SPAWithBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        EmployeeRepository _employeeRepository = new EmployeeRepository();

        /// <summary>
        /// GET
        /// </summary>
        #region snippet_GetAll
        [HttpGet]
        public IEnumerable<Employee> GetAll() => _employeeRepository.GetAll();
        #endregion

        #region snippet_GetById
        [HttpGet("{id}")]
        public Employee Get(int id) => _employeeRepository.GetById(id);
        #endregion

        /// <summary>
        /// POST
        /// </summary>
        #region snippet_Create
        [HttpPost]
        public void Post([FromBody]Employee employee) => _employeeRepository.Create(employee);
        #endregion

        /// <summary>
        /// PUT
        /// </summary>
        #region snippet_Update
        [HttpPut]
        public void Update(Employee employee) => _employeeRepository.Update(employee);
        #endregion

        /// <summary>
        /// DELETE
        /// </summary>
        #region snippet_Update
        [HttpDelete("{id}")]
        public void Delete(int id) => _employeeRepository.Delete(id);
        #endregion
    }
}
