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

                buyAnimal(animaltypes.Cow);
                buyAnimal(animaltypes.Horse);
                buyAnimal(animaltypes.Goat);
                buyAnimal(animaltypes.Chicken);
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

