using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using Presenter.Barn;

namespace View.Barn{
    public class BarnView : MonoBehaviour
    {
        BarnPresenter presenter;

        // Start is called before the first frame update
        void Awake()
        {
            presenter = new BarnPresenter(this);
        }

        public void actBtn() {
            presenter.actAnimal();
        }

        public void setMessage() {
            TMPro.TextMeshProUGUI temp = GetComponentInChildren(typeof(TMPro.TextMeshProUGUI)) as TMPro.TextMeshProUGUI;
            temp.text = "temp text";
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
