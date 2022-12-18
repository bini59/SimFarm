using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Simfarm;

namespace Model{
    namespace Animal{
        public class AnimalModel : MonoBehaviourSingletonTemplate<AnimalModel>, IFarmAnimal, IBarnAnimal, IShopAnimal, IDayendAnimal, IResultAnimal
        {
            private Animal[] animals;
            private int index;
            private int animalscore = 0;
            private animaltypes animaltypes;
            public AnimalModel()
            {
                animals = new Animal[6];
                index = 0;

                buyAnimal(animaltypes.Cow);
                buyAnimal(animaltypes.Horse);
                buyAnimal(animaltypes.Goat);
                buyAnimal(animaltypes.Chicken);
                buyAnimal(animaltypes.Duck);
                buyAnimal(animaltypes.Pig);
                // test for create button
            }
            public void buyAnimal(animaltypes animaltypes)
            {
                switch (animaltypes)
                {
                    case animaltypes.Cow:
                        animals[index++] = new Cow();
                        break;
                    case animaltypes.Horse:
                        animals[index++] = new Horse();
                        break;
                    case animaltypes.Goat:
                        animals[index++] = new Goat();
                        break;
                    case animaltypes.Duck:
                        animals[index++] = new Duck();
                        break;
                    case animaltypes.Pig:
                        animals[index++] = new Pig();
                        break;
                    case animaltypes.Chicken:
                        animals[index++] = new Chicken();
                        break;
                    default:
                        break;
                }

            }

            public string setState(string animal, ItemStat stat){
                animaltypes temp = 0;
                switch (animal)
                {
                    case "Pig" : temp = animaltypes.Pig; break;
                    case "Goat" : temp = animaltypes.Goat; break;
                    case "Chicken" : temp = animaltypes.Chicken; break;
                    case "Horse" : temp = animaltypes.Horse; break;
                    case "Duck" : temp = animaltypes.Duck; break;
                    case "Cow" : temp = animaltypes.Cow; break;
                }
                for (int i = 0; i < 6; i++) {
                    if (temp == animals[i].animalType()){
                        animals[i].setFeel(animals[i].getFeel()+stat.feel);
                        animals[i].setGrowth(animals[i].getFeel()+stat.growth);
                        animals[i].setHunger(animals[i].getHunger() + stat.hunger);
                    }
                }

                string result = "";
                if(stat.feel > 0) result += "animal feels good\n"; else if(stat.feel < 0) result += "animal feels bad\n";
                if(stat.growth > 0) result += "animal grow up\n"; else if(stat.growth < 0) result += "animal grow down\n";
                if(stat.hunger > 0) result += "animal feels full\n"; else if(stat.hunger < 0) result += "animal feels hungry\n";
                return result;
            }

            public Animal[] getAnimalList()
            {
                return animals;
            }

            public int[] getAnimalState(Animal animal)
            {
                return animal.getDayendAnimalInfo();
            }
            public void setAnimalScore(int score)
            {
                this.animalscore = score;
            }
            public int getAnimalScore()
            {
                return this.animalscore;
            }
            public animaltypes GetAnimaltypes()
            {
                return animaltypes;
            }
        }
    }
}

