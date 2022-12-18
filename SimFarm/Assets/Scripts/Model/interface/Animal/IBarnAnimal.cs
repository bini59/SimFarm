using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model.Animal;
using Model;
public interface IBarnAnimal
{
    public int[] getAnimalState(Animal animal);
    public string setState(string animal, ItemStat stat);
}
