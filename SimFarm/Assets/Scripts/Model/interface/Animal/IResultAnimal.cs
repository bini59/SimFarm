using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model.Animal;
public interface IResultAnimal
{
    public Animal[] getAnimalList();
    public Animal getAnimalState(Animal animal);
}
