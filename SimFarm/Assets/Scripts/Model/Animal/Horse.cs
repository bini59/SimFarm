using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model.Animal;
public class Horse : Animal
{
    private int turnMoney = 800;    //각 동물들이 벌어들이는 골드
    private int turn = 4;        //각 동물들이 골드를 벌어들이는데 사용되는 턴 수
    public override int getTurn()
    {
        return turn;
    }
    public override void setTurn()
    {
        if (this.turn == 0)
        {
            this.turn = 4;
        }
        this.turn--;
    }
    public override int getTurnMoney()
    {
        return turnMoney;
    }
    public override animaltypes animalType()
    {
        return animaltypes.Horse;
    }
}
