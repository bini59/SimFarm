using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Model;
using Model.User;
using Model.Animal;

namespace Presenter
{
    namespace Result
    {
        public class ResultPresenter
        {
            private IResultAnimal animal;
            private IResultUser user;

            public ResultPresenter()
            {
                user = UserModel.Instance;
                animal = AnimalModel.Instance;
            }
            public Animal[] getAnimalInfo()
            {
                return animal.getAnimalList();
            }
            public void setAnimalScore(int score)
            {
                animal.setAnimalScore(score);
            }
            public int getAnimalScore()
            {
                return animal.getAnimalScore();
            }
            public int getResultUserMoney()
            {
                return user.getResultUserMoney();
            }
            public void setTotalScore(int score)
            {
                user.setTotalScore(score);
            }
            public int getTotalScore()
            {
                return user.getTotalScore();
            }
        }
    }
}
