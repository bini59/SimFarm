# SimFarm
Kumoh National Institute of Technology, Adventure Design Advanced Project ( team 6, 2022-2 )

## 목차
1. [MVP 패턴](#MVP패턴)
2. [Singleton](#Singleton)


### MVP패턴

Unity에서 기능의 분리를 위해 MVP패턴을 적용하였다.


#### Model
가장 중요한 데이터인, Animal, User를 Model로 만들었다. 
각각 Singleton 패턴을 적용하여서 전역에서 접근할 수 있도록 하였다.

또한 각 View가 사용할 수 있는 method를 지정한 interface를 만들어서 presenter가 참조하도록 하였다.

##### Singleton
class의 객체를 하나만 생성하는 방법이다.
```C#
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
```

#### View

각 Panel들을 View로 지정을 해서 사용자에게 보여지는 부분을 구성하였다.
> Panel 의 종류
- Game UI
- Main
- Story
- Shop
- Barn
- Day End
- Ending

#### Presenter

각 view의 presenter를 지정하였다.
각 presenter는 필요한 Model을 interface를 사용해서 참조하도록 하고, view를 생성할때 받아와서 사용한다.






