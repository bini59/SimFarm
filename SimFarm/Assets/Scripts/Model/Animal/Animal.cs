using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model{
    namespace Animal{
        public class Animal
        {
            public enum animalType
            {
                Cow,
                Horse,
                Goat,
                Duck,
                Pig,
                Chicken
            }

            private int growth;      //��������, 
            private int feel;        //���
            private int hunger;      //�� �������� ����� ��ġ
            private int turnMoney;    //�� �������� ������̴� ���
            private int turn;        //�� �������� ��带 ������̴µ� ���Ǵ� �� ��
            public void setGrowth(int growth)
            {
                this.growth = growth;
            }

            public int getGrowth()
            {
                return growth;
            }
            public void setFeel(int feel)
            {
                this.feel = feel;
            }
            public int getFeel()
            {
                return feel;
            }
            public void setTurnMoney(int turnMoney)
            {
                this.turnMoney = turnMoney;
            }
            public int getTurnMoney()
            {
                return 1000;
            }
            public void setTurn(int turn)
            {
                this.turn = turn;
            }
            public int getTurn()
            {
                return turn;
            }
            public void feed()
            {
                this.hunger += 3;
            }

            public void useItem(int item)
            {
                if(item == 0)
                {
                    this.feel++;
                }
                else
                {
                    this.feel--;
                }
            }
            public void setState(int userInput) //�߰� �ʿ�
            {
                if(userInput == 0)      //����̱�
                {
                    feed();
                }
                /*else if(userInput == 1)     //�����ۻ��?
                {
                    useItem()
                }*/
            }
            public void dayEnd()    //�Ϸ� ���� �� ���� �� ����  ��
            {
                this.hunger -= 3;
                if(this.hunger > 5)
                {
                    this.growth += 1;
                    this.feel += 1;
                }
                else
                {
                    this.growth -= 1;
                    this.feel -= 1;
                }
            }

            public int earnMoney()
            {
                int earn = 0;
                if(this.feel > 8)
                {
                    earn = this.turnMoney;
                }
                else if(this.feel > 5)
                {
                    earn = this.turnMoney - this.turnMoney / 4;
                }
                else if(this.feel > 3)
                {
                    earn = this.turnMoney - this.turnMoney / 3;
                }
                else
                {
                    earn = this.turnMoney / 2;
                }
                return earn;
            }
        }

    }
}
