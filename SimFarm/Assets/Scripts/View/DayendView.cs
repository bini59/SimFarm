using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using Model;
using Model.User;
using Model.Animal;
using Presenter.Dayend;

namespace View
{
    namespace Dayend
    {
        public class DayendView : MonoBehaviour
        {
            private GameObject[] endPanel;
            private GameObject dayresult;
            private DayendPresenter dayendPresenter;
            private float posX = 0F;
            private float posY = 60.0F;
            private float posZ = 0F;
            private int day = 1;

            // Start is called before the first frame update
            void Start()
            {
                endPanel = GameObject.FindGameObjectsWithTag("endPanel");
                dayresult = GameObject.FindGameObjectsWithTag("dayResult")[0];
                dayendPresenter = new DayendPresenter();
                Animal[] animallist = dayendPresenter.getAnimalInfo();
                dayendPresenter.setDay(day);
                day++;
                string message;
                message = dayendPresenter.getDay() + " Day";
                dayresult.transform.GetComponent<TMPro.TextMeshProUGUI>().text = message;

                GameObject unclegold = Instantiate(Resources.Load("Prefabs/UncleGold")) as GameObject;
                unclegold.transform.SetParent(GameObject.Find("Canvas").transform, false);
                unclegold.transform.GetChild(0).transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = dayendPresenter.getUncleMoney().ToString();
                unclegold.transform.parent = gameObject.transform;

                dayendPresenter.setDayendUserMoney(dayendPresenter.getUncleMoney());
                for (int i = 0; i < animallist.Length; i++)
                {
                    if (animallist[i] != null)
                    {
                        //Debug.Log(i);
                        animallist[i].setTurn();
                        if(animallist[i].getTurn() == 0)
                        {
                            GameObject animal = Instantiate(Resources.Load("Prefabs/DayendAnimal")) as GameObject;
                            if(animallist[i].animalType() == animaltypes.Cow)
                            {
                                animal = Instantiate(Resources.Load("Prefabs/DayendCow")) as GameObject;
                            }
                            if (animallist[i].animalType() == animaltypes.Horse)
                            {
                                animal = Instantiate(Resources.Load("Prefabs/DayendHorse")) as GameObject;
                            }
                            if (animallist[i].animalType() == animaltypes.Goat)
                            {
                                animal = Instantiate(Resources.Load("Prefabs/DayendGoat")) as GameObject;
                            }
                            if (animallist[i].animalType() == animaltypes.Pig)
                            {
                                animal = Instantiate(Resources.Load("Prefabs/DayendPig")) as GameObject;
                            }
                            if (animallist[i].animalType() == animaltypes.Duck)
                            {
                                animal = Instantiate(Resources.Load("Prefabs/DayendDuck")) as GameObject;
                            }
                            if (animallist[i].animalType() == animaltypes.Chicken)
                            {
                                animal = Instantiate(Resources.Load("Prefabs/DayendChicken")) as GameObject;
                            }
                            animal.transform.SetParent(GameObject.Find("Canvas").transform, false);
                            animal.transform.GetChild(0).transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = animallist[i].getTurnMoney().ToString();
                            dayendPresenter.setDayendUserMoney(animallist[i].getTurnMoney());
                            animal.transform.localPosition = new Vector3(posX, posY, posZ);
                            animal.transform.parent = gameObject.transform;
                        }
                    }
                }

                GameObject totalGold = Instantiate(Resources.Load("Prefabs/TotalGold")) as GameObject;
                totalGold.transform.SetParent(GameObject.Find("Canvas").transform, false);
                totalGold.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text =
                    dayendPresenter.getDayendUserMoney().ToString();
                totalGold.transform.localPosition = new Vector3(posX, posY, posZ);
                totalGold.transform.parent = gameObject.transform;
            }

            // Update is called once per frame
            void Update()
            {
                if (Input.GetMouseButton(0))
                {
                    endPanel[0].gameObject.SetActive(false);
                }
            }
        }
    }
}
