using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager i_GM;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        i_GM = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
