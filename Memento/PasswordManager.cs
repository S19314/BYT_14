using System;
using System.Collections.Generic;
using System.Text;

namespace BYT_zad_ind_14.Memento
{
    class PasswordManager
    {
        private User user;
        private Caretaker caretaker;
        public PasswordManager(User user, Caretaker caretaker) 
        {
            this.user = user;
            this.caretaker = caretaker;
        }
        public void SaveState() 
        {
            caretaker.SaveState(user);
        }

        public void RestoreState() 
        {
            caretaker.RestoreState(user);
        }
        public void ChangePassword(String password)
        {
            // if (password.Equals("STOP")) throw new ArgumentException("PASSWORD nie może mieć wartość: STOP");
            user.LastDateUpdateProperty = DateTime.Now;
            user.PasswordStringProperty = password;
            if (password.Equals("STOP")) throw new ArgumentException("PASSWORD nie może mieć wartość: STOP"); 
            // Specjalne, żeby pokazać działanie MEMENTO
        }

        public bool isPasswordsEquals(string password) 
        {
            return user.PasswordStringProperty.Equals(password);
        }


        public bool autorizateUser()
        {
            string password;
            do
            {
                Console.WriteLine("Proszę wpisać swoje hasło\n" +
                    "Dla rezegnacji z zmiany hasła, proszę wpisać: STOP");
                password = Console.ReadLine().Trim();
                if (password.Equals("STOP")) return false;
            } while (!isPasswordsEquals(password));
            return true;
        }

    }
}
