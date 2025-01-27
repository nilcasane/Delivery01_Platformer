using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager Instance;
    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else
        {
           Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
