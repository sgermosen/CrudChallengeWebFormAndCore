namespace FormApp.Models
{
    public class PermissionSave
    {
        public int PermissionId { get; set; } 
        public string EmployeeLastname { get; set; }
        public string EmployeeName { get; set; }
        public string DateFromView { get; set; }
        public int PermissionTypeId { get; set; }
    }
}