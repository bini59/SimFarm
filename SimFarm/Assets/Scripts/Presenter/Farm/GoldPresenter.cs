using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Model.User;

namespace Presenter{
    namespace Farm{
        public class GoldPresenter
        {
            IFarmUser user;
            public GoldPresenter() {
                user = UserModel.Instance;
            }

            public int getGold() {
                return user.getFarmUserInfo()[0];
            }
        }
    }
}
