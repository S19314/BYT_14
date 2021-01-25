﻿using System;
using System.Collections.Generic;
using System.Text;
using BYT_zad_ind_14.Mediator;
using BYT_zad_ind_14.Builder;
using BYT_zad_ind_14.Builder.Interface;
namespace BYT_zad_ind_14.Mediator.Components
{
    public class Cook : BaseComponent
    {
        private IBuilder _builder;

        public IBuilder Builder
        {
            set { _builder = value; }
            /*
             * Z przeczytanego wiem, że funkcja get{} dla buildera w Cook jest trochę inna odnośnie oryginałnej wersii 
             * Pattern Builder. Ale tutaj to jest potrzebno dlatego, że kucharz w sobie zawiera metody komunikowania, które potrzebują Product.
             * I również trochę zmieniłem oryginałną funkcje Notify() w interfejsie Mediatora, dla  zmniejszenia ilości metod, które będą wykonali 
             * podobne działania, ale dla różnych typów potraw.
             */
        }

        
        public void BuildBurger()
        {
            this._builder.BuildPartSesameBun();
            this._builder.BuildPartSauce();
            this._builder.BuildPartMeat();
            this._builder.BuildPartBaseBun();
        }

        public void BuildBigMac()
        {
            this._builder.BuildPartSesameBun();
            this._builder.BuildPartSauce();
            this._builder.BuildPartMeat();
            this._builder.BuildPartCabbage();
            this._builder.BuildPartBaseBun();
            this._builder.BuildPartSauce();
            this._builder.BuildPartMeat();
            this._builder.BuildPartCheese();
            this._builder.BuildPartCabbage();
            this._builder.BuildPartBaseBun();
        }

        public void BuildCheeseBurger() 
        {
            this._builder.BuildPartSesameBun();
            this._builder.BuildPartSauce();
            this._builder.BuildPartCheese();
            this._builder.BuildPartMeat();
            this._builder.BuildPartBaseBun();
        }   

        // DOWN Mediator Part
        public void CookBurger()
        {
            Console.WriteLine("Cook\'s answer: Np, teraz zrobię dla tobię burgera");
            /*
             Make Burger by Pattern Builder, возможно, отправка бургера клиенту через waitera
             */
            Object product = Builder;
            this._mediator.Notify(this, "GiveBurgerToWaiter", product);
        }

     
    }
}
