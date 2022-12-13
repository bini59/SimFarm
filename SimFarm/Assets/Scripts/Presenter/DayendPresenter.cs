using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Model;
using Model.User;
using Model.Animal;


namespace Presenter
{
    namespace Dayend
    {
        public class DayendPresenter
        {
            private IDayendAnimal animal;
            private IDayendUser user;
            public DayendPresenter()
            {
                user = UserModel.Instance;
                animal = AnimalModel.Instance;
            }
            
            public Animal[] getAnimalInfo()
            {
                return animal.getAnimalList();
            }

            public void setDay(int day)
            {
                user.setDay(day);
            }
            public int getDay()
            {
                return user.getDay();
            }
        }
    }
}

