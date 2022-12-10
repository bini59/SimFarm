using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBarnUser
{
    public int[] getBarnUserEnergy();
    public Equipment[] getBarnUserEquipment();

}