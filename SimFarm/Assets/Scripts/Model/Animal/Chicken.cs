using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model.Animal;

public class Chicken : Animal
{
    private int turnMoney = 50;    //각 동물들이 벌어들이는 골드
    private int turn = 1;        //각 동물들이 골드를 벌어들이는데 사용되는 턴 수
    public override int getTurn()
    {
        return turn;
    }
    public override void setTurn()
    {
        if (this.turn == 0)
        {
            this.turn = 1;
        }
        this.turn--;
    }
    public override int getTurnMoney()
    {
        return turnMoney;
    }
    public override animaltypes animalType()
    {
        return animaltypes.Chicken;
    }
}
