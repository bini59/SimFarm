using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using View.Barn;
using Model.User;
using Model.Animal;
using Model;
using Simfarm;


namespace Presenter.Barn{
    public class BarnPresenter
    {
        BarnView view;
        IBarnUser user;
        IBarnAnimal animal;
        GameManager manager;

        public BarnPresenter(BarnView View) {
            this.view = View;
            this.user = UserModel.Instance;
            this.manager = GameManager.Instance;
            this.animal = AnimalModel.Instance;
        }

        public void actAnimal(string animal_name, string message) {
            ItemStat itemStat = new ItemStat(0, 0, 0);
            Equipment[] equipment = user.getBarnUserEquipment();
            foreach(var e in equipment) {
                ItemStat temp = e.getItemStat(animal_name);
                itemStat.feel += temp.feel;
                itemStat.growth += temp.growth;
                itemStat.hunger += temp.hunger;
            }
            ItemStat actStat = Message.getStat(animal_name, message);
            actStat.feel += itemStat.feel; actStat.growth += itemStat.growth; actStat.hunger += itemStat.hunger;


            int energy = user.redueceEnergy();
            if(energy == -1) return;
            string res = this.animal.setState(animal_name, actStat);
            this.view.setMessage(res);
            this.manager.redueceEnergy();
        }

        public void checkEnd() {
            int energy = user.getCurEnergy();
            if(energy == 0) {
                manager.toggleEnergy();
                manager.toggleDay();
            }
        }
    }
}
