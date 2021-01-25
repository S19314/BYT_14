using System;
using System.Collections.Generic;
using System.Text;
using BYT_zad_ind_14.Memento.Interface;

namespace BYT_zad_ind_14.Memento
{
        public class Caretaker
        {
            private object m_memento;
            public void SaveState(IOriginator originator)
            {
                if (originator == null)
                    throw new ArgumentNullException("originator");
                m_memento = originator.GetMemento();
            }

            public void RestoreState(IOriginator originator)
            {
                if (originator == null)
                    throw new ArgumentNullException("originator");
                if (m_memento == null)
                    throw new InvalidOperationException("m_memento == null");
                originator.SetMemento(m_memento);
            }
        }
    }
