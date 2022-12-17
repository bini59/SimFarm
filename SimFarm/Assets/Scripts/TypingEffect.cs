using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingEffect : MonoBehaviour
{
    public Text[] tx;
    AudioSource audioSource; 

    public string[] m_text = new string[] { "현대의 복잡한 인간관계, 삶에 지쳐 귀성길에 오른 주인공.\n 농사지으며 조금 내려놓은 채로 살기위해서 내려왔다.",
                                     "하지만 농사를 짓는 것도 공부를 하고, 연구를 해야 했다.",
                                     "열심히 이론공부는 했지만, 실전을 겪어보지 못한 주인공.\n20살부터 37년간 농사를 지어오신\n삼촌의 농장에서 실전을 겪어보기로 한다." };

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        StartCoroutine(_typing());
    }


    IEnumerator _typing()
    {
        yield return new WaitForSeconds(2f);
        for (int j = 0; j <= tx.Length-1; j++)
        {
            for (int i = 0; i <= m_text[j].Length; i++)
            {
                tx[j].text = m_text[j].Substring(0, i);
                if(!tx[j].text.Equals(' ')  || !tx[j].text.Equals('.'))
                    audioSource.Play();
                yield return new WaitForSeconds(0.08f);
            }
            yield return new WaitForSeconds(1f);
        }
    }
        

}

