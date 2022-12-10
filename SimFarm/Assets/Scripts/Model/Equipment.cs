public class Equipment
{
    private int feel = 0;
    private int growth = 0;
    private int hunger = 0;
    private equipments equipmentType;

    public Equipment(equipments e) {
        equipmentType = e;
        switch (e) {
            case equipments.low_food: hunger = 1; break;
            case equipments.mid_food: hunger = 2; break;
            case equipments.high_food: hunger = 3; break;
            case equipments.low_incubator: growth = 1; break;
            case equipments.high_incubator: growth = 2; break;
            case equipments.wood_horseshoe: feel = 1; break;
            case equipments.iron_horseshoe: feel = 2; break;
            case equipments.high_barn: feel = 1; break;
            case equipments.old_grandfather_cloth: feel = 1; grwoth = 1; break;
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
}
