using UnityEngine;



public enum sprite
{
    neutral,
    happy,
    sad,
    angry

}

[CreateAssetMenu(fileName = "Dialog", menuName = "Scriptable Objects/Dialog")]
public class DialogSO : ScriptableObject
{
    public bool _EndDialog; 

    [Space(10)]
    [TextArea(5,15)]
    public string _dialogText;
    public int _AddLove;

    public sprite _NpcSprite;

    public string _option1TXT;
    public string _option2TXT;


    public DialogSO _option1;
    public DialogSO _option2;





}
