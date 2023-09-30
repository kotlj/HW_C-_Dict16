using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HW_C__Dict_16_
{
    internal class Program
    {
        public static Dictionary<string, string> Employee = new Dictionary<string, string>();

        public static void Menu()
        {
            char input = '0';
            string Login;
            string Pass;
            Console.WriteLine("Welcome to @CompanyName@ profile manager, choose option:\n0 - exit\n1 - Add new profile\n2 - Remove profile\n3 - Change password\n4 - Change Login and Password\n5 - Get password(totaly secure)\n");
            while (true)
            {
                input = Convert.ToChar(Console.ReadLine());
                if (input >= '0' && input <= '5')
                {
                    if (input == '1')
                    {
                        Console.WriteLine("Enter Login and Password(Divide prising enter):");
                        Login = Console.ReadLine();
                        Pass = Console.ReadLine();
                        AddNewPerson(Login, Pass);
                    }
                    else if (input == '2')
                    {
                        Console.WriteLine("Enter Login to remove:");
                        Login = Console.ReadLine();
                        RemovePerson(Login);
                    }
                    else if (input == '3')
                    {
                        Console.WriteLine("Enter Login what password will be changed:");
                        Login = Console.ReadLine();
                        Console.WriteLine("Enter new password:");
                        Pass = Console.ReadLine();
                        ChangePassword(Login, Pass);
                    }
                    else if (input == '4')
                    {
                        Console.WriteLine("Enter Login what will be changed:");
                        Login = Console.ReadLine();
                        Console.WriteLine("Enter new Login:");
                        string NewLogin = Console.ReadLine();
                        ChangeLogin(Login, NewLogin);
                    }
                    else if (input == '5')
                    {
                        Console.WriteLine("Enter Login what password you want to get");
                        Login = Console.ReadLine();
                        Console.WriteLine(GetPassword(Login));
                    }
                    else if (input == '0')
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Option Doesnt exist");
                }
            }
        }
        private static void AddNewPerson(string login, string pass)
        {
            if (!Employee.ContainsKey(login))
            {
                Employee.Add(login, pass);
            }
            else
            {
                Console.WriteLine("Current Login already in use. Please, enter new Login.");
            }
        }
        private static void RemovePerson(string login)
        {
            if (Employee.ContainsKey(login))
            {
                Employee.Remove(login);
                Console.WriteLine($"{login} was removed.");
            }
            else
            {
                Console.WriteLine("An Login error, please, check login is correct");
            }
        }
        private static void ChangeLogin(string login, string NewLogin)
        {
            if (Employee.ContainsKey(login))
            {
                if (!Employee.ContainsKey(NewLogin))
                {
                    string password = Employee[login];
                    Employee.Remove(login);
                    Employee.Add(NewLogin, password);
                }
                else
                {
                    Console.WriteLine($"Current Login - {NewLogin} already exist");
                }
            }
            else
            {
                Console.WriteLine("An Login-Password error, please, check Login-Password combination");
            }
        }
        private static void ChangePassword(string login, string NewPass)
        {
            if (Employee.ContainsKey(login))
            {
                Employee[login] = NewPass;
            }
            else
            {
                Console.WriteLine("An Login error, please, check login is correct");
            }
        }
        private static string GetPassword(string login)
        {
            if (Employee.ContainsKey(login))
            {
                return Employee[login];
            }
            else
            {
                Console.WriteLine("An Login error, please, check login is correct");
                return "0";
            }
        }
        static void Main(string[] args)
        {
            Menu();
        }
    }
}
