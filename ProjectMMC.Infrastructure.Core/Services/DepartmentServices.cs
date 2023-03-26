using ProjectMMC.Core.Entities;
using ProjectMMC.Infrastructure.DBcontext;
using ProjectMMC.Infrastructure.Utilities.Exceptions;
using System;

namespace ProjectMMC.Infrastructure.Services;

public class DepartmentServices
{
    private static int index_count = 0;
    

    public void Create(string? name, int employeelimit, int company_id)
    {
        foreach (var company in AppDBcontext.Companies)
        {
            if(company is null)
            {
                throw new NotFoundException("Not found Company");
            }
            if (company.Id == company_id) break;
        }
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentNullException();
        }
        bool isExist = false;
        for (int i = 0; i < index_count; i++)
        {
            if (AppDBcontext.Departments[i].Name.ToUpper() == name.ToUpper())
            {
                isExist = true; break;

            }
        }
        if (isExist)
        {
            throw new DuplicateWaitObjectException("This department already exist");
        }
        Department new_department = new(name, employeelimit, company_id);
        AppDBcontext.Departments[index_count++] = new_department;
    }
    public void GetAll()
    {
        for (int i = 0; i < index_count; i++)
        {
            String temp_company = string.Empty;
            foreach (var company in AppDBcontext.Companies)
            {
                if (company == null) break;
                if (AppDBcontext.Companies[i].Id == company.Id)
                {
                    temp_company = company.Name;
                    break;
                }
            }
            Console.WriteLine($"Department Id: {AppDBcontext.Departments[i].Id}," +
                $"Department Name: {AppDBcontext.Departments[i].Name}," +
                $" EmployeeLimit:{AppDBcontext.Departments[i].EmployeeLimit}," +
                $"Belongs to:{temp_company}");

        }
    }
}

