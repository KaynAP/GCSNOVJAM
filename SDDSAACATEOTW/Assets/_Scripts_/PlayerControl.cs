using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System.Security.Cryptography;
using UnityEngine.UI;
using TMPro;

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
        _Warning.SetActive(false);
        gameObject.transform.position = GameManager._LASTPOS;
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

    public IEnumerator warningTime(string message)
    {
        _Warning.SetActive(true);
        _Warning.GetComponentInChildren<TMP_Text>().text = message;
        _rb.linearVelocity = Vector2.zero;
        _CanMove = false;
        GameManager._GamePause = true;
        yield return new WaitForSeconds(2f);
        _Warning.SetActive(false);
        GameManager._GamePause = false;
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
            _rb.linearVelocity = Vector2.zero;
            if (other.name == "Cel") //check Cel
            {
                if (CelManager._CelConvoNo >= 1 && GameManager._phase == 1) //Check if done phase 1
                {
                    StartCoroutine(warningTime("I have other customers to attend to."));
                }
                else if (GameManager._phase == 2 && _drink <= 0 && CelManager._CelConvoNo <= 1)
                {
                    StartCoroutine(warningTime("I have to get Cel their order."));
                }
                else
                {
                    if (CelManager._CelConvoNo <= 1)
                    {
                        _drink = 0;
                        _food = 0;
                        _dessert = 0;
                    }
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
                    StartCoroutine(warningTime("I have other customers to attend to."));
                }
                else if (GameManager._phase == 2 && _drink <= 0 && LuluManager._LuluConvoNo <= 1)
                {
                    StartCoroutine(warningTime("I have to get Lulu her order."));
                }
                else
                {
                    if (LuluManager._LuluConvoNo <= 1)
                    {
                        _drink = 0;
                        _food = 0;
                        _dessert = 0;
                    }
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
                    StartCoroutine(warningTime("I have other customers to attend to."));
                }
                else if (GameManager._phase == 2 && _drink <= 0 && TDManager._TDConvoNo <= 1)
                {
                    StartCoroutine(warningTime("I have to get Aevum his order."));
                }
                else
                {
                    if (TDManager._TDConvoNo <= 1)
                    {
                        _drink = 0;
                        _food = 0;
                        _dessert = 0;
                    }
                    GameManager._currentChar = other.GetComponent<TDManager>()._TDChar;
                    GameManager._currentDialog = other.GetComponent<TDManager>()._TDDialogStarts[TDManager._TDConvoNo];
                    TDManager._TDConvoNo++;
                    GameManager.i_GM.SCENECHANGE();
                }
            }
        }
    }
}
