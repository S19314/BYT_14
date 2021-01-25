using System;
using System.Collections.Generic;
using BYT_zad_ind_14.Memento;
namespace BYT_zad_ind_14
{
    class Program
    {

        private static PasswordManager passwordManager;
        static void Main(string[] args)
        {

            User user = new User("root");
            Caretaker caretaker = new Caretaker();
            passwordManager = new PasswordManager(user, caretaker);
            Console.WriteLine("Good day! Witamy w SuperBurgerze!");
            communcationWithClient();
            Console.WriteLine("Program skończył swoje działanie.");
            /*
             * 
             
            Foo foo = new Foo("Test", 15);
            foo.Print();
            Caretaker ct1 = new Caretaker();
            Caretaker ct2 = new Caretaker();
            ct1.SaveState(foo);
            foo.IntProperty += 152;
            foo.Print();
            ct2.SaveState(foo);
            ct1.RestoreState(foo);
            foo.Print();
            ct2.RestoreState(foo);
            foo.Print();
            Console.ReadKey();
            */
            Console.ReadKey();
        }

        private static void communcationWithClient()
        {   
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
                        Console.WriteLine("Proszę, wpisać nowe hasło" +
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
                        // burger
                        break;
                    default:
                        break;
                }
            } while (!commandSystem.Equals("END"));

        }


        
    }

}

    /*
        // Create director and builders
        Director director = new Director();

        Builder b1 = new ConcreteBuilder1();
        Builder b2 = new ConcreteBuilder2();

        // Construct two products
        director.Construct(b1);
        Product p1 = b1.GetResult();
        p1.Show();

        director.Construct(b2);
        Product p2 = b2.GetResult();
        p2.Show();

        // Wait for user
        Console.Read();
    }
}

// "Director"

class Director
{
    // Builder uses a complex series of steps
    public void Construct(Builder builder)
    {
        builder.BuildPartA();
        builder.BuildPartB();
    }
}

// "Builder"

abstract class Builder
{
    public virtual void BuildPartA() { }
    public virtual void BuildPartB() { }
    public abstract Product GetResult();
}

// "ConcreteBuilder1"

class ConcreteBuilder1 : Builder
{
    private readonly Product product = new Product();

    public override void BuildPartA()
    {
        product.Add("PartA");
    }

    public override void BuildPartB()
    {
        product.Add("PartB");
    }

    public override Product GetResult()
    {
        return product;
    }
}

// "ConcreteBuilder2"

class ConcreteBuilder2 : Builder
{
    private readonly Product product = new Product();

    public override void BuildPartA()
    {
        product.Add("PartX");
    }

    public override void BuildPartB()
    {
        product.Add("PartY");
    }

    public override Product GetResult()
    {
        return product;
    }
}

// "Product"

class Product
{
    private readonly List<string> parts = new List<string>();

    public void Add(string part)
    {
        parts.Add(part);
    }

    public void Show()
    {
        Console.WriteLine("\nProduct Parts -------");
        foreach (string part in parts)
            Console.WriteLine(part);
    }
}

    } 

    */
