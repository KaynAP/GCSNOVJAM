using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class minigameInitiate : MonoBehaviour
{
    public GameObject _canvasThing;

    public static minigameInitiate i_MI;

    public TMP_Text firstTextTarget;
    public TMP_Text secondTextTarget;
    public TMP_Text thirdTextTarget;

    void Awake()
    {
        i_MI = this;
    }

    private void Start()
    {
        canvasVisibility(false);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        // checks if you've taken all of characters' orders
        if (GameManager._phase == 2)
        { 
            if (Input.GetKey(KeyCode.E) && collision.CompareTag("Player"))
            {
                if (PlayerControl.i_PC._drink == 0)
                {
                    canvasVisibility(true);
                    PlayerControl.i_PC._CanMove = false;
                    choice("Pick a Drink", "Coffee", "Tea");
                }
            }
        }
    }
    public void canvasVisibility(bool isVisible)
    {
        _canvasThing.SetActive(isVisible);
    }
    public void choice(string title, string option1, string option2)
    {
        if (_canvasThing != null)
        {
            firstTextTarget.text = title;
            secondTextTarget.text = option1;
            thirdTextTarget.text = option2;
        }
    }
}
