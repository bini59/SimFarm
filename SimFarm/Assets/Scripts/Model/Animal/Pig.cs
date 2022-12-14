using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Model.Animal;
public class Pig : Animal
{
    private int turnMoney = 240;    //각 동물들이 벌어들이는 골드
    private int turn = 2;        //각 동물들이 골드를 벌어들이는데 사용되는 턴 수
    private int score = 0;
    private int isOwned = 2;
    public override int getTurn()
    {
        return turn;
    }
    public override void setTurn()
    {
        if (this.turn == 0)
        {
            this.turn = 2;
        }
        this.turn--;
    }
    public override int getTurnMoney()
    {
        return turnMoney;
    }
    public override int getScore()
    {
        setScore();
        return this.score;
    }
    public override void setScore()
    {
        this.score = (int)(getFeel() * 0.3) + (int)(getGrowth() * 0.4) + isOwned;
    }
    public override animaltypes animalType()
    {
        return animaltypes.Pig;
    }
}
