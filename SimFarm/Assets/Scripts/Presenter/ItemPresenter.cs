using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using Model;
using Model.User;
using View.Shop;

namespace Presenter{
    namespace Shop{
        public class ItemPresenter
        {
            private IShopUser user;
            public ItemPresenter() {
                user = UserModel.Instance;
            }

            public bool buyEquipment(Equipment e) {
                bool res = user.buyEquipment(e.getEquipmentType());
                return res;
            }

        }

    }
}
