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
    IEnumerator TimeBeforeBegin()
    {
        yield return new WaitForSeconds(3f);
        GameManager._gameHasBegin = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
