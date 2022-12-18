using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using View;
using Model.Animal;
using Model.User;
using Simfarm;

namespace Presenter{

    public class AnimalBuyPresenter 
    {
        private AnimalBuyView view;
        private UserModel user;
        private AnimalModel animal;
        public AnimalBuyPresenter(AnimalBuyView view){
            this.view = view;
            this.user = UserModel.Instance;
            this.animal = AnimalModel.Instance;
        }

        public void buyAnimal(string _animal, int price) {
            bool res = user.buyAnimal(price);
            if(res) {
                Debug.Log(_animal);
                animaltypes type = this.animal.convertString(_animal);
                Debug.Log(type);
                this.animal.buyAnimal(type);
                GameManager.Instance.updateGold();
                this.view.offButton();
            }
        }
    }
}
