using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using View.Barn;

namespace Simfarm{
    public class GameManager : MonoBehaviourSingletonTemplate<GameManager>
    {
        [SerializeField]
        private GameObject barn;
        private GameObject shop;
        private GameObject ui;
        private GameObject dayend;
        private GameObject end;

        public void toggleBarn(string source) {
            barn.SetActive(!barn.activeSelf);
            barn.GetComponent<BarnView>().setImage(source);
        }

        public void toggleShop() {
            shop.SetActive(!shop.activeSelf);
        }
 
        void Awake() {
            barn = GameObject.Find("Canvas").transform.GetChild(0).gameObject;
            shop = GameObject.Find("Canvas").transform.GetChild(2).gameObject;
            end = GameObject.Find("Canvas").transform.GetChild(3).gameObject;
            dayend = GameObject.Find("Canvas").transform.GetChild(5).gameObject;
            ui = GameObject.Find("Canvas").transform.GetChild(6).gameObject;
        }
    }
}

