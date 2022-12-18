using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Simfarm;
using Enum;
using Model.Animal;
// usermodel with Singleton pattern
namespace Model{
    namespace User{
        public class UserModel : MonoBehaviourSingletonTemplate<UserModel>, IFarmUser, IBarnUser, IDayendUser, IResultUser, IShopUser
        {
            private int day = 1;
            private int totalscore = 0;
            private int money = 3000;
            private int energy = 8;
            private int maxEnergy = 8;
            private int unclemoney = 200;
            private Equipment[] equipment = new Equipment[System.Enum.GetValues(typeof(equipments)).Length];

            void Awake() {
                DontDestroyOnLoad(gameObject);
                foreach(int i in System.Enum.GetValues(typeof(equipments))) {
                    equipment[i] = new Equipment((equipments)i);
                }
            }

            public int[] getFarmUserInfo() {
                int[] userInfo = new int[3];
                userInfo[0] = money;
                userInfo[1] = energy;
                userInfo[2] = maxEnergy;

                return userInfo;
            }

            /**
            * @return int[] energy info
            * int[0] = energy
            * int[1] = maxEnergy
            */
            public int[] getBarnUserEnergy() {
                int [] energyInfo = new int[2];
                energyInfo[0] = energy;
                energyInfo[1] = maxEnergy;

                return energyInfo;
            }
            public bool buyEquipment(equipments equipment) {
                for (int i = 0; i < this.equipment.Length; i++) {
                    if(this.equipment[i].getEquipmentType() != equipment) continue;
                    int price = this.equipment[i].getPrice();
                    if(money < price) return false;
                    this.money -= price;
                    this.equipment[i].buyEquipment();
                    GameManager.Instance.updateGold();
                }
                return true;
            }
            public Equipment[] getBarnUserEquipment() {
                return equipment;
            }

            public Equipment[] getShopEquipment() {
                int noOwnedEquipment = 0;
                foreach(Equipment e in equipment) {
                    if(e.getIsOwned() == false) {
                        noOwnedEquipment++;
                    }
                }
                Equipment[] shopEquipment = new Equipment[noOwnedEquipment];
                int i = 0;
                foreach(Equipment e in equipment) {
                    if(e.getIsOwned() == false) {
                        shopEquipment[i] = e;
                        i++;
                    }
                }
                return shopEquipment;
            }
            public int getUncleMoney()
            {
                return unclemoney;
            }
            public int getDayendUserMoney() {       //��Ż����� �� ����
                return money;
            }
            public void setDayendUserMoney(int money) {
                this.money += money;
            }

            public int getResultUserMoney() {       //������� �����  �� ����
                return money;
            }

            public int getDay() {
                return day;
            }
            public int addDay() {
                day += 1;
                return day;
            }

            public int redueceEnergy()
            {
                if (this.energy <= 0)
                {
                    return -1;
                }
                this.energy -= 1;
                return this.energy;
            }
            public void setTotalScore(int score)
            {
                this.totalscore += score;
            }

            public int getTotalScore()
            {
                return totalscore;
            } 
            public int getCurEnergy() {
                return this.energy;
            }

            public void setEnergyFull() {
                this.energy = this.maxEnergy;
            }


            public void earnDayMoney(Animal.Animal[] animals) {
                for (int i = 0; i < 6; i++) {
                    if(animals[i] == null) continue;
                    this.money += animals[i].getTurnMoney();
                }
                this.money += this.unclemoney;
            }
        }
    }
}
