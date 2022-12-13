using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Presenter.Farm;

namespace View{
    namespace Farm{
        public class GuageView : MonoBehaviour
        {

            private GuagePresenter presenter;
            private int curEnergy;
            private int maxEnergy;

            private const float width = 160.1f;
            // Start is called before the first frame update
            void Awake()
            {
                presenter = new GuagePresenter(this);
                int[] energy = presenter.getEnergy();
                curEnergy = energy[0];
                maxEnergy = energy[1];
                UpdateEnergy(curEnergy);
            }

            public void UpdateEnergy(int energy) {
                Transform currentEnergy = gameObject.transform.GetChild(1);
                float curWidth = ((energy) / (float)maxEnergy) * width;

                RectTransform rectTran = currentEnergy.GetComponent<RectTransform>();
                rectTran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, curWidth);
            }

            // Update is called once per frame
            void Update()
            {
                
            }
        }

    }
}
