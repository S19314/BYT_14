using System;
using System.Collections.Generic;
using System.Text;
using BYT_zad_ind_14.Mediator.Interface;
namespace BYT_zad_ind_14.Mediator
{
    public class BaseComponent
    {
        // Базовый Компонент обеспечивает базовую функциональность хранения
        // экземпляра посредника внутри объектов компонентов.

        protected IMediator _mediator;

        public BaseComponent(IMediator mediator = null)
        {
            this._mediator = mediator;
        }

        public void SetMediator(IMediator mediator)
        {
            this._mediator = mediator;
        }
    }
}
    // Конкретные Компоненты реализуют различную функциональность. Они не
    // зависят от других компонентов. Они также не зависят от каких-либо
    // конкретных классов посредников.
   
        /*
        class Program
        {
            static void Main(string[] args)
            {
                // Клиентский код.
                Component1 component1 = new Component1();
                Component2 component2 = new Component2();
                new ConcreteMediator(component1, component2);

                Console.WriteLine("Client triggets operation A.");
                component1.DoA();

                Console.WriteLine();

                Console.WriteLine("Client triggers operation D.");
                component2.DoD();
            }
        }
        */
    

