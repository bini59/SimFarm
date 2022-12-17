using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

using View.Barn;
using View.Farm;

namespace Simfarm{
    public class GameManager : MonoBehaviourSingletonTemplate<GameManager>
    {
        [SerializeField]
        private GameObject barn;
        private GameObject shop;
        private GameObject uiEnergy;
        private GameObject uiEnter;
        private GameObject dayend;
        private GameObject end;

        public void toggleBarn(string source) {
            barn.SetActive(!barn.activeSelf);
            barn.GetComponent<BarnView>().setImage(source);
        }

        public void toggleShop() {
            shop.SetActive(!shop.activeSelf);
        }

        public void onEnter(string source) {
            uiEnter.SetActive(true);
            UnityAction listener = (source.Equals("Shop")) ? delegate { toggleShop(); this.offEnter();  } : delegate { toggleBarn(source); this.offEnter(); };
            uiEnter.GetComponent<Button>().onClick.AddListener(listener);
        }
        public void offEnter() {
            uiEnter.SetActive(false);
        }

        public void redueceEnergy() {
            uiEnergy.transform.GetChild(1).gameObject.GetComponent<GuageView>().redueceEnergy();
        }
 
        void Awake() {
            this.barn = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
            this.shop = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
            this.end = GameObject.Find("Canvas").transform.GetChild(3).gameObject;
            this.dayend = GameObject.Find("Canvas").transform.GetChild(5).gameObject;
            Transform ui = GameObject.Find("Canvas").transform.GetChild(6);
            this.uiEnter = ui.GetChild(0).gameObject;
            this.uiEnergy = ui.GetChild(1).gameObject;
        }
    }
}

