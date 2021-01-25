using System;
using System.Collections.Generic;
using BYT_zad_ind_14.Memento;
using BYT_zad_ind_14.Builder;
using BYT_zad_ind_14.Mediator.Components;
using BYT_zad_ind_14.Mediator;

namespace BYT_zad_ind_14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Good day! Witamy w SuperBurgerze!");
            communcationWithClient();
            Console.WriteLine("Program skończył swoje działanie.");
            Console.ReadKey();
        }

        private static void communcationWithClient()
        {
            User user = new User("root");
            Waiter waiter = new Waiter();
            Cook cook = new Cook();
            ConcreteMediator concreteMediator = new ConcreteMediator(waiter, cook, user);
            var builder = new ConcreteBuilder();
            cook.Builder = builder;

            Caretaker caretaker = new Caretaker();
            PasswordManager passwordManager = new PasswordManager(user, caretaker);


            Console.WriteLine(" Dla korzystania z systemu, proszę zalogować się" +
                    "\nP.S. Password dla testera: root");
            if (!passwordManager.autorizateUser()) return;
             
            string commandSystem = "";  
            do
            {
                Console.WriteLine("Jesteś autoryzowany.\n" +
                    "Masz do dyspozycjui następujące opcje:" +
                    "\nDla zmiany hasła proszę wpisać: 1\n" +
                    "Dla zamówenia burgera proszę wpisać: 2\n" +
                    "Dla skończenia sesji, proszę wpisać: END");
                commandSystem = Console.ReadLine().Trim();
                switch (commandSystem) 
                {
                    case "1":
                        // password
                        passwordManager.SaveState();
                        Console.WriteLine("Proszę, wpisać nowe hasło, nowe hasło będzie działać tylko podczas działania sesji" +
                            "\n Hasło nie może mieć wartość: STOP" +
                            "\n Proszę wpisać STOP, jeżeli rezegnujeś z edycji hasła.");

                        string newPassword = Console.ReadLine().Trim();
                        try
                        {
                            passwordManager.ChangePassword(newPassword);
                            Console.WriteLine("Hasło zostało zmienione");
                        }
                        catch (ArgumentException arge) 
                        {
                            Console.WriteLine(arge.Message);
                            Console.WriteLine("Została wykonana rezygnacja ze zmiany hasła");
                            passwordManager.RestoreState();
                        }
                        passwordManager.PrintUserData();   
                        break;
                    case "2":
                        Console.WriteLine("\tMenu" +
                            "\n==============================================" +
                            "\nDla wyboru Burgera proszę wpisać 1 ;" +
                            "\nDla wyboru CheeseBurgera proszę wpisać 2 ; " +
                            "\nDla wyboru BigMac proszę wpisać 3 ;" +
                            "\nDla rezygnacji proszę wpisać 4 ;");
                        string menuCommand = Console.ReadLine();
                        switch (menuCommand) 
                        {
                            case "1":
                                user.AskWaiterForBurger(new Product("Burger"));
                                break;
                            case "2":
                                user.AskWaiterForBurger(new Product("CheeseBurger"));
                                break;
                            case "3":
                                user.AskWaiterForBurger(new Product("BigMac"));
                                break;
                            case "4":
                                Console.WriteLine("Nie sostało wybrano potrawy.");
                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        break;
                }
            } while (!commandSystem.Equals("END"));

        }
    }
}