using ProjectMMC.Core.Interfaces;

namespace ProjectMMC.Core.Entities;

public class Department : IEntity
{
    public int Id { get; set; }
    public string Name { get ; set; }
    public int EmployeeLimit { get;  }
    public int CompanyId { get; set; }
    private int count { get; set; }
    public Department()
    {
        Id = count++;
    }

    public Department(string name, int employee_limit, int companyId):this() 
    {
        Name = name;
        EmployeeLimit = employee_limit;
        CompanyId = companyId;
    }
}
