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
            private animaltypes animaltypes;
            public AnimalModel()
            {
                animals = new Animal[6];
                index = 0;
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


            public animaltypes convertString(string animal) {
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
                return temp;
            }
            public string setState(string animal, ItemStat stat){
                animaltypes temp = convertString(animal);
                for (int i = 0; i < 6; i++) {
                    if(animals[i] == null) continue;
                    if (temp == animals[i].animalType()){
                        animals[i].setFeel(animals[i].getFeel()+stat.feel);
                        animals[i].setGrowth(animals[i].getFeel()+stat.growth);
                        animals[i].setHunger(animals[i].getHunger() + stat.hunger);
                    }
                }

                string result = "";
                if(stat.feel > 0) result += "기분이 좋아졌다!\n"; else if(stat.feel < 0) result += "기분이 나빠졌다...\n";
                if(stat.growth > 0) result += "쑥쑥 자라고 있는 느낌이다!\n"; else if(stat.growth < 0) result += "점점 초췌해지는 느낌이 든다...\n";
                if(stat.hunger > 0) result += "배가 차서 기뻐 보인다!\n"; else if(stat.hunger < 0) result += "배가 고파 보인다...\n";
                return result;
            }
            
            public void setAnimalTurn() {
                for (int i = 0; i < 6; i++) {
                    if(animals[i] != null){
                        animals[i].setTurn();
                    }
                }
            }
            public Animal[] getAnimalList()
            {
                int n = 0;
                Animal[] anm = new Animal[6];
                for (int i = 0; i < 6;i++) {
                    if(animals[i] != null && animals[i].getTurn() == 0) anm[n++] = animals[i];
                }
                
                return anm;
            }

            public Animal[] getExistAnimals() {
                int n = 0;
                Animal[] anm = new Animal[6];
                for (int i = 0; i < 6;i++) {
                    if(animals[i] != null) anm[n++] = animals[i];
                }
                
                return anm;
            }

            public int[] getAnimalState(Animal animal)
            {
                return animal.getDayendAnimalInfo();
            }


            public bool existAnimal(string animal) {
                animaltypes type = convertString(animal);
                for (int i = 0; i < 6; i++) {
                    if(animals[i] == null) continue;
                    if(animals[i].animalType() == type) return true;
                }
                return false;
            }

            public int getAnimalPrice(string animal) {
                animaltypes type = convertString(animal);
                int price = 0;
                switch (type)
                {
                    case animaltypes.Cow: price = 5000; break;
                    case animaltypes.Horse: price = 4000; break;
                    case animaltypes.Goat: price = 3000; break;
                    case animaltypes.Pig: price = 2000; break;
                    case animaltypes.Duck: price = 1500; break;
                    case animaltypes.Chicken: price = 1000; break;
                }
                return price;
            }

            public int calculateScore() {
                int score = 0;
                for (int i = 0; i < 6; i ++) {
                    if(animals[i] ==null) continue;
                    score += animals[i].getScore();
                }
                return score;
            }
        }
    }
}

