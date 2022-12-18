using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Model.User;
using Model;

public interface IBarnUser
{
    public int[] getBarnUserEnergy();
    public Equipment[] getBarnUserEquipment();
    public int redueceEnergy();
    public int getCurEnergy();

}