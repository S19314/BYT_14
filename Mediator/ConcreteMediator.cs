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
                Console.WriteLine("Mediator reacts on A and triggers folowing operations:");
                this.waiter.ConfirmBurgerOdrer();
            }
            if (ev == "ConfirmBurgerOdrer")
            {
                Console.WriteLine("Waiter asked Cook: Proszę, przygotuj Burger.");
                this.cook.CookBurger();
                
            }
            if(ev == "CookBurger")  // GiveBurgerToWaiter
            {
                Console.WriteLine("Cook say: Trymaj Burgera!");
                this.waiter.SendBurgerToClient((Product)product); // Можно отправаить как абстрактную булку, а посел через ToString() узнать что это за блюдо.
            }
            if (ev == "SendBurgerToClient") 
            {
                Console.WriteLine("Waiter say: Proszę," + ((Product)product).GetName() + "dla Pana/Pani.");
            }
        }
    }
}
