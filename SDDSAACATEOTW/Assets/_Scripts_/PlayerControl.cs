using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D _rb;

    public float _moveSpeed;
    Vector2 _moveDir;

    public bool _CanMove;

    public static PlayerControl i_PC;

    public int _drink = 0;
    public int _food = 0;
    public int _dessert = 0;

    void Awake()
    {
        i_PC = this;
    }
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();

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
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.E) && other.CompareTag("NPC"))
        {
            GameManager.i_GM.SCENECHANGE();
        }
    }
}
