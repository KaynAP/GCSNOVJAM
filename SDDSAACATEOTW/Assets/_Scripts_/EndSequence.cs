using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class EndSequence : MonoBehaviour
{
    public GameObject _EndScreen;

    [SerializeField] Sprite[] _ActualSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameManager._Success)
        {
            if (GameManager._badGuy == "Cel")
            {
                _EndScreen.GetComponent<SpriteRenderer>().sprite = _ActualSprite[0];
            }
            else if (GameManager._badGuy == "Aevum")
            {
                _EndScreen.GetComponent<SpriteRenderer>().sprite = _ActualSprite[1];
            }
            else
            {
                _EndScreen.GetComponent<SpriteRenderer>().sprite = _ActualSprite[2];
            }
        }
        else
        {
            if (GameManager._badGuy == "Cel")
            {
                _EndScreen.GetComponent<SpriteRenderer>().sprite = _ActualSprite[3];
            }
            else if (GameManager._badGuy == "Aevum")
            {
                _EndScreen.GetComponent<SpriteRenderer>().sprite = _ActualSprite[4];
            }
            else
            {
                _EndScreen.GetComponent<SpriteRenderer>().sprite = _ActualSprite[5];
            }
        }
    }
}
