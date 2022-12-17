using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model.Animal;


public class Cow : Animal
{
    private int turnMoney = 1500;    //�� �������� ������̴� ���
    private int turn  = 5;        //�� �������� ��带 ������̴µ� ���Ǵ� �� ��
    private int score;
    private int isOwned = 5;

    public override int getTurn()
    {
        return turn;
    }
    
    public override void setTurn()
    {
        if (this.turn == 0)
        {
            this.turn = 5;
        }
        this.turn--;
    }
    public override int getScore()
    {
        setScore();
        return this.score;
    }
    public override void setScore()
    {
        this.score = (int)(getFeel() * 0.7) + getGrowth() + isOwned;
    }
    public override int getTurnMoney()
    {
        return turnMoney;
    }
    public override animaltypes animalType()
    {
        return animaltypes.Cow;
    }
}
