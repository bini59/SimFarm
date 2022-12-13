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

            private int growth;      //성장정도, 
            private int feel;        //기분
            private int hunger;      //각 동물들의 배고픔 수치
            private int turnMoney;    //각 동물들이 벌어들이는 골드
            private int turn;        //각 동물들이 골드를 벌어들이는데 사용되는 턴 수
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
            public void setState(int userInput) //추가 필요
            {
                if(userInput == 0)      //밥먹이기
                {
                    feed();
                }
                /*else if(userInput == 1)     //아이템사용?
                {
                    useItem()
                }*/
            }
            public void dayEnd()    //하루 종료 후 다음 날 됬을  때
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
