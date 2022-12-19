using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Enum;
using Model;
using Presenter.Shop;

namespace View{
    namespace Shop {
        public class ShopView : MonoBehaviour
        {
            private ShopPresenter shopPresenter;
            private float initX = 175F;
            private float initY = -52.5777F;
            private float initZ = 0;
            private float space = 105.155F;
            // Start is called before the first frame update

            private Equipment[] shopEquipment;
            private GameObject[] equipments;
            void Start()
            {   
                shopPresenter = new ShopPresenter();
                equipments = new GameObject[17];
                structShop();
            }

            public void structShop() {
                shopEquipment = shopPresenter.getShopEquipment();
                for (int i = 0; i < shopEquipment.Length; i++) {
                    GameObject equipment = Instantiate(Resources.Load("Prefabs/Equipment")) as GameObject;
                    equipment.transform.SetParent(GameObject.Find("Canvas").transform, false);
                    equipment.transform.localPosition = new Vector3(initX, initY + space * i, initZ);
                    equipment.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetComponent<TMPro.TextMeshProUGUI>().text = shopEquipment[i].equipmentName();
                    equipment.transform.GetComponent<ItemView>().setEquipment(shopEquipment[i]);
                    equipment.transform.parent = gameObject.transform;
                    equipments[i] = equipment;
                }
            }

            public void destoryItem() {
                foreach (var i in equipments){
                    Destroy(i);
                }
            }

            // Update is called once per frame
            void Update()
            {
                
            }
        }
    }
}
