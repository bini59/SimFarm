using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingEffect : MonoBehaviour
{
    public Text[] tx;
    bool txstate=true;

    public string[] m_text = new string[] { "������ ������ �ΰ�����, � ���� �ͼ��濡 ���� ���ΰ�.\n ��������� ���� �������� ä�� ������ؼ� �����Դ�.",
                                     "������ ��縦 ���� �͵� ���θ� �ϰ�, ������ �ؾ� �ߴ�.",
                                     "������ �̷а��δ� ������, ������ �޾�� ���� ���ΰ�.\n20����� 37�Ⱓ ��縦 �������\n������ ���忡�� ������ �޾��� �Ѵ�." };


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
                yield return new WaitForSeconds(0.08f);
            }
            
            yield return new WaitForSeconds(1f);
        }
        txstate = false;
        if (!txstate)
        {
            Debug.Log("Text END");
        }
    }
    


}

