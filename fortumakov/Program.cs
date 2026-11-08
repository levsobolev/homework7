using fortumakov.Bankaccount;
using fortumakov.song;
using fortumakov.typeforBankAccount;
using System;
using System.Collections.Generic;
using System.IO;

namespace fortumakov
{
    public class Program
    {

        /// <summary>
        /// возвращает слово, буквы которого идут в обратном порядке
        /// </summary>
        /// <param name="str">слово, которое нужно "развернуть"</param>
        /// <returns>итоговое слово</returns>
        public static string Revers(string str)
        {
            char[] arraychar = str.ToCharArray();

            char[] resultArray = new char[arraychar.Length];

            for (int i = 0; i < arraychar.Length; i++)
            {
                resultArray[i] = arraychar[arraychar.Length - 1 - i];
            }

            return string.Join("", resultArray);
        }

        /// <summary>
        /// если файл найден, то записывает в новый файл тот же текст, но заглавными буквами.
        /// </summary>
        public static void Task83()
        {
            Console.WriteLine("Введите имя файла: ");
            string fileName = Console.ReadLine();

            if (File.Exists(fileName))
            {
                string text = File.ReadAllText(fileName);
                File.AppendAllText("result.txt", text.ToUpper());
                Console.WriteLine("Данные успешно записаны в файл.");
                return;
            }
            else
            {
                Console.WriteLine("Файла с данным названием нет.");
                return;
            }
        }

        /// <summary>
        /// проверяет совместимость параметра с IFormattable
        /// </summary>
        /// <param name="obj">параметр</param>
        /// <returns>совместим или нет</returns>
        public static bool CheckFormattableWithIs(object obj)
        {
            return obj is IFormattable;
        }

        /// <summary>
        /// проверяет совместимость параметра с IFormattable
        /// </summary>
        /// <param name="obj">параметр</param>
        /// <returns>совместим или нет</returns>
        public static bool CheckFormattableWithAs(object obj)
        {
            IFormattable iformattable = obj as IFormattable;
            
            if (iformattable != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Достает из строки email пользователя
        /// </summary>
        /// <param name="s">строка, из которой нужно достать</param>
        public static void SearchMail(ref string s)
        {
            string[] str = s.Split('#');
            s = str[1].Trim();
        }

        public static void Main(string[] args)
        {
            //Задание 8.1

            Console.WriteLine("Упражнение 8.1 В класс банковский счет, созданный в упражнениях 7.1- 7.3 добавить\r\n" +
                "метод, который переводит деньги с одного счета на другой. У метода два параметра: ссылка\r\n" +
                "на объект класса банковский счет откуда снимаются деньги, второй параметр – сумма.");

            BankAccount bankAccount1 = new BankAccount(30000, TypeForBankAccount.Current);
            BankAccount bankAccount2 = new BankAccount(4000, TypeForBankAccount.Savings);

            bankAccount1.Translation(bankAccount2, 2000);

            bankAccount1.Translation(bankAccount2, 3000);

            //Задание 8.2

            Console.WriteLine("Упражнение 8.2 Реализовать метод, который в качестве входного параметра принимает\r\n" +
                "строку string, возвращает строку типа string, буквы в которой идут в обратном порядке.\r\nПротестировать метод.");

            Console.WriteLine(Revers("Hello"));

            //Задание 8.3

            Console.WriteLine("Упражнение 8.3 Написать программу, которая спрашивает у пользователя имя файла. Если\r\n" +
                "такого файла не существует, то программа выдает пользователю сообщение и заканчивает\r\n" +
                "работу, иначе в выходной файл записывается содержимое исходного файла, но заглавными\r\nбуквами.");

            Task83();
            Task83();

            //Задание 8.4

            Console.WriteLine("Упражнение 8.4 Реализовать метод, который проверяет реализует ли входной параметр\r\n" +
                "метода интерфейс System.IFormattable. Использовать оператор is и as. (Интерфейс\r\n" +
                "IFormattable обеспечивает функциональные возможности форматирования значения объекта\r\nв строковое представление.)");

            Console.WriteLine(CheckFormattableWithAs("tryr"));
            Console.WriteLine(CheckFormattableWithIs(12));

            //Домашнее задание 8.1

            Console.WriteLine("Работа со строками. Дан текстовый файл, содержащий ФИО и e-mail\r\n" +
                "адрес. Разделителем между ФИО и адресом электронной почты является символ #:\r\n" +
                "Иванов Иван Иванович # iviviv@mail.ru\r\nПетров Петр Петрович # petr@mail.ru\r\n" +
                "Сформировать новый файл, содержащий список адресов электронной почты.\r\n" +
                "Предусмотреть метод, выделяющий из строки адрес почты. Методу в\r\n" +
                "качестве параметра передается символьная строка s, e-mail возвращается в той же строке s:\r\n" +
                "public void SearchMail (ref string s).");

            string filePath = "C:\\Users\\user\\source\\repos\\homework7\\fortumakov\\email.txt";
            string filePathres = "result81.txt";
            using (StreamReader reader = new StreamReader(filePath))
            using (StreamWriter writer = new StreamWriter(filePathres))
            {
                string line;

                while((line = reader.ReadLine()) !=  null)
                {
                    SearchMail(ref line);
                    writer.Write(line + ", ");
                    Console.WriteLine(line);
                }
            }

            //Домашнее задание 8.2

            Console.WriteLine("Список песен. В методе Main создать список из четырех песен. В\r\n" +
                "цикле вывести информацию о каждой песне. Сравнить между собой первую и вторую\r\n" +
                "песню в списке. Песня представляет собой класс с методами для заполнения каждого из\r\n" +
                "полей, методом вывода данных о песне на печать, методом, который сравнивает между\r\nсобой два объекта");

            List<Song> playlist = new List<Song>();

            Song song1 = new Song();
            song1.SetName("Кукушка");
            song1.SetAuthor("Кино");
            song1.SetPrev(null); 

            Song song2 = new Song();
            song2.SetName("Группа крови");
            song2.SetAuthor("Кино");
            song2.SetPrev(song1);

            Song song3 = new Song();
            song3.SetName("Выхода нет");
            song3.SetAuthor("Сплин");
            song3.SetPrev(song2);

            Song song4 = new Song();
            song4.SetName("Кукушка"); 
            song4.SetAuthor("Кино");
            song4.SetPrev(song3);

            playlist.Add(song1);
            playlist.Add(song2);
            playlist.Add(song3);
            playlist.Add(song4);

            Console.WriteLine("--- Список всех песен ---");
            foreach (Song song in playlist)
            {
                Console.WriteLine(song.Title());
            }
            Console.WriteLine();

            Console.WriteLine("--- Сравнение первой и второй песни ---");
            if (song1.Equals(song2))
            {
                Console.WriteLine($"Песни \"{song1.Title()}\" и \"{song2.Title()}\" одинаковые.");
            }
            else
            {
                Console.WriteLine($"Песни \"{song1.Title()}\" и \"{song2.Title()}\" разные.");
            }
            Console.WriteLine();
        }
    }
}
