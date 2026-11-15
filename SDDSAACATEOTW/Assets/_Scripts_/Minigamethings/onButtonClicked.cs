using UnityEditor;
using UnityEngine;

public class onButtonClicked : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void thingsOptions()
    {
        if (PlayerControl._drink == 0)
        {
            if (gameObject.name == "Option 1")
            {
                PlayerControl._drink = 1;
            }
            else if (gameObject.name == "Option 2")
            {
                PlayerControl._drink = 2;
            }
            minigameInitiate.i_MI.choice("Pick a food", "Soup", "Sandwich");
        }
        else if (PlayerControl._food == 0)
        {
            if (gameObject.name == "Option 1")
            {
                PlayerControl._food = 1;
            }
            else if (gameObject.name == "Option 2")
            {
                PlayerControl._food = 2;
            }
            minigameInitiate.i_MI.choice("Pick a food", "Savoury", "Sweet");
        }
        else if (PlayerControl._dessert == 0)
        {
            if (gameObject.name == "Option 1")
            {
                PlayerControl._dessert = 1;
            }
            else if (gameObject.name == "Option 2")
            {
                PlayerControl._dessert = 2;
            }
            optionsAndTitle.i_oAT.gameObject.SetActive(false);
            PlayerControl.i_PC._CanMove = true;
        }
    }
}
