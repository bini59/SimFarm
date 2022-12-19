using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Presenter;

namespace View{

    public class AnimalBuyView : MonoBehaviour
    {
        private int price;
        private string animal;
        private AnimalBuyPresenter presenter;

        [SerializeField]
        private GameObject ui;

        void Awake() {
            presenter = new AnimalBuyPresenter(this);
        }

        public void setPrice(int price, string animal) {
            this.price = price;
            this.animal = animal;
            gameObject.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = string.Format("{0}G", price);
        }

        public void buyAnimal() {
            presenter.buyAnimal(animal, price);
        }

        public void offButton() {
            ui.GetComponent<AudioSource>().Play();
            gameObject.SetActive(false);
        }
    }
}
