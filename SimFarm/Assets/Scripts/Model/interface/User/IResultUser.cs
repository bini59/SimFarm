using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model.User;
public interface IResultUser
{
    public int getResultUserMoney();
    public void setTotalScore(int score);
    public int getTotalScore();
}