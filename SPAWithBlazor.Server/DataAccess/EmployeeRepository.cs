using Microsoft.EntityFrameworkCore;
using SPAWithBlazor.Shared.Models;
using System.Collections.Generic;
using System.Linq;

namespace SPAWithBlazor.Server.DataAccess
{
    public class EmployeeRepository
    {
        private SPAWithBlazorContext _context = new SPAWithBlazorContext();

        /// <summary>
        /// GET
        /// </summary>
        #region snippet_GetAll
        public IEnumerable<Employee> GetAll()
        {
            try
            {
                return _context.Employee.ToList();
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region snippet_GetById
        public Employee GetById(int id)
        {
            try
            {
                var employee = _context.Employee.Find(id);
                return employee;
            }
            catch
            {
                throw;
            }
        }
        #endregion

        /// <summary>
        /// POST
        /// </summary>
        #region snippet_Create
        public void Create(Employee employee)
        {
            try
            {
                _context.Employee.Add(employee);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        #endregion

        /// <summary>
        /// PUT
        /// </summary>
        #region snippet_Update
        public void Update(Employee employee)
        {
            try
            {
                _context.Entry(employee).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        #endregion

        /// <summary>
        /// DELETE
        /// </summary>
        #region snippet_Delete
        public void Delete(int id)
        {
            try
            {
                var employee = _context.Employee.Find(id);
                _context.Employee.Remove(employee);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        #endregion
    }
}