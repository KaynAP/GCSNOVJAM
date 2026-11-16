using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //starting shit (save last position, activate singleton, your game has begin one)
    public static Vector3 _LASTPOS;
    public static GameManager i_GM;

    public static bool _gameHasBegin = false;
    public static bool _IntroDone = false;
    //public static bool _GamePause = false;
    public static bool _Success = false;

    //relationship meter
    public static int _CRelationshipMeter = 0;
    public static int _TDRelationshipMeter = 0;
    public static int _LRelationshipMeter = 0;

    public static int _phase = 0;

    //public GameObject _PauseMenu;

    [HideInInspector] public static string _badGuy;


    //pull the current character and dialog scriptable objects as well as 
    [HideInInspector] public static Characters _currentChar;
    [HideInInspector] public static DialogSO _currentDialog;

    [SerializeField] Characters[] _gMChar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //call singleton, ensure that game manager isnt deleted but makes sure copies are
        if (i_GM != null && i_GM != this)
        {
            Destroy(gameObject);
            return;
        }

        i_GM = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        //select the evil guy
        _gMChar[Random.Range(0, 3)]._IsEvil = true;

        _LASTPOS = new Vector3(2.87f, -3.16f, -2f);
        SceneManager.LoadScene("TitleScene");
        _PauseMenu.SetActive(false);
        Debug.Log($"{_gMChar[0]._IsEvil}, {_gMChar[1]._IsEvil}, {_gMChar[2]._IsEvil}");

    }

    // Update is called once per frame
    void Update()
    {
        if (_gameHasBegin)
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
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "CafeScene" && _IntroDone)
        {
            if (!_GamePause)
            {
                _GamePause = true;
                _PauseMenu.SetActive(true);
                Time.timeScale = 0f;
                
            }
            else if (_GamePause)
            {
                _PauseMenu.SetActive(false);
                _GamePause = false;
                Time.timeScale = 1.0f;
                
            }
            
        }
       
    }


    //change the scene, DM me because even I dont want to deal with explaining at midnight
    public void SCENECHANGE()
    {
        if(SceneManager.GetActiveScene().name == "DatingScene" && (TDManager._TDConvoNo >= 3 || CelManager._CelConvoNo >= 3 || LuluManager._LuluConvoNo >= 3))
        {
            _phase = 3; //endgame, will put the ending decider
            if (_CRelationshipMeter >= 4 && _gMChar[0]._IsEvil)
            {
                //good, C bad
                _Success = true;
                _badGuy = "Cel";
            }
            else if (_CRelationshipMeter < 4 && _gMChar[0]._IsEvil)
            {
                //bad, C bad
                _Success = false;
                _badGuy = "Cel";
            }
            else if (_TDRelationshipMeter >= 4 && _gMChar[1]._IsEvil)
            {
                //good, TD bad
                _Success = true;
                _badGuy = "Aevum";
            }
            else if (_TDRelationshipMeter < 4 && _gMChar[1]._IsEvil)
            {
                //bad, TD bad
                _Success = false;
                _badGuy = "Aevum";
            }
            else if (_LRelationshipMeter >= 4 && _gMChar[2]._IsEvil)
            {
                //good, L bad
                _Success = true;
                _badGuy = "Lulu";
            }
            else if (_LRelationshipMeter < 4 && _gMChar[2]._IsEvil)
            {
                //bad, L bad
                _Success = false;
                _badGuy = "Lulu";
            }
            SceneManager.LoadScene("EndScene");
        }
        else if (SceneManager.GetActiveScene().name == "CafeScene"){
            if (PlayerControl.i_PC.isActiveAndEnabled)
            _LASTPOS = PlayerControl.i_PC.transform.position;
            SceneManager.LoadScene("DatingScene");
        }
        else
        {
            _GamePause = false;
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("CafeScene");
        }
    }
}
