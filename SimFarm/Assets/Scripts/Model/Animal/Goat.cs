using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model.Animal;
public class Goat : Animal
{
    private int turnMoney = 390;    //�� �������� ������̴� ���
    private int turn = 1;        //�� �������� ��带 ������̴µ� ���Ǵ� �� ��
    private int score = 0;
    private int isOwned = 3;
    public override int getTurn()
    {
        return turn;
    }
    public override void setTurn()
    {
        if (this.turn == 0)
        {
            this.turn = 3;
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
        this.score = (int)(getFeel() * 0.4) + (int)(getGrowth() * 0.6) + isOwned;
    }
    public override animaltypes animalType()
    {
        return animaltypes.Goat;
    }
}
