using System.Collections;
using UnityEngine;

public class CafeSceneStart : MonoBehaviour
{
    public static bool _gameHasBegin = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (_gameHasBegin == false)
        {
            PlayerControl.i_PC.CanMove = false;
            StartCoroutine(TimeBeforeBegin());
        }

    }
    IEnumerator TimeBeforeBegin()
    {
        yield return new WaitForSeconds(3f);
        _gameHasBegin = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
