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
            // private float posX = 0.0F;
            // private float posY = 60.0F;
            // private float posZ = 0F;

            private GameObject[] instances;

            void Start()
            {
                resultPresenter = new ResultPresenter(this);
                resultPresenter.processScore();
            }

            public void setResultPanel(int[] scores, Animal[] animals) {
                int n_instance = 1;
                for (int i = 0; i < 7; i ++) if(scores[i] != -1) n_instance++;
                instances = new GameObject[n_instance];

                int index = 0; int score = 0;
                goldScore(scores[6], index++); score += scores[6];
                for (int i = 0; i < 6; i++) {
                    if(scores[i] == -1) continue;
                    animalScore(scores[i], index++, animals[i].animalType());
                    score += scores[i];
                }
                totalSocre(score, index++);
            }

            private void goldScore(int score, int index) {
                instances[index] = Instantiate(Resources.Load("Prefabs/ScorePrefabs/GoldScore")) as GameObject;
                instances[index].transform.SetParent(GameObject.Find("Canvas").transform, false);
                instances[index].transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text =  "골드점수 : " + score;
                instances[index].transform.parent = gameObject.transform;
            }

            private void animalScore(int score, int index, animaltypes type) {
                instances[index] = Instantiate(Resources.Load("Prefabs/DayendAnimal")) as GameObject;
                instances[index] = Instantiate(Resources.Load("Prefabs/ScorePrefabs/CowScore")) as GameObject;
                switch (type)
                {
                    case animaltypes.Cow:    
                        instances[index] = Instantiate(Resources.Load("Prefabs/ScorePrefabs/CowScore")) as GameObject;
                        break;
                    case animaltypes.Horse:    
                        instances[index] = Instantiate(Resources.Load("Prefabs/ScorePrefabs/HorseScore")) as GameObject;
                        break;
                    case animaltypes.Duck:    
                        instances[index] = Instantiate(Resources.Load("Prefabs/ScorePrefabs/DuckScore")) as GameObject;
                        break;
                    case animaltypes.Chicken:    
                        instances[index] = Instantiate(Resources.Load("Prefabs/ScorePrefabs/ChickenScore")) as GameObject;
                        break;
                    case animaltypes.Pig:    
                        instances[index] = Instantiate(Resources.Load("Prefabs/ScorePrefabs/PigsScore")) as GameObject;
                        break;
                    case animaltypes.Goat:    
                        instances[index] = Instantiate(Resources.Load("Prefabs/ScorePrefabs/GoatScore")) as GameObject;
                        break;
                }
                instances[index].transform.SetParent(GameObject.Find("Canvas").transform, false);
                instances[index].transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "점수 : " + score;
                instances[index].transform.parent = gameObject.transform;
            }

            private void totalSocre(int score, int index) {
                instances[index] = Instantiate(Resources.Load("Prefabs/ScorePrefabs/TotalScore")) as GameObject;
                instances[index].transform.SetParent(GameObject.Find("Canvas").transform, false);
                instances[index].transform.GetChild(0).transform.GetChild(0).GetComponent<Text>().text = "최종점수 : " + score;
                instances[index].transform.parent = gameObject.transform;
            }
        }
    }
}

