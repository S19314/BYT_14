using System;
using System.Collections.Generic;
using System.Text;
using BYT_zad_ind_14.Mediator;
using BYT_zad_ind_14.Builder;

namespace BYT_zad_ind_14.Mediator.Components
{
    public class Waiter : BaseComponent
    {
        public void ConfirmBurgerOdrer(Product product)
        {
            Console.WriteLine("Waiter\'s answer:\"Burger będzie zrobionny po paru minut.\". ");

            this._mediator.Notify(this, "ConfirmBurgerOdrer", product);
        }

        public void SendBurgerToClient(Product product)
        {
            Console.WriteLine("Waiter say: Thank you Cook fo the " + product.GetName());

            this._mediator.Notify(this, "SendBurgerToClient", product);
        }
    }
}
