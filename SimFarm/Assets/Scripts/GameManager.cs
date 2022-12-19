using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

using View;
using View.Barn;
using View.Farm;
using Model.User;
using Model;
using Model.Animal;

namespace Simfarm{
    public class GameManager : MonoBehaviourSingletonTemplate<GameManager>
    {
        private GameObject barn;
        private GameObject shop;
        private GameObject uiEnergy;
        private GameObject uiEnter;
        private GameObject uiBuy;
        private GameObject dayend;
        private GameObject end;
        private GameObject player;
        private GameObject pause;


        void Update() {
            if(Input.GetButtonDown("Cancel") && !GameObject.Find("Canvas").transform.GetChild(1).gameObject.activeSelf && !pause.activeSelf) {
                pause.SetActive(true);
            }
            else if(Input.GetButtonDown("Cancel") && pause.activeSelf) {
                pause.SetActive(false);
            }
        }

        public void initialize() {
            UserModel.Instance.initialize();
            AnimalModel.Instance.initialize();
        }

        public void updateGold() {
            int gold = UserModel.Instance.getDayendUserMoney();
            uiEnergy.transform.GetChild(3).gameObject.GetComponent<GoldView>().updateGold(gold);
        }
        public void toggleBarn(string input) {
            barn.SetActive(!barn.activeSelf);
            barn.GetComponent<BarnView>().setImage("BarnAnimal/"+input);

            string[] messages = Message.getMessage(input);
            barn.GetComponent<BarnView>().setButton(input, messages);
        }

        public void updateTime() {
            int day = UserModel.Instance.getDay();
            GameObject timeText = uiEnergy.transform.GetChild(2).GetChild(1).gameObject;
            timeText.GetComponent<TMPro.TextMeshProUGUI>().text = string.Format("Day {0}", day);
        }

        public void toggleShop() {
            shop.SetActive(!shop.activeSelf);
        }

        public void toggleDay() {
            dayend.SetActive(!dayend.activeSelf);
        }

        public void onEnding() {
            end.SetActive(true);
        }

        public void onEnter(string input) {
            if(!input.Equals("Shop") && !AnimalModel.Instance.existAnimal(input)) {
                uiBuy.SetActive(true);
                int price = AnimalModel.Instance.getAnimalPrice(input);
                uiBuy.GetComponent<AnimalBuyView>().setPrice(price, input);
                return;
            }


            uiEnter.SetActive(true);
            PlayerAction player_action = player.transform.GetComponent<PlayerAction>();
            UnityAction listener = (input.Equals("Shop")) 
            ? delegate { toggleShop(); this.offEnter(); player_action.moveToggle(); }
            : delegate { toggleBarn(input); this.offEnter(); player_action.moveToggle(); };
            uiEnter.GetComponent<Button>().onClick.AddListener(listener);
        }
        public void offEnter() {
            uiEnter.SetActive(false);
            uiEnter.GetComponent<Button>().onClick.RemoveAllListeners();
            uiBuy.SetActive(false);
            uiBuy.GetComponent<Button>().onClick.RemoveAllListeners();
        }

        public void onDayEnd() {
            player.transform.position = new Vector3(1.72f, 0.66f, 0);
            UserModel.Instance.setEnergyFull();
            toggleEnergy();
        }

        public void toggleEnergy() {
            uiEnergy.SetActive(!uiEnergy.activeSelf);
        }

        public void redueceEnergy() {
            uiEnergy.transform.GetChild(1).gameObject.GetComponent<GuageView>().redueceEnergy();
        }
 
        void Awake() {
            this.barn = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
            this.shop = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
            this.end = GameObject.Find("Canvas").transform.GetChild(5).gameObject;
            this.dayend = GameObject.Find("Canvas").transform.GetChild(3).gameObject;
            Transform ui = GameObject.Find("Canvas").transform.GetChild(6);
            this.uiEnter = ui.GetChild(0).gameObject;
            this.uiEnergy = ui.GetChild(1).gameObject;
            this.uiBuy = ui.GetChild(2).gameObject;
            this.player = GameObject.Find("Player");
            this.pause = GameObject.Find("Canvas").transform.GetChild(7).gameObject;
        }
    }
}

