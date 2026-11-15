using TMPro;
using UnityEngine;

public class optionsAndTitle : MonoBehaviour
{
    public static optionsAndTitle i_oAT;

    void Awake()
    {
        if (i_oAT != null && i_oAT != this)
        {
            Destroy(gameObject);
            return;
        }

        i_oAT = this;
        DontDestroyOnLoad(gameObject);

    }
}
