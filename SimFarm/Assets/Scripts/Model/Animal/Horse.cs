using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model.Animal;
public class Horse : Animal
{
    private int turnMoney = 800;    //�� �������� ������̴� ���
    private int turn = 4;        //�� �������� ��带 ������̴µ� ���Ǵ� �� ��
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
