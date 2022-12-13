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

            AnimalModel()
            {
                animals = new Animal[6];
                index = 0;

                // test for create button
                buyAnimal();
                buyAnimal();
            }
            public enum userInput
            {
                Feed,
                useItem
            }
            public void buyAnimal()
            {
                animals[index++] = new Animal();
            }
            public void setAnimalState(userInput userinput , Animal.animalType animal)
            {
                index = (int)animal;
                animals[index].setState((int)userinput); // 이건 제대로 작동 안할거같ㅇㄴ데
            }
            public Animal[] getAnimalList()
            {
                return animals;
            }

            public Animal getAnimalState(Animal animal)
            {
                return animal;
            }
        }
    }
}

