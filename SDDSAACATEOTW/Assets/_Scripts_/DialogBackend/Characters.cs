using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Characters", menuName = "Scriptable Objects/Characters")]
public class Characters : ScriptableObject
{
    public int _currentCharID;
    public string _CharName;
    public sprite _default;
    [SerializeField] public Dictionary<sprite, Sprite> _charImages = new Dictionary<sprite, Sprite>();

    public bool _smallTalker;
    public bool _serious;

    public AudioSource _charSound;
    public bool _IsEvil;

    

}
