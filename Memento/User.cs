using System;
using System.Collections.Generic;
using System.Text;
using BYT_zad_ind_14.Memento.Interface;
using BYT_zad_ind_14.Mediator;
namespace BYT_zad_ind_14.Memento
{
    public class User : BaseComponent, IOriginator
    {

        public string PasswordStringProperty
        {
            get;
            set;
        }

        public DateTime LastDateUpdateProperty
        {
            get;
            set;
        }
        // ПРи создании конструктора бахнуть "root" как параметр
        public User(String stringPropertyValue)
        {
            PasswordStringProperty = stringPropertyValue;
            LastDateUpdateProperty = DateTime.Now;
        }

        public void Print()
        {
            Console.WriteLine("=============");
            Console.WriteLine("User password: {0}", PasswordStringProperty);
            Console.WriteLine("Date of last update: {0}", LastDateUpdateProperty);
            Console.WriteLine("=============");
        }
        object IOriginator.GetMemento()
        {
            return new Memento { PasswordStringProperty = this.PasswordStringProperty, LastDateUpdateProperty = this.LastDateUpdateProperty };
        }

        void IOriginator.SetMemento(object memento)
        {
            if (Object.ReferenceEquals(memento, null))
                throw new ArgumentNullException("memento");
            if (!(memento is Memento))
                throw new ArgumentException("memento");
            PasswordStringProperty = ((Memento)memento).PasswordStringProperty;
            LastDateUpdateProperty = ((Memento)memento).LastDateUpdateProperty;
        }



        // DOWN for Pattern Mediator
        public void AskWaiterForBurger()
        {
            Console.WriteLine("User say to Waiter: Zamawiam burger.");

            this._mediator.Notify(this, "AskWaiterForBurger", null);
        }


        /// <summary>
        ///  THANK you?
        /// </summary>
        public void DoB()
        {
            Console.WriteLine("Component 1 does B.");

            // this._mediator.Notify(this, "B");
        }
    }

}

