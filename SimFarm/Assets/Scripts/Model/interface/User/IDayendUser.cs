using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model.User;
using Model.Animal;
public interface IDayendUser
{
    public int getDayendUserMoney();
    public void setDayendUserMoney(int money);
    public int getDay();
    public int addDay();
    public int getUncleMoney();
    public void setEnergyFull();
    public void earnDayMoney(Animal[] animals);
}
