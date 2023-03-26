using ProjectMMC.Core.Entities;
using ProjectMMC.Infrastructure.DBcontext;
using System;
using System.Data;

namespace ProjectMMC.Infrastructure.Services;

public class CompanyServices
{
    private static int index_counter = 0;
    public void Creat(string? name)
    {
        if (String.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException();
        }
        bool isExist = false;
        for (int i = 0; i < index_counter; i++)
        {
            if (AppDBcontext.Companies[i].Name.ToUpper() == name.ToUpper())
            {
                isExist = true;
                break;
            }
        }
        if (isExist)
        {
            throw new DuplicateNameException("This company already exist");
        }
        Company new_company = new (name);
        AppDBcontext.Companies[index_counter++] = new_company;
    }
    public void GetAll()
    {
        for (int i = 0;i < index_counter;i++)
        {
            Console.WriteLine($"Id:{AppDBcontext.Companies[i].Id}->Name:{AppDBcontext.Companies[i].Name}");
        }
    }
    public void GetAllDepartments(int id)
    {
        for (int i = 0; i < index_counter; i++)
        {
            if (AppDBcontext.Companies[i].Id == id)
            {
                foreach (var department in AppDBcontext.Departments)
                {
                    if (department is null) break;
                    Console.WriteLine(department.Name);
                }
            }
        }
    }
}




