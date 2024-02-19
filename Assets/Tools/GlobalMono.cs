using UnityEngine;

public class GlobalMono : MonoBehaviour
{
    public static GlobalMono Instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new GameObject("Global Mono").AddComponent<GlobalMono>();
            }

            return _instance;
        }
    }

    private static GlobalMono _instance;
}