using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Presenter.Farm;

public class GoldView : MonoBehaviour
{
    private GoldPresenter presenter;
    private int gold;
    // Start is called before the first frame update
    void Awake()
    {
        this.presenter = new GoldPresenter();
        gold = presenter.getGold();
        string goldString = ""; int index = 0;
        while(gold > 0) {
            if(index%3 == 0 && goldString != "") {
                goldString = "," + goldString;
            }
            goldString = (gold % 10).ToString() + goldString;
            gold /= 10;
            index++;
        }
        gameObject.transform.GetChild(1).transform.GetComponent<TMPro.TextMeshProUGUI>().text = goldString;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
