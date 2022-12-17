using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model{
    namespace Animal{
        public class Animal
        {
            
            private int growth;      //��������, 
            private int feel;        //���
            private int hunger;      //�� �������� ����� ��ġ
            private int turnMoney;    //�� �������� ������̴� ���
            private int turn;        //�� �������� ��带 ������̴µ� ���Ǵ� �� ��
            private animaltypes animal;

            public int[] getDayendAnimalInfo()
            {
                int[] animalInfo = new int[5];
                animalInfo[0] = growth;
                animalInfo[1] = feel;
                animalInfo[2] = hunger;
                animalInfo[3] = turnMoney;
                animalInfo[4] = turn;

                return animalInfo;
            }
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
            public virtual int getTurn()
            {
                return turn;
            }
            public virtual void setTurn()
            {
                if(this.turn == 0)
                {
                    this.turn = 1;
                }
                this.turn--;
            }
            public virtual int getTurnMoney()
            {
                return turnMoney;
            }
            public virtual animaltypes animalType()
            {
                return animal;
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
        }

    }
}
