using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using View.Barn;
using Model.User;
using Model;
using Simfarm;


namespace Presenter.Barn{
    public class BarnPresenter
    {
        BarnView view;
        IBarnUser user;
        GameManager manager;

        public BarnPresenter(BarnView View) {
            this.view = View;
            this.user = UserModel.Instance;
            this.manager = GameManager.Instance;
        }

        public void actAnimal(string animal, string message) {
            int[] growth = new int[3];
            Equipment[] equipment = user.getBarnUserEquipment();
            foreach(var e in equipment) {
                int[] temp = e.getItemStat(animal);
                for (int i = 0; i < 3; i++) growth[i] += temp[i];
            }
            

            int energy = user.redueceEnergy();
            if(energy == -1) return;
            this.view.setMessage();
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
