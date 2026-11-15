using System.Collections;
using UnityEngine;

public class CafeSceneStart : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
  
        if (GameManager._gameHasBegin == false)
        {
            PlayerControl.i_PC._CanMove = false;
            StartCoroutine(TimeBeforeBegin());
        }

    }
    private void Update()
    {
        if (GameManager._IntroDone)
        {
            PlayerControl.i_PC._CanMove = true;
        }
    }
    IEnumerator TimeBeforeBegin()
    {
        yield return new WaitForSeconds(2f);
        GameManager._gameHasBegin = true;
        yield return new WaitForSeconds(5f);
        GameManager._IntroDone = true;
    }
}
