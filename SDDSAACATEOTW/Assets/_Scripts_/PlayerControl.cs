using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D _rb;

    public float _moveSpeed;
    Vector2 _moveDir;

    public bool CanMove;

    public static PlayerControl i_PC;

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
    }
    void FixedUpdate()
    {
        _rb.linearVelocity = _moveDir * _moveSpeed;
    }
}
