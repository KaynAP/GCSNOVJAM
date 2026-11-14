using UnityEngine;


public enum npcType
{
    unknown,
    cthulu,
    celestial,
    timeDaddy

}
public enum sprite
{
    neutral,
    happy,
    crazy,
    sad,
    flirtatious,
    timid,
    warm

}
public enum playerSprite
{
    neutral,
    happy,
    sad,
    flirtatious,
    timid,
    warm
}
[CreateAssetMenu(fileName = "Dialog", menuName = "Scriptable Objects/Dialog")]
public class DialogSO : ScriptableObject
{
    public bool _StartDialog;
    public bool _EndDialog; 

    [Space(5)]
    [TextArea(5,15)]
    public string _dialogText;

    public npcType _npcType;

    public sprite _NpcSprite;

    public string _option1TXT;
    public string _option2TXT;


    public DialogSO _option1;
    public DialogSO _option2;





}
