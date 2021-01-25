using System;
using System.Collections.Generic;
using System.Text;

namespace BYT_zad_ind_14.Mediator.Interface
{
    public interface IMediator
    {
        void Notify(object sender, string ev, object product);
    }
}
