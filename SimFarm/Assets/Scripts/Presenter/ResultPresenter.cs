using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Model;
using Model.User;
using Model.Animal;
using View.Result;

namespace Presenter
{
    namespace Result
    {
        public class ResultPresenter
        {
            private IResultAnimal animal;
            private IResultUser user;

            private ResultView view;

            public ResultPresenter(ResultView resultView)
            {
                user = UserModel.Instance;
                animal = AnimalModel.Instance;
                view = resultView;
            }


            public void processScore() {
                // score -1 
                int[] score = new int[7];
                Animal[] animals = animal.getExistAnimals();
                for (int i = 0; i < 6; i ++) {
                    score[i] = -1;
                    if (animals[i] == null) continue;
                    score[i] = animals[i].getScore();
                }
                score[6] = user.getTotalScore();

                for (int i = 0; i < 7; i++ ){
                    Debug.Log("score :" + score[i]);
                }

                view.setResultPanel(score, animals);
            }
        }
    }
}
