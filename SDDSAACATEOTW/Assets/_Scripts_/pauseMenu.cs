using UnityEngine;

public class pauseMenu : MonoBehaviour
{
    public static pauseMenu i_PM;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //call singleton, ensure that game manager isnt deleted but makes sure copies are
        if (i_PM != null && i_PM != this)
        {
            Destroy(gameObject);
            return;
        }

        i_PM = this;
        DontDestroyOnLoad(gameObject);
    }
}
