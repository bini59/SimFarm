using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model.Animal;
public class Duck : Animal
{
    private int turnMoney = 100;    //�� �������� ������̴� ���
    private int turn = 1;        //�� �������� ��带 ������̴µ� ���Ǵ� �� ��
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
        return animaltypes.Duck;
    }
}
