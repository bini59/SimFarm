using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Model.Animal;
public class Pig : Animal
{
    private int turnMoney = 240;    //�� �������� ������̴� ���
    private int turn = 2;        //�� �������� ��带 ������̴µ� ���Ǵ� �� ��
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
    public override animaltypes animalType()
    {
        return animaltypes.Pig;
    }
}
