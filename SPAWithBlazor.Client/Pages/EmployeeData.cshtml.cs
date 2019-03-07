using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using SPAWithBlazor.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SPAWithBlazor.Client.Pages
{
    public class EmployeeDataModel : BlazorComponent
    {
        [Inject]
        protected HttpClient Client { get; set; }
        protected string ModalTitle { get; set; }
        protected string SearchString { get; set; }

        protected Employee _employee = new Employee();
        protected List<Employee> _listEmployee = new List<Employee>();
        protected List<Cities> _listCities = new List<Cities>();

        #region snippet_OnInit
        protected override async Task OnInitAsync()
        {
            await GetAllEmployees();
            await GetAllCities();
        }
        #endregion

        /// <summary>
        /// HELPERS
        /// </summary>
        #region snippet_AddEmployee
        protected void AddEmployee()
        {
            _employee = new Employee();
            this.ModalTitle = "Add employee";
        }
        #endregion

        #region snippet_EditEmployee
        protected async Task EditEmployee(int id)
        {
            _employee = await Client.GetJsonAsync<Employee>("/api/Employee/" + id);
            this.ModalTitle = "Edit employee";
        }
        #endregion

        #region snippet_DeleteConfirm
        protected async Task DeleteConfirm(int id) => _employee = await Client.GetJsonAsync<Employee>("/api/Employee/" + id);
        #endregion

        #region snippet_SearchEmployee
        protected async Task SearchEmploye()
        {
            await GetAllEmployees();

            if (SearchString != string.Empty)
            {
                _listEmployee = _listEmployee.Where(x => x.EmployeeName.IndexOf(SearchString, StringComparison.OrdinalIgnoreCase) != -1).ToList();
            }
        }
        #endregion

        /// <summary>
        /// POST OR PUT
        /// </summary>
        #region snippet_CreateEmployee
        protected async Task CreateEmployee()
        {
            if (_employee.EmployeeId != 0)
            {
                await Client.SendJsonAsync(HttpMethod.Put, "api/Employee/", _employee);
            }
            else
            {
                await Client.SendJsonAsync(HttpMethod.Post, "api/Employee/", _employee);
            }

            await GetAllEmployees();
        }
        #endregion

        /// <summary>
        /// DELETE
        /// </summary>
        #region snippet_DeleteEmployee
        protected async Task DeleteEmployee(int id)
        {
            await Client.DeleteAsync("api/Employee/" + id);
            await GetAllEmployees();
        }
        #endregion

        /// <summary>
        /// GET
        /// </summary>
        #region snippet_GetAllEmployees
        protected async Task GetAllEmployees() => _listEmployee = await Client.GetJsonAsync<List<Employee>>("api/Employee");
        #endregion

        #region snippet_GetAllCities
        protected async Task GetAllCities() => _listCities = await Client.GetJsonAsync<List<Cities>>("api/Cities");
        #endregion
    }
}