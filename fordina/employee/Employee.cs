using System.Collections.Generic;

namespace fordina.employee
{
    public class Employee
    {
        public string Name {  get; set; }
        public string Position {  get; set; }
        public string Departament {  get; set; }
        public List<Employee> Bosses { get; set; }

        public Employee(string name, string position, string departament = null)
        {
            Name = name;
            Position = position;
            Departament = departament;
            Bosses = new List<Employee>();
        }

        public void AddBoss(Employee boss)
        {
            Bosses.Add(boss);
        }
    }
}
