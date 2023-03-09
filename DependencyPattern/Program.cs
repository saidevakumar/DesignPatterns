// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

EmployeeBL employeeBL = new EmployeeBL(new EmployeeDAL());
List<Employee> ListEmployee = employeeBL.GetAllEmployees();
foreach(Employee emp in ListEmployee)
{
    Console.WriteLine("ID = {0}, Name = {1}, Department = {2}", emp.ID, emp.Name, emp.Department);
}

public class Employee
{
    public int ID { get; set; }
    public string? Name { get; set; }
    public string? Department { get; set; }
}

public interface IEmployeeDAL
{
    List<Employee> SelectAllEmployees();
}

public class EmployeeDAL : IEmployeeDAL
{
    public List<Employee> SelectAllEmployees()
    {
        List<Employee> ListEmployees = new List<Employee>();
        //Get the Employees from the Database
        //for now we are hard coded the employees
        ListEmployees.Add(new Employee() { ID = 1, Name = "Pranaya", Department = "IT" });
        ListEmployees.Add(new Employee() { ID = 2, Name = "Kumar", Department = "HR" });
        ListEmployees.Add(new Employee() { ID = 3, Name = "Rout", Department = "Payroll" });
        return ListEmployees;
    }
}

public class EmployeeBL
{
    public IEmployeeDAL employeeDAL;
    public EmployeeBL(IEmployeeDAL employeeDAL)
    {
        this.employeeDAL = employeeDAL;
    }
    public List<Employee> GetAllEmployees()
    {
        return employeeDAL.SelectAllEmployees();
    }
}