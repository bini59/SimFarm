using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Model.User;
using View.Farm;

namespace Presenter{
    namespace Farm{
        public class GuagePresenter
        {
            private IFarmUser user;
            private GuageView view;
            public GuagePresenter(GuageView view) {
                this.view = view;
                user = UserModel.Instance;
            }

            public int[] getEnergy() {
                int[] info = user.getFarmUserInfo();
                int[] energy = new int[2];
                energy[0] = info[1]; energy[1] = info[2];
                return energy;
            }
        }
    }
}
