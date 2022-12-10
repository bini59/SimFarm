using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
