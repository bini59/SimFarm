using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;


namespace Presenter{
    namespace Shop{
        public class ShopPresenter
        {
            private IShopUser shopUser;
            public ShopPresenter() {
                shopUser = UserModel.Instance;
            }

            public Equipment[] getShopEquipment() {
                return shopUser.getShopEquipment();
            }
        }
    }
}

