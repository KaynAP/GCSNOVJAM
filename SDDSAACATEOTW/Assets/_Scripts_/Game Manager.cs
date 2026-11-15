using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //starting shit (save last position, activate singleton, your game has begin one)
    public static Vector3 _LASTPOS;
    public static GameManager i_GM;
    public static bool _gameHasBegin = false;

    //relationship meter
    public static int _CRelationshipMeter = 0;
    public static int _TDRelationshipMeter = 0;
    public static int _LRelationshipMeter = 0;

    public static int _phase = 0;

    public static bool _IntroDone = false;

    //pull the current character and dialog scriptable objects as well as 
    [HideInInspector] public Characters _currentChar;

    [HideInInspector] public DialogSO _currentDialog;

    [SerializeField] Characters[] _gMChar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //call singleton, ensure that game manager isnt deleted
        i_GM = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        //select the evil guy
     _gMChar[Random.Range(0,3)]._IsEvil = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (CelManager._CelConvoNo == 0 || TDManager._TDConvoNo == 0 || LuluManager._LuluConvoNo == 0)
        {
            _phase = 1;
        }
        if (CelManager._CelConvoNo == 1 && TDManager._TDConvoNo == 1 && LuluManager._LuluConvoNo == 1)
        {
            _phase = 2;
        }
    }
    //change the scene, DM me because even I dont want to deal with explaining at midnight
    public void SCENECHANGE()
    {
        if(SceneManager.GetActiveScene().name == "TitleScene")
        {
            SceneManager.LoadScene("CafeScene");
        }
        else if(SceneManager.GetActiveScene().name == "CafeScene"){
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
