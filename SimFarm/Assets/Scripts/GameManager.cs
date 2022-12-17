using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

using View.Barn;
using View.Farm;
using Model.User;

namespace Simfarm{
    public class GameManager : MonoBehaviourSingletonTemplate<GameManager>
    {
        private GameObject barn;
        private GameObject shop;
        private GameObject uiEnergy;
        private GameObject uiEnter;
        private GameObject dayend;
        private GameObject end;
        private GameObject player;

        public void toggleBarn(string source) {
            barn.SetActive(!barn.activeSelf);
            barn.GetComponent<BarnView>().setImage(source);
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

        public void onEnter(string source) {
            uiEnter.SetActive(true);
            PlayerAction player = GameObject.Find("Player").transform.GetComponent<PlayerAction>();
            UnityAction listener = (source.Equals("Shop")) 
            ? delegate { toggleShop(); this.offEnter(); player.moveToggle(); }
            : delegate { toggleBarn(source); this.offEnter(); player.moveToggle(); };
            uiEnter.GetComponent<Button>().onClick.AddListener(listener);
        }
        public void offEnter() {
            uiEnter.SetActive(false);
            uiEnter.GetComponent<Button>().onClick.RemoveAllListeners();

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
            this.player = GameObject.Find("Player");
        }
    }
}

