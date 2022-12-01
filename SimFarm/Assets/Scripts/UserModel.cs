using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// usermodel with Singleton pattern

public class UserModel : MonoBehaviourSingletonTemplate<UserModel>
{
    private int money;
    private int energy;
    private int maxEnergy;
    private string[] equipment;

    public int Money { get => money; set => money = value; }
    public int Energy { get => energy; set => energy = value; }
    public int MaxEnergy { get => maxEnergy; set => maxEnergy = value; }
    public string[] Equipment { get => equipment; set => equipment = value; }

}
