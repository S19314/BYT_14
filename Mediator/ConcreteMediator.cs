using System;
using System.Collections.Generic;
using System.Text;
using BYT_zad_ind_14.Mediator.Interface;
using BYT_zad_ind_14.Mediator.Components;
using BYT_zad_ind_14.Memento;
using BYT_zad_ind_14.Builder;

namespace BYT_zad_ind_14.Mediator
{
    public class ConcreteMediator : IMediator
    {
        private readonly Waiter waiter;

        private readonly Cook cook;
        private readonly User userClient;

        public ConcreteMediator(Waiter waiter, Cook cook, User userClient)
        {
            this.waiter = waiter;
            this.waiter.SetMediator(this);
            this.cook = cook;
            this.cook.SetMediator(this);
            this.userClient = userClient;
            this.userClient.SetMediator(this);
        }

        public void Notify(object sender, string ev, object product)
        {
            if (ev == "AskWaiterForBurger")
            {
                Console.WriteLine("User say to Waiter: Zamawiam " + ((Product)product).GetName() + ".");
                this.waiter.ConfirmBurgerOdrer((Product)product);
            }
            if (ev == "ConfirmBurgerOdrer")
            {
                Console.WriteLine("Waiter asked Cook: Proszę, przygotuj " + ((Product)product).GetName() + ".");
                this.cook.CookBurger((Product)product);
                
            }
            if(ev == "CookBurger")  // GiveBurgerToWaiter
            {
                Console.WriteLine("Cook say: Trymaj " + ((Product)product).GetName() + ".");
                this.waiter.SendBurgerToClient((Product)product);
            }
            if (ev == "SendBurgerToClient") 
            {
                Console.WriteLine("Waiter say: Proszę, " + ((Product)product).GetName() + "dla Pana/Pani.");
                this.userClient.ToThankYou((Product)product);
            }
        }
    }
}
