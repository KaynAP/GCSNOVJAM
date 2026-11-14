using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static Vector3 _LASTPOS; 
    public static GameManager i_GM;
    public static bool _gameHasBegin = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        i_GM = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SCENECHANGE()
    {
        if(SceneManager.GetActiveScene().name == "CafeScene"){
            _LASTPOS = PlayerControl.i_PC.transform.position;
            SceneManager.LoadScene("DatingScene");
        }
        else{
            SceneManager.LoadScene("CafeScene");
        }
    }
}
