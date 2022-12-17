using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model.Animal;

public class Chicken : Animal
{
    private int turnMoney = 50;    //�� �������� ������̴� ���
    private int turn = 1;        //�� �������� ��带 ������̴µ� ���Ǵ� �� ��
    private int score = 0;
    private int isOwned = 1;
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
    public override int getScore()
    {
        setScore();
        return this.score;
    }
    public override void setScore()
    {
        this.score = (int)(getFeel() * 0.1) + (int)(getGrowth() * 0.2) + isOwned;
    }
    public override animaltypes animalType()
    {
        return animaltypes.Chicken;
    }
}
