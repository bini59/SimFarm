using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Simfarm;
// usermodel with Singleton pattern
namespace Model{
    namespace User{
        public class UserModel : MonoBehaviourSingletonTemplate<UserModel>, IFarmUser, IBarnUser, IDayendUser, IResultUser, IShopUser
        {
            private int day;
            private int money = 1000;
            private int energy = 3;
            private int maxEnergy = 8;
            private int unclemoney = 1000;
            private Equipment[] equipment = new Equipment[System.Enum.GetValues(typeof(equipments)).Length];

            void Awake() {
                DontDestroyOnLoad(gameObject);
                foreach(int i in System.Enum.GetValues(typeof(equipments))) {
                    equipment[i] = new Equipment((equipments)i);
                }
                // log for test
                foreach(Equipment e in equipment) {
                    Debug.Log(e.getEquipmentType() + " " + e.getIsOwned());
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
            public int getDayendUserMoney() {       //토탈골드할 떄 쓰자
                return money;
            }
            public void setDayendUserMoney(int money) {
                this.money += money;
            }

            public int getResultUserMoney() {       //최종결과 골드할  떄 쓰자
                return money;
            }

            public void setDay(int day)
            {
                this.day = day;
            }

            public int getDay()
            {
                return day;
            }

        }
    }
}
