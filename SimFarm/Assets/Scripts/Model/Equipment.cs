
using Enum;

namespace Model{
    public class Equipment
    {
        private int feel = 0;
        private int growth = 0;
        private int hunger = 0;
        private int price = 100;
        private bool isOwned = false;
        private equipments equipmentType;

        public Equipment(equipments e)
        {
            equipmentType = e;
            switch (e)
            {
                case equipments.low_food: hunger = 1; break;
                case equipments.mid_food: hunger = 2; break;
                case equipments.high_food: hunger = 3; break;
                case equipments.low_incubator: growth = 1; break;
                case equipments.high_incubator: growth = 2; break;
                case equipments.wood_horseshoe: feel = 1; break;
                case equipments.iron_horseshoe: feel = 2; break;
                case equipments.high_barn: feel = 1; break;
                case equipments.old_grandfather_cloth: feel = 1; growth = 1; break;
                case equipments.new_grandfather_cloth: feel = 2; growth = 2; break;
                case equipments.normal_mud: feel = 1; break;
                case equipments.clean_mud: feel = 2; break;
                case equipments.low_dehorner: feel = 1; break;
                case equipments.high_dehorner: feel = 2; break;
                case equipments.low_cleaner: feel = 1; break;
                case equipments.mid_cleaner: feel = 2; break;
                case equipments.high_cleaner: feel = 3; break;
            }
        }
        public bool getIsOwned() {
            return isOwned;
        }
        public int getPrice() {
            return price;
        }
        public int getFeel() {
            return feel;
        }
        public int getGrowth() {
            return growth;
        }
        public int getHunger() {
            return hunger;
        }
        public equipments getEquipmentType() {
            return equipmentType;
        }

        public int[] getItemStat(string animal) {
            if(!isOwned) return new int[3] { 0, 0, 0 };
            if(
                equipmentType == equipments.low_food ||
                equipmentType == equipments.mid_food ||
                equipmentType == equipments.high_food ||
                equipmentType == equipments.high_barn ||
                equipmentType == equipments.low_cleaner ||
                equipmentType == equipments.mid_cleaner ||
                equipmentType == equipments.high_cleaner
            ) return new int[3] { feel, growth, hunger };


            if (
                (animal.Equals("Chicken") || animal.Equals("Duck")) &&
                (
                    equipmentType == equipments.low_incubator ||
                    equipmentType == equipments.high_incubator
                )
            ) return new int[3] { feel, growth, hunger };

            if (
                (animal.Equals("Horse") ) &&
                (
                    equipmentType == equipments.wood_horseshoe ||
                    equipmentType == equipments.iron_horseshoe
                )
            ) return new int[3] { feel, growth, hunger };

            if (
                (animal.Equals("Cow") ) &&
                (
                    equipmentType == equipments.old_grandfather_cloth ||
                    equipmentType == equipments.new_grandfather_cloth
                )
            ) return new int[3] { feel, growth, hunger };

            if (
                (animal.Equals("Pig")) &&
                (
                    equipmentType == equipments.clean_mud ||
                    equipmentType == equipments.normal_mud
                )
            ) return new int[3] { feel, growth, hunger };

            if (
                (animal.Equals("Goat")) &&
                (
                    equipmentType == equipments.high_dehorner ||
                    equipmentType == equipments.low_dehorner
                )
            ) return new int[3] { feel, growth, hunger };
        }
    }

}

