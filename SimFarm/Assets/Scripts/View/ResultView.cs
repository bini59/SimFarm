using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using Model;
using Model.User;
using Model.Animal;

using Presenter.Result;

namespace View
{
    namespace Result
    {
        public class ResultView : MonoBehaviour
        {
            private GameObject[] endPanel;
            private GameObject dayresult;
            private ResultPresenter resultPresenter;
            private float posX = 0.0F;
            private float posY = 60.0F;
            private float posZ = 0F;
            private float maxGold = 27240.0f;
            private float maxDay = 30.0f;

            private void Start()
            {
                resultPresenter = new ResultPresenter();
                Animal[] animallist = resultPresenter.getAnimalInfo();

                GameObject resultGold = Instantiate(Resources.Load("Prefabs/ScorePrefabs/GoldScore")) as GameObject;
                resultGold.transform.SetParent(GameObject.Find("Canvas").transform, false);
                string message;
                message = "골드점수 : " + (int)(resultPresenter.getResultUserMoney() / maxGold * maxDay);
                resultPresenter.setTotalScore((int)(resultPresenter.getResultUserMoney() / maxGold * maxDay));
                resultGold.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = message;
                //resultGold.transform.localPosition = new Vector3(posX, posY, posZ);
                resultGold.transform.parent = gameObject.transform;
                for (int i = 0; i < animallist.Length; i++)
                {
                    if (animallist[i] != null)
                    {
                        GameObject animal = Instantiate(Resources.Load("Prefabs/DayendAnimal")) as GameObject;
                        if (animallist[i].animalType() == animaltypes.Cow)
                        {
                            animal = Instantiate(Resources.Load("Prefabs/ScorePrefabs/CowScore")) as GameObject;
                        }
                        if (animallist[i].animalType() == animaltypes.Horse)
                        {
                            animal = Instantiate(Resources.Load("Prefabs/ScorePrefabs/HorseScore")) as GameObject;
                        }
                        if (animallist[i].animalType() == animaltypes.Goat)
                        {
                            animal = Instantiate(Resources.Load("Prefabs/ScorePrefabs/GoatScore")) as GameObject;
                        }
                        if (animallist[i].animalType() == animaltypes.Pig)
                        {
                            animal = Instantiate(Resources.Load("Prefabs/ScorePrefabs/PigScore")) as GameObject;
                        }
                        if (animallist[i].animalType() == animaltypes.Duck)
                        {
                            animal = Instantiate(Resources.Load("Prefabs/ScorePrefabs/DuckScore")) as GameObject;
                        }
                        if (animallist[i].animalType() == animaltypes.Chicken)
                        {
                            animal = Instantiate(Resources.Load("Prefabs/ScorePrefabs/ChickenScore")) as GameObject;
                        }
                        animal.transform.SetParent(GameObject.Find("Canvas").transform, false);
                        resultPresenter.setAnimalScore(animallist[i].getScore());
                        resultPresenter.setTotalScore(animallist[i].getScore());
                        message = "점수 : " + resultPresenter.getAnimalScore();
                        animal.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = message;
                        animal.transform.parent = gameObject.transform;
                    }
                }
                GameObject totalscore = Instantiate(Resources.Load("Prefabs/ScorePrefabs/TotalScore")) as GameObject;
                totalscore.transform.SetParent(GameObject.Find("Canvas").transform, false);
                message = "최종점수 : " + resultPresenter.getTotalScore();
                totalscore.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = message;
                totalscore.transform.parent = gameObject.transform;
            }
        }
    }
}

