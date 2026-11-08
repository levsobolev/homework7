using fortumakov.typeforBankAccount;
using System;
namespace fortumakov.Bankaccount
{
    public class BankAccount
    {
        private int _numberBankAccount;
        private decimal _balance;
        private TypeForBankAccount _typeforBankAccount;

        //Методы доступа к данным
        public decimal GetBalance()
        {
            return _balance;
        }
        public void SetBalance(decimal value)
        {
            _balance = value;
        }

        public TypeForBankAccount GetTypeForBankAccount()
        {
            return _typeforBankAccount;
        }
        public void SetTypeForBankAccount(TypeForBankAccount value)
        {
            _typeforBankAccount = value;
        }

        public int GetNumberBankAccount()
        {
            return _numberBankAccount;
        }

        //Статические поле и метод для генерации номера банковского счета в порядке очереди
        private static int _nextNumberBankAccount = 0;
        private static int GeneratedNumberBankAccount()
        {
            return ++_nextNumberBankAccount;
        }

        //Пустой конструктор
        public BankAccount()
        {
            _numberBankAccount = GeneratedNumberBankAccount();
        }

        //Конструктор со всеми полями
        public BankAccount(decimal balance, TypeForBankAccount typeforBankAccount)
        {
            _numberBankAccount = GeneratedNumberBankAccount();
            _balance = balance;
            _typeforBankAccount = typeforBankAccount;
        }

        //Печать информации об аккаунте
        public void PrintInfo()
        {
            Console.WriteLine($"Номер счета - {_numberBankAccount}\nТип счета - {_typeforBankAccount}\nБаланс - {_balance}");
        }

        //Операция внесения депозита
        public void BankAccountTopUp(decimal amount)
        {
            if (amount > 0)
            {
                _balance += amount;
                Console.WriteLine($"Сумма успешно внесена! Новый баланс : {_balance}");
            }
            else
            {
                Console.WriteLine("Операция не прошла: сумма должна быть положительнойю");
            }
        }

        //Операция снятия со счета
        public bool Withdrawal(decimal amount)
        {
            if (amount < 0)
            {
                Console.WriteLine("Сумма снятия должна быть положительной.");
                return false;
            }

            if (_balance >= amount)
            {
                _balance -= amount;
                Console.WriteLine($"Снятие прошло успешно. Текущий баланс: {_balance}");
                return true;
            }
            else
            {
                Console.WriteLine("Операция не выполнена, недостаточно средств.");
                return false;
            }

        }

        /// <summary>
        /// Производит операцию перевода на текущий счет с указанного в методе
        /// </summary>
        /// <param name="bankaccount">Счет, с которого переводят</param>
        /// <param name="amount">Сумма, которую пытаются перевести</param>
        /// <returns>успешная операция или нет</returns>
        public bool Translation(BankAccount bankaccount, decimal amount)
        {
            if (bankaccount._balance >= amount)
            {
                bankaccount._balance -= amount;
                _balance += amount;
                Console.WriteLine("Операция прошла успешно");
                return true;
            }
            else
            {
                Console.WriteLine("На счете недостаточно средств");
                return false;
            }
        }
    }
}