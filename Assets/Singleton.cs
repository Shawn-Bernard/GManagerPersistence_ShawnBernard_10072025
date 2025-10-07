using UnityEngine;

public class Singleton<Type> : MonoBehaviour where Type : MonoBehaviour
{
    [SerializeField] bool canDestroy = true;

    static Type instance;
    public static Type Instance
    {
        get
        {
            if (instance == null) // if null find game manager in scene
            {
                instance = GameObject.FindAnyObjectByType<Type>();
                if (instance != null)
                {
                    GameObject GM = new GameObject(typeof(Type).Name);
                    instance = GM.AddComponent<Type>();
                }
            }
            return instance;
        }
    }

    private void Start()
    {
        InstanceCheck();
    }

    void InstanceCheck()
    {
        if (canDestroy)
        {
            if (instance != null)
            {
                Destroy(this.gameObject);
                return;
            }
            else
            {
                DontDestroyOnLoad(this.gameObject);
            }

            instance = this as Type;
        }
        else
        {
            Debug.Log("Can't destroy self");
        }
    }
}
