using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Model.User;
using Model;

public interface IShopUser
{
    public Equipment[] getShopEquipment();
    public bool buyEquipment(equipments equipment);
}
