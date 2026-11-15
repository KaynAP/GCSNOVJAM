using UnityEngine;

public class onButtonClicked : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void foodOption()
    {
        if (gameObject.name == "Option 1")
        {
            PlayerControl.i_PC._food = 1;
            gameObject.SetActive(false);
        }
        else if (gameObject.name == "Option 2")
        {
            PlayerControl.i_PC._food = 2;
            gameObject.SetActive(false);
        }
    }
}
