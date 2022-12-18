using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model{
    namespace Animal{
        public class Animal
        {
            
            private int growth = 10;      //��������, 
            private int feel = 10;        //���
            private int hunger;      //�� �������� ����� ��ġ
            private int turnMoney;    //�� �������� ������̴� ���
            private int turn;        //�� �������� ��带 ������̴µ� ���Ǵ� �� ��
            private int score;
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
                if (this.growth > 10)
                {
                    this.growth = 10;
                }
            }

            public int getGrowth()
            {
                return this.growth;
            }
            public void setFeel(int feel)
            {
                this.feel = feel;
                if(this.feel > 10)
                {
                    this.feel = 10;
                }
            }
            public int getFeel()
            {
                return this.feel;
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
            public virtual void setScore()
            {
                this.score = getFeel() + getGrowth();
            }
            public virtual int getScore()
            {
                return this.score;
            }
            public virtual animaltypes animalType()
            {
                return animal;
            }
            public int getHunger(){
                return this.hunger;
            }
            public void setHunger(int hunger) {
                this.hunger = hunger;
            } 
            public void feed()
            {
                this.hunger += 3;
            }

            public void useItem(int item)
            {
                if(item == 0)
                {
                    setFeel(feel++);
                }
                else
                {
                    setFeel(feel--);
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
