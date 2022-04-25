using FormApp.Models;
using FormApp.Utils;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;

namespace FormApp.Services
{
    public class ApiService : IDataService
    {
        public static string apiUrl = "http://localhost:13558/api/";

        public Response<bool> CreatePermission(PermissionSave model)
        {
            var permissionDb = new Permission();

            PermissionModelToPermission(model, permissionDb);

            var client = new HttpClient();
            client.BaseAddress = new Uri($"{apiUrl}");
            var postTask = client.PostAsJsonAsync<Permission>("Permissions", permissionDb);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<Permission>();
                readTask.Wait();

                var insertedObject = readTask.Result;

                return new Response<bool> { IsSuccess = true, Value = true };

            }

            return new Response<bool> { IsSuccess = false, Error = "We coulnt create this object" };

        }

        public Response<PermissionType> GetPermissionType(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"{apiUrl}");

                var responseTask = client.GetAsync($"PermissionTypes/{id}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<PermissionType>();
                    readTask.Wait();
                    var permission = readTask.Result;
                    return new Response<PermissionType> { IsSuccess = true, Value = permission };
                }
            }

            return new Response<PermissionType> { IsSuccess = false, Value = new PermissionType(), Error = "Error retreaving data" };

        }

        private void PermissionModelToPermission(PermissionSave model, Permission permissionDb)
        {
            permissionDb.EmployeeLastname = model.EmployeeLastname;
            permissionDb.EmployeeName = model.EmployeeName;
            permissionDb.PermissionDate = Dates.ConvertToDate(model.DateFromView);
            permissionDb.PermissionTypeId = model.PermissionTypeId;
        }

        public Response<bool> DeletePermission(int selectedId)
        {
            var client = new HttpClient();

            client.BaseAddress = new Uri($"{apiUrl}");

            var responseTask = client.DeleteAsync($"Permissions/{selectedId}");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<Permission>();
                readTask.Wait();
                var permission = readTask.Result;
                return new Response<bool> { IsSuccess = true, Value = true };
            }

            return new Response<bool> { IsSuccess = false, Value = false, Error = "Error retreaving data" };

        }

        public Response<Permission> GetPermission(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"{apiUrl}");

                var responseTask = client.GetAsync($"Permissions/{id}");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<Permission>();
                    readTask.Wait();
                    var permission = readTask.Result;
                    return new Response<Permission> { IsSuccess = true, Value = permission };
                }
            }

            return new Response<Permission> { IsSuccess = false, Value = new Permission(), Error = "Error retreaving data" };

        }

        public Response<List<Permission>> GetPermissions()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"{apiUrl}");
                var responseTask = client.GetAsync("Permissions");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<List<Permission>>();
                    readTask.Wait();
                    var permissions = readTask.Result;
                    return new Response<List<Permission>> { IsSuccess = true, Value = permissions };
                }
            }
            return new Response<List<Permission>> { IsSuccess = false, Value = new List<Permission>(), Error = "Error retreaving data" };
        }

        public Response<List<PermissionType>> GetPermissionTypes()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"{apiUrl}");
                var responseTask = client.GetAsync("PermissionTypes");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<List<PermissionType>>();
                    readTask.Wait();
                    var permissions = readTask.Result;
                    return new Response<List<PermissionType>> { IsSuccess = true, Value = permissions };
                }
            }
            return new Response<List<PermissionType>> { IsSuccess = false, Value = new List<PermissionType>(), Error = "Error retreaving data" };

        }

        public void SetPermissionId(int v) => HttpContext.Current.Session["PermissionId"] = v;

        public Response<int> GetSelectedPermissionId() => new Response<int> { IsSuccess = true, Value = Convert.ToInt32(HttpContext.Current.Session["PermissionId"]) };


        public Response<bool> UpdatePermission(int permissionId, PermissionSave model)
        {

            var permission = new Permission();

            PermissionModelToPermission(model, permission);
            permission.Id = permissionId;
            var client = new HttpClient();
            client.BaseAddress = new Uri($"{apiUrl}");
            
            var postTask = client.PutAsJsonAsync<Permission>($"Permissions/{permissionId}", permission);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {

                var readTask = result.Content.ReadAsAsync<Permission>();
                readTask.Wait();

                var updateObject = readTask.Result;

                return new Response<bool> { IsSuccess = true, Value = true };
            }

            return new Response<bool> { IsSuccess = false, Error = "We coulnt save this object" };

        }
    }
}