using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using Presenter.Barn;

namespace View.Barn{
    public class BarnView : MonoBehaviour
    {
        BarnPresenter presenter;

        private string animal;
        private string[] messages;

        // Start is called before the first frame update
        void Awake()
        {
            presenter = new BarnPresenter(this);
        }

        public void setImage(string src) {
            Transform image = gameObject.transform.GetChild(0);
            image.GetComponent<Image>().sprite = Resources.Load<Sprite>(src);
        }

        public void actBtn(int n) {
            presenter.actAnimal(this.animal, this.messages[n]);
        }

        public void onDayEnd() {
            presenter.checkEnd();
        }

        public void setButton(string animal, string[] messages) {
            this.animal = animal;
            this.messages = messages;
            Transform panel = gameObject.transform.GetChild(2);
            for (int i = 0; i < 3; i++) {
                panel.GetChild(i).GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = this.messages[i];
            }
        }

        public void setMessage(string message) {
            TMPro.TextMeshProUGUI temp = GetComponentInChildren(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
            temp.text = message;
        }

        public void clearMessage() {
            TMPro.TextMeshProUGUI temp = GetComponentInChildren(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
            temp.text = "";
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
