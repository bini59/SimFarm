using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShopUser
{
    public Equipment[] getShopEquipment();
    public bool buyEquipment(equipments equipment);
}
