using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Presenter.Farm;
using Model.Animal;

namespace View.Farm{

    public class FarmView : MonoBehaviour
    {
        private Vector3 start;
        private Vector3 distance;
        private FarmPresenter presenter;

        [SerializeField]
        private GameObject shop;
        [SerializeField]
        private GameObject mainUI;
        // Start is called before the first frame update
        void Awake()
        {
            presenter = new FarmPresenter(this);
            start = new Vector3(75, -75, 0);
            distance = new Vector3(0, -152, 0);
        }

        private void showShop() {
            shop.SetActive(true);
            mainUI.SetActive(false);
        }

        public void createShop(Vector3 position) {
            GameObject shop = Instantiate(Resources.Load("Prefabs/ActivateBarnBtn")) as GameObject;
            shop.transform.SetParent(GameObject.Find("Canvas").transform, false);
            shop.transform.localPosition = position;
            shop.transform.parent = gameObject.transform;
            shop.transform.GetComponent<Button>().onClick.AddListener(showShop);
        }

        public void createButton(Animal[] animals) {
            Vector3 position = start;

            for (int i = 0; i < animals.Length; i++) {
                if(animals[i] == null) break;
                GameObject animal = Instantiate(Resources.Load("Prefabs/ActivateBarnBtn")) as GameObject;
                animal.transform.SetParent(GameObject.Find("Canvas").transform, false);
                animal.transform.localPosition = position;
                animal.transform.parent = gameObject.transform;
                position += distance;
            }
            createShop(position);
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
