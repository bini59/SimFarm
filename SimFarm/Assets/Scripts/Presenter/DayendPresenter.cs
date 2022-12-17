using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Model;
using Model.User;
using Model.Animal;
using Simfarm;
using View.Dayend;


namespace Presenter
{
    namespace Dayend
    {
        public class DayendPresenter
        {
            private GameManager manager;
            private IDayendAnimal animal;
            private IDayendUser user;
            private DayendView view;
            public DayendPresenter(DayendView view)
            {
                user = UserModel.Instance;
                animal = AnimalModel.Instance;
                manager = GameManager.Instance;
                this.view = view;
            }
            
            public Animal[] getAnimalInfo()
            {
                return animal.getAnimalList();
            }
            public int getUncleMoney()
            {
                return user.getUncleMoney();
            }
            public int getDayendUserMoney()
            {
                return user.getDayendUserMoney();
            }
            public void setDayendUserMoney(int money)
            {
                user.setDayendUserMoney(money);
            }

            public void setDay() {
                view.setDay(user.getDay());
            }

            public void dayEnd() {
                int day = user.addDay();
                Debug.Log(day);
                if(day == 3) { manager.onEnding(); }
                else { manager.onDayEnd(); };
            }
        }
    }
}

