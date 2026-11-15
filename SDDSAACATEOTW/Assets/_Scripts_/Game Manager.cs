using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static Vector3 _LASTPOS; 
    public static GameManager i_GM;
    public static bool _gameHasBegin = false;

    public static int _CRelationshipMeter = 0;
    public static int _TDRelationshipMeter = 0;
    public static int _LRelationshipMeter = 0;

    [HideInInspector] public Characters _currentChar;

    [HideInInspector] public DialogSO _currentDialog;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        i_GM = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
    //    _gMChar[Random.Range(0,3)]._IsEvil = true;
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
            Dialog.i_DIA._Character = _currentChar;
            Dialog.i_DIA._dialogSO = _currentDialog;
        }
        else{
            SceneManager.LoadScene("CafeScene");
            
        }
    }
}
