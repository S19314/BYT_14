using System;
using System.Collections.Generic;
using System.Text;

namespace BYT_zad_ind_14.Memento.Interface
{   
    public interface IOriginator
    {
        object GetMemento();
        void SetMemento(object memento);
    }
}
