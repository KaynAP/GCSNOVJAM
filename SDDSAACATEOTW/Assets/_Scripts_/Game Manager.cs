using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //starting shit (save last position, activate singleton, your game has begin one)
    public static Vector3 _LASTPOS;
    public static GameManager i_GM;

    public static bool _gameHasBegin = false;
    public static bool _IntroDone = false;
    public static bool _GamePause = false;
    public static bool _Success = false;

    //relationship meter
    public static int _CRelationshipMeter = 0;
    public static int _TDRelationshipMeter = 0;
    public static int _LRelationshipMeter = 0;

    public static int _phase = 0;

    public GameObject _PauseMenu;

    [HideInInspector] public static string _badGuy;
    [HideInInspector] public static string _talkingTo;


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
        if (_gMChar[0]._IsEvil) {_badGuy = "Cel";}
        else if (_gMChar[1]._IsEvil) {_badGuy = "Aevum";}
        else{_badGuy = "Lulu";}

        //Other beginning stuff
        _LASTPOS = new Vector3(2.87f, -3.16f, -2f);
        SceneManager.LoadScene("TitleScene");
        _PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
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

    private void FixedUpdate()
    {
        if (CelManager._CelConvoNo == 1 && TDManager._TDConvoNo == 1 && LuluManager._LuluConvoNo == 1)
        {
            _phase = 2;
        }
        else if (CelManager._CelConvoNo == 0 || TDManager._TDConvoNo == 0 || LuluManager._LuluConvoNo == 0)
        {
            _phase = 1;
        }
    }

    //change the scene, DM me because even I dont want to deal with explaining at midnight
    public void SCENECHANGE()
    {
        if(SceneManager.GetActiveScene().name == "DatingScene" && (TDManager._TDConvoNo >= 4 || CelManager._CelConvoNo >= 4 || LuluManager._LuluConvoNo >= 4))
        {
            _phase = 3; //endgame, will put the ending decider
            if ((_CRelationshipMeter >= 4 && _badGuy == "Cel") || (_TDRelationshipMeter >= 4 && _badGuy == "Aevum") || (_LRelationshipMeter >= 4 && _badGuy == "Lulu"))
            {
                _talkingTo = Dialog.i_DIA._Character._CharName;
                _Success = true;
            }
            else
            {
                _Success = false;
            }
            SceneManager.LoadScene("EndScene");
        }
        else if (SceneManager.GetActiveScene().name == "CafeScene"){
            if (PlayerControl.i_PC.isActiveAndEnabled)
            _LASTPOS = PlayerControl.i_PC.transform.position;
            SceneManager.LoadScene("DatingScene");
        }
        else if (SceneManager.GetActiveScene().name == "EndScene")
        {
            //resets game, maybe
            SceneManager.LoadScene("CafeScene");
            PlayerControl._dessert = 0;
            PlayerControl._drink = 0;
            PlayerControl._food = 0;
            _phase = 0;
            _gameHasBegin = false;
            _IntroDone = false;
            _Success = false;
            _CRelationshipMeter = 0;
            _LRelationshipMeter = 0;
            _TDRelationshipMeter = 0;
            CelManager._CelConvoNo = 0;
            LuluManager._LuluConvoNo = 0;
            TDManager._TDConvoNo = 0;

            Start();
        }
        else
        {
            _GamePause = false;
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("CafeScene");
        }
    }
}
