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
            private GameObject total;
            private GameObject unclegold;
            private DayendPresenter dayendPresenter;
            private float posX = 0F;
            private float posY = 60.0F;
            private float posZ = 0F;
            private float space = 60F;
            private int day = 1;

            // Start is called before the first frame update
            void Start()
            {
                endPanel = GameObject.FindGameObjectsWithTag("endPanel");
                dayresult = GameObject.FindGameObjectsWithTag("dayResult")[0];
                //total = GameObject.FindGameObjectsWithTag("totalGold")[0];
                dayendPresenter = new DayendPresenter();
                Animal[] animallist = dayendPresenter.getAnimalInfo();
                dayendPresenter.setDay(day++);  //여기 인수에 model의 현재 day 값을 가져오고 싶은데.. => view의 day를 기준으로  하면 되잖아!
                string message;
                message = dayendPresenter.getDay() + " Day";
                dayresult.transform.GetComponent<TMPro.TextMeshProUGUI>().text = message;

                GameObject unclegold = Instantiate(Resources.Load("Prefabs/UncleGold")) as GameObject;
                unclegold.transform.SetParent(GameObject.Find("Canvas").transform, false);
                unclegold.transform.GetChild(0).transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = dayendPresenter.getUncleMoney().ToString();
                unclegold.transform.parent = gameObject.transform;

                dayendPresenter.setDayendUserMoney(dayendPresenter.getUncleMoney());
                //int abcd = animallist[1].getTurnMoney();
                //Debug.Log(animallist.Length);
                for (int i = 0; i < animallist.Length; i++)
                {
                    //GameObject animal = Instantiate(Resources.Load("Prefabs/DayendAnimal")) as GameObject;
                    //Debug.Log(animal.transform.GetChild(0).transform.GetChild(0));
                    if (animallist[i] != null)
                    {
                        //Debug.Log(i);
                        GameObject animal = Instantiate(Resources.Load("Prefabs/DayendAnimal")) as GameObject;
                        animal.transform.SetParent(GameObject.Find("Canvas").transform, false);
                        animal.transform.GetChild(0).transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = animallist[i].getTurnMoney().ToString();
                        dayendPresenter.setDayendUserMoney(animallist[i].getTurnMoney());
                        animal.transform.localPosition = new Vector3(posX, posY, posZ);
                        animal.transform.parent = gameObject.transform;
                    }
                    /*animal.transform.SetParent(GameObject.Find("Canvas").transform, false);
                    animal.transform.GetChild(0).transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = "1000"; *//*animallist[i].getTurnMoney().ToString();*//*
                    dayendPresenter.setDayendUserMoney(1000);
                    animal.transform.localPosition = new Vector3(posX, posY, posZ);
                    animal.transform.parent = gameObject.transform;*/

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
