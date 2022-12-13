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
            private bool isOwned = false;
            private animaltypes animaltypes;
            public AnimalModel()
            {
                animals = new Animal[6];
                index = 0;

                buyAnimal();
                buyAnimal();
                buyAnimal();
                // test for create button
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
            
            public Animal[] getAnimalList()
            {
                return animals;
            }

            public int[] getAnimalState(Animal animal)
            {
                return animal.getDayendAnimalInfo();
            }

            public bool getIsOwned()
            {
                return isOwned;
            }

            public animaltypes GetAnimaltypes()
            {
                return animaltypes;
            }
        }
    }
}

