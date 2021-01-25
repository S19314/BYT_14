using System;
using System.Collections.Generic;
using System.Text;
using BYT_zad_ind_14.Builder;

namespace BYT_zad_ind_14.Builder
{
    public class ConcreteBuilder
    {
        private Product _product = new Product();


        public ConcreteBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._product = new Product();
        }

        public void BuildPartSesameBun()
        {
            this._product.Add("sezamowa bułka");
        }

        public void BuildPartBaseBun()
        {
            this._product.Add("bułka (podstawowa)");
        }
        public void BuildPartCheese()
        {
            this._product.Add("ser");
        }

        public void BuildPartSauce()
        {
            this._product.Add("sos");
        }

        public void BuildPartCabbage()
        {
            this._product.Add("kapusta");
        }

        public void BuildPartMeat()
        {
            this._product.Add("mięso");
        }
        public Product GetProduct()
        {
            Product result = this._product;

            this.Reset();

            return result;
        }
    }
}
