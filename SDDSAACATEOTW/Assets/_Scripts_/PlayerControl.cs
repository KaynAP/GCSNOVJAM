using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //annotated in powcow
    Rigidbody2D _rb;

    public float _moveSpeed;
    Vector2 _moveDir;

    public bool _CanMove;

    public static PlayerControl i_PC;

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
    }

    // Update is called once per frame
    void Update()
    {
        _moveDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (!_CanMove)
        {
            _rb.linearVelocity = Vector2.zero;
        }
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
        if (Input.GetKey(KeyCode.E) && other.CompareTag("NPC"))
        {
            GameManager.i_GM._currentChar = other.GetComponent<Characters>();
            GameManager.i_GM._currentDialog = other.GetComponent<DialogSO>();
            GameManager.i_GM.SCENECHANGE();
        }
    }
}
