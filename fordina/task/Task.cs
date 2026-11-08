using fordina.employee;
using System;

namespace fordina.task
{
    public class Task
    {
        public static int NumberTask {  get; set; }
        public string Content {  get; set; }
        public string Departament {  get; set; }

        private int NextNumber()
        {
            return ++NumberTask;
        }

        public Task(string content, string departament)
        {
            NumberTask = NextNumber();
            Content = content;
            Departament = departament;
        }

        public bool Indication(Employee employeeBoss, Employee employee)
        {
            if (employee.Bosses.Contains(employeeBoss))
            {
                if (Departament == employee.Departament)
                {
                    Console.WriteLine($"{employee.Name} берется за задачу номер {NumberTask}");
                    return true;
                }
                else
                {
                    Console.WriteLine($"{employee.Name} не берется за задачу, тк она не в его компетенции.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine($"{employeeBoss.Name} не может давать задачи {employee.Name}");
                return false;
            }
        }
    }
}
