using System;
using System.Collections.Generic;
using System.Text;
using BYT_zad_ind_14.Mediator;
using BYT_zad_ind_14.Builder;

namespace BYT_zad_ind_14.Mediator.Components
{
    public class Cook : BaseComponent
    {
        public void CookBurger()
        {
            Console.WriteLine("Cook\'s answer: Np, teraz zrobię dla tobię burgera");
            /*
             Make Burger by Pattern Builder, возможно, отправка бургера клиенту через waitera
             */
            Object product = null;
            this._mediator.Notify(this, "GiveBurgerToWaiter", product);
        }

        public void DoB()
        {
            Console.WriteLine("Component 1 does B.");

            // this._mediator.Notify(this, "B");
        }
     
    }
}
