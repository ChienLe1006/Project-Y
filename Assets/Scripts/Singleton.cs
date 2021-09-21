using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    [SerializeField] private static bool isInactive;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(T)) as T;
            }
            return instance;
        }
    }

    public void Reset()
    {
        instance = null;
    }

    public static bool Exists()
    {
        return (instance != null);
    }
}
