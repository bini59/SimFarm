using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model.User;
public interface IDayendUser
{
    public int getDayendUserMoney();
    public void setDayendUserMoney(int money);
    public int getDay();
    public void setDay(int day);
    public int getUncleMoney();
}
