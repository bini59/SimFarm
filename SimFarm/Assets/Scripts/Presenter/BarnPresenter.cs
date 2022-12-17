using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using View.Barn;
using Model.User;
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

        public void actAnimal() {
            if(!user.redueceEnergy()) return;
            this.view.setMessage();
            this.manager.redueceEnergy();
        }
    }
}
