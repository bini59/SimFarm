using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoBehaviourSingletonTemplate<T> : MonoBehaviour where T : MonoBehaviour
{
    static T m_Instance = null;
    public static T Instance
    {
        get
        {
            if (m_Instance == null)
            {
                var obj = new GameObject(typeof(T).Name);
                m_Instance = obj.AddComponent<T>();
            }
            return m_Instance;
        }
    }
    
    protected void Awake()
    {
    	DontDestroyOnLoad(gameObject);
    }
}