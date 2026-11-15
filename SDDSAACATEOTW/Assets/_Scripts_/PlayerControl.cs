using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    //annotated in powcow

    Rigidbody2D _rb;
    public float _moveSpeed;
    Vector2 _moveDir;

    public bool _CanMove;

    public static PlayerControl i_PC;

    public GameObject _Warning;

    public static int _drink = 0;
    public static int _food = 0;
    public static int _dessert = 0;

    void Awake()
    {
        i_PC = this;
    }
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        if (GameManager._gameHasBegin)
        {
            i_PC.transform.position = GameManager._LASTPOS;
        }
        _Warning.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager._GamePause)
        {
            _moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (!_CanMove)
            {
                _rb.linearVelocity = Vector2.zero;
            }
        }
    }

    IEnumerator warningTime(int time)
    {
        _CanMove = false;
        yield return new WaitForSeconds(time);
        _CanMove = true;
    }

    void FixedUpdate()
    {
        if (_CanMove)
        {
            _rb.linearVelocity = _moveDir * _moveSpeed;
        }
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.E) && other.CompareTag("NPC") && !GameManager._GamePause)
        {
            if (other.name == "Cel") //check Cel
            {
                if (CelManager._CelConvoNo >= 1 && GameManager._phase == 1) //Check if done phase 1
                {
                    _Warning.SetActive(true);
                    warningTime(2);
                }
                else
                {
                    GameManager._currentChar = other.GetComponent<CelManager>()._CelChar;
                    GameManager._currentDialog = other.GetComponent<CelManager>()._CelDialogStarts[CelManager._CelConvoNo];
                    CelManager._CelConvoNo++;
                    GameManager.i_GM.SCENECHANGE();
                }
                    
            }
            else if (other.name == "Lulu") //Check Lulu
            {
                if (LuluManager._LuluConvoNo >= 1 && GameManager._phase == 1) // check if done phase 1
                {
                    _Warning.SetActive(true);
                    warningTime(2);
                }
                else
                {
                    GameManager._currentChar = other.GetComponent<LuluManager>()._LuluChar;
                    GameManager._currentDialog = other.GetComponent<LuluManager>()._LuluDialogStarts[LuluManager._LuluConvoNo];
                    LuluManager._LuluConvoNo++;
                    GameManager.i_GM.SCENECHANGE();
                }
                    
            }
            else if (other.name == "Aevum") //Check Aevum
            {
                if (TDManager._TDConvoNo >= 1 && GameManager._phase == 1) // check if done phase 1
                {
                    _Warning.SetActive(true);
                    warningTime(2);
                }
                else
                {
                    GameManager._currentChar = other.GetComponent<TDManager>()._TDChar;
                    GameManager._currentDialog = other.GetComponent<TDManager>()._TDDialogStarts[TDManager._TDConvoNo];
                    TDManager._TDConvoNo++;
                    GameManager.i_GM.SCENECHANGE();
                }
            }
            
        }
    }
}
