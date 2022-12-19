using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model.Animal;
public interface IResultAnimal
{
    public Animal[] getExistAnimals();
    public int[] getAnimalState(Animal animal);
    public void setAnimalScore(int score);
    public int getAnimalScore();
}
