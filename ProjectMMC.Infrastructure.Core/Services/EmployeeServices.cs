using ProjectMMC.Core.Entities;
using ProjectMMC.Infrastructure.DBcontext;
using ProjectMMC.Infrastructure.Utilities.Exceptions;
using System;

namespace ProjectMMC.Infrastructure.Services;

public class EmployeeServices
{
    private static int index_count = 0;
    public void Creat(string name, string surname, double salary, int department_id)
    {
        foreach (var departments in AppDBcontext.Departments)
        {
            if (departments == null)
            {
                throw new NotFoundException("This department is not exist");
            }
            if (departments.Id == department_id) break;
        }
        if (String.IsNullOrWhiteSpace(name) || String.IsNullOrWhiteSpace(surname))
        {
            throw new ArgumentNullException();
        }
        
        Employee new_employee = new(name, surname, salary,department_id);
        AppDBcontext.Employees[index_count++] = new_employee;
    }
   

    public void GetAll()
    {
        for (int i = 0; i < index_count; i++)
        {
            Console.WriteLine("\n************************************************************************\n");
            Console.WriteLine($"EmployeeId:{AppDBcontext.Employees[i].Id}" +
                $"EmployeeName:{AppDBcontext.Employees[i].Name}" +
                $"EmployeeSurname:{AppDBcontext.Employees[i].SurName}" +
                $"EmployeeSalary:{AppDBcontext.Employees[i].Salary}");
            
            Console.WriteLine("\n************************************************************************\n");
        }
    }
}

