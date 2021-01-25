using System;
using System.Collections.Generic;
using System.Text;

namespace BYT_zad_ind_14.Builder.Interface
{
    public interface IBuilder
    {
        void BuildPartSesameBun();

        void BuildPartBaseBun();

        void BuildPartCheese();
        void BuildPartMeat();
        void BuildPartCabbage();
        void BuildPartSauce();
    }
}
