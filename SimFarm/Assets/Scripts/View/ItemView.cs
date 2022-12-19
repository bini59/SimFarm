using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

using Model;
using Model.User;
using Presenter.Shop;

namespace View{
    namespace Shop{        
        public class ItemView : MonoBehaviour
        {   
            private GameObject shop;
            private ItemPresenter user;
            private Equipment equipment;

            // Start is called before the first frame update
            void Start()
            {
                user = new ItemPresenter();
                shop = GameObject.FindGameObjectsWithTag("ShopMessage")[0];
            }

            // Update is called once per frame
            void Update()
            {
                
            }
            public void setEquipment(Equipment e) {
                equipment = e;
            }

            public void click() {
                ShopAudio Shop = GameObject.Find("Shop").GetComponent<ShopAudio>();
                Shop.clickButton();
                bool res = user.buyEquipment(equipment);
                string message;
                message = res ? equipment.equipmentName() + "을(를) 구매했습니다" : "돈이 부족해요!!";
                shop.transform.GetComponent<TMPro.TextMeshProUGUI>().text = message;
                if (res)
                {
                    Destroy(gameObject); // remove when buy success
                    Shop.purchaseSuccess();
                }
            }
        }
    }
}
