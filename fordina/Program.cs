using fordina.employee;
using System;
using System.Collections.Generic;
using fordina.task;

namespace fordina
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Задание

            Console.WriteLine("Написать программу, содержащую решение следующих задач:\r\n" +
                "На совещании у начальства раздавали задачи. Сотрудники фирмы так задолбались, что\r\n" +
                "решили, что будут получать задачи только в том случае, если это их прямое руководство.\r\n" +
                "Все возмущение началось из‐за того, что бухгалтерия решила автоматизировать себе\r\nработу,\r\n" +
                "они хотят приходить на работу, нажимать на кнопочку и чтобы все само делалось, а отдел\r\n" +
                "информационных технологий должен сделать эту задачу им." +
                "При назначении задач, задача должна иметь признак кому ее дают: системщикам или\r\n" +
                "разработчикам или начальству(начальник и зам.начальник отдела), а потом\r\n\r\n" +
                "распределить задачи по сотрудникам. На экране будет следующее: от человека А\r\n" +
                "даётся задача «название задачи» человек Б. И надо вывести берет человек задачу или\r\nнет.");

            Dictionary<string, Employee> employees = new Dictionary<string, Employee>();

            Employee timur = new Employee("Тимур", "Генеральный директор");
            Employee rashid = new Employee("Рашид", "Финансовый директор");
            Employee ilham = new Employee("Ильхам", "Директор по автоматизации");

            //бухгалтерия
            Employee lukas = new Employee("Лукас", "Главный бухгалтер");

            //IT-отдел
            Employee orkadiy = new Employee("Оркадий", "Начальник инф систем", "начальство");
            Employee volodya = new Employee("Володя", "Зам. начальника инф систем", "начальство");

            //системщики
            Employee ilshat = new Employee("Ильшат", "Главный в секторе системщиков", "системщики");
            Employee ivanych = new Employee("Иваныч", "Зам. сектора системщиков", "системщики");
            Employee ilya = new Employee("Илья", "Системщик", "системщики");
            Employee vitya = new Employee("Витя", "Системщик", "системщики");
            Employee zhenya = new Employee("Женя", "Системщик", "системщики");

            //разработчики
            Employee sergey = new Employee("Сергей", "Главный в секторе разработчиков", "разработчики");
            Employee lyaysan = new Employee("Ляйсан", "Зам. сектора разработчиков", "разработчики");
            Employee marat = new Employee("Марат", "Разработчик", "разработчики");
            Employee dina = new Employee("Дина", "Разработчик", "разработчики");
            Employee ildar = new Employee("Ильдар", "Разработчик", "разработчики");
            Employee anton = new Employee("Антон", "Разработчик", "разработчики");

            Employee[] allEmployees = {
                timur, rashid, ilham, lukas, orkadiy, volodya,
                ilshat, ivanych, ilya, vitya, zhenya,
                sergey, lyaysan, marat, dina, ildar, anton
            };
            foreach (Employee emp in allEmployees)
            {
                employees[emp.Name] = emp;
            }

            rashid.AddBoss(timur);
            ilham.AddBoss(timur);
            lukas.AddBoss(rashid);

            orkadiy.AddBoss(ilham);
            volodya.AddBoss(ilham);

            sergey.AddBoss(orkadiy);
            sergey.AddBoss(volodya);
            lyaysan.AddBoss(sergey);
            marat.AddBoss(lyaysan);
            dina.AddBoss(lyaysan);
            ildar.AddBoss(lyaysan);
            anton.AddBoss(lyaysan);

            ilshat.AddBoss(orkadiy);
            ilshat.AddBoss(volodya);
            ivanych.AddBoss(ilshat);
            ilya.AddBoss(ivanych);
            vitya.AddBoss(ivanych);
            zhenya.AddBoss(ivanych);

            Task task1 = new Task("Написать скрипт автозаполнения форм", "разработчики");
            Task task2 = new Task("Проверить маршрутизацию в секторе", "системщики");
            Task task3 = new Task("Проверить пул-реквесты джунов", "разработчики");

            task1.Indication(timur, vitya);
            task3.Indication(orkadiy, sergey);
            task2.Indication(ildar, ilshat); 
        }
    }
}
