using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// usermodel with Singleton pattern

public class UserModel : MonoBehaviourSingletonTemplate<UserModel>, IFarmUser
{
    private int money;
    private int energy;
    private int maxEnergy;
    private string[] equipment;

    public int Money { get => money; set => money = value; }
    public int Energy { get => energy; set => energy = value; }
    public int MaxEnergy { get => maxEnergy; set => maxEnergy = value; }
    public string[] Equipment { get => equipment; set => equipment = value; }

    public int[] getUserInfo()
    {
        int[] userInfo = new int[3];
        userInfo[0] = money;
        userInfo[1] = energy;
        userInfo[2] = maxEnergy;

        return userInfo;
    }

}
