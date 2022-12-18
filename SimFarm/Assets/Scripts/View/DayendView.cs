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

            private GameObject[] animalObjects = new GameObject[6];
            private GameObject uncle;
            private GameObject totalGold;

            // Start is called before the first frame update
            void Awake()
            {
                endPanel = GameObject.FindGameObjectsWithTag("endPanel");
                dayresult = GameObject.FindGameObjectsWithTag("dayResult")[0];
                dayendPresenter = new DayendPresenter(this);
                for (int i = 0; i < 6; i++) animalObjects[i] = null;   
            }
            void OnEnable() {
                dayendPresenter.setDay();
                dayendPresenter.processGold();
            }

            private void setAnimalInstance(Animal animal, int index) {
                switch (animal.animalType())
                {
                    case animaltypes.Cow: animalObjects[index] = Instantiate(Resources.Load("Prefabs/DayendCow")) as GameObject; break;
                    case animaltypes.Goat: animalObjects[index] = Instantiate(Resources.Load("Prefabs/DayendGoat")) as GameObject; break;
                    case animaltypes.Horse: animalObjects[index] = Instantiate(Resources.Load("Prefabs/DayendHorse")) as GameObject; break;
                    case animaltypes.Pig: animalObjects[index] = Instantiate(Resources.Load("Prefabs/DayendPig")) as GameObject; break;
                    case animaltypes.Duck: animalObjects[index] = Instantiate(Resources.Load("Prefabs/DayendDuck")) as GameObject; break;
                    case animaltypes.Chicken: animalObjects[index] = Instantiate(Resources.Load("Prefabs/DayendChicken")) as GameObject; break;
                }

                animalObjects[index].transform.SetParent(GameObject.Find("Canvas").transform, false);
                animalObjects[index].transform.GetChild(0).transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = animal.getTurnMoney().ToString();
                    dayendPresenter.setDayendUserMoney(animal.getTurnMoney());
                animalObjects[index].transform.localPosition = new Vector3(posX, posY, posZ);
                animalObjects[index].transform.parent = gameObject.transform;
            }
            
            public void setTotalGold(int money) {
                totalGold = Instantiate(Resources.Load("Prefabs/TotalGold")) as GameObject;
                totalGold.transform.SetParent(GameObject.Find("Canvas").transform, false);
                totalGold.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text =
                    money.ToString();
                totalGold.transform.localPosition = new Vector3(posX, posY, posZ);
                totalGold.transform.parent = gameObject.transform;
            }
            public void setPanel(Animal[] animals, int money, int unclemoney) {
                this.uncle = Instantiate(Resources.Load("Prefabs/UncleGold")) as GameObject;
                uncle.transform.SetParent(GameObject.Find("Canvas").transform, false);
                uncle.transform.GetChild(0).transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = unclemoney.ToString();
                uncle.transform.parent = gameObject.transform;

                for (int i = 0; i < 6; i++){
                    if(animals[i] == null) continue;
                    setAnimalInstance(animals[i], i);
                }
                setTotalGold(money);
            }

            public void clearPanel() {
                GameObject.Destroy(this.uncle);
                GameObject.Destroy(this.totalGold); 
                for (int i = 0; i < animalObjects.Length; i++) {
                    if(animalObjects[i] == null) continue;
                    GameObject.Destroy(animalObjects[i]); animalObjects[i] = null;
                }
            }

            public void setDay(int day) {
                string message;
                message = day + " Day";
                dayresult.transform.GetComponent<TMPro.TextMeshProUGUI>().text = message;
            }
            public void dayEnd() {
                clearPanel();
                dayendPresenter.dayEnd();
            }
        }
    }
}
