using UnityEngine;
using UnityEngine.UI;

public class onButtonClicked : MonoBehaviour
{
    public Button button;
    public void Start()
    {
        button.onClick.AddListener(foodOption);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void foodOption()
    {
        Debug.Log("clicked");
        if (button.name == "Option 1")
        {
            PlayerControl.i_PC._food = 1;
            Debug.Log("food 1");
        }
        else if (button.name == "Option 2")
        {
            PlayerControl.i_PC._food = 2;
            Debug.Log("food 2");
        }
    }
    private void OnDestroy()
    {
        button.onClick.RemoveListener(foodOption);
    }
}
