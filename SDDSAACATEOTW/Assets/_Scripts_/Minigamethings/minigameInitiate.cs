using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class minigameInitiate : MonoBehaviour
{
    public GameObject _canvasThing;

    public TMP_Text firstTextTarget;
    public TMP_Text secondTextTarget;
    public TMP_Text thirdTextTarget;

    private void Start()
    {
        canvasVisibility(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E) && collision.CompareTag("Player"))
        {
            canvasVisibility(true);
            choice("Pick a Drink", "Coffee", "Tea");
        }
    }

    public void Update()
    {
        while (_canvasThing.activeInHierarchy)
        {
            PlayerControl.i_PC._CanMove = false;
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
