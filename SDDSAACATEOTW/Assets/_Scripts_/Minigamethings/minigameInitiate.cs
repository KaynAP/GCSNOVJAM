using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using System.Linq;
using System;
using System.Runtime.CompilerServices;

public class minigameInitiate : MonoBehaviour
{
    public GameObject _minigameTab;

    [SerializeField] private PlayerControl _targetScript;

    public static minigameInitiate i_MI;

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
        if (Input.GetKey(KeyCode.E) && collision.CompareTag("Player"))
        {
            // checks if you've taken all of characters' orders
            if (GameManager._phase == 2)
            { 
                if (PlayerControl._drink == 0)
                {
                    canvasVisibility(true);
                    PlayerControl.i_PC._CanMove = false;
                    choice("Pick a Drink", "Coffee", "Tea");
                }
                else
                {
                    _targetScript.StartCoroutine(_targetScript.warningTime("I already have an order."));
                }
            }
            else
            {
                _targetScript.StartCoroutine(_targetScript.warningTime("I don't know what to get."));
            }

        }

    }
    public void canvasVisibility(bool isVisible)
    {
        _minigameTab.SetActive(isVisible);
    }
    public void choice(string title, string option1, string option2)
    {
        if (_minigameTab != null)
        {
            TMP_Text[] children = _minigameTab.GetComponentsInChildren<TMP_Text>();
            children[0].text = title;
            children[1].text = option1;
            children[2].text = option2;
        }
    }
}
