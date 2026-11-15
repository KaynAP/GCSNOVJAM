using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements;

public class characterBlurb : MonoBehaviour
{
    

    // Drag the new Sprite you want to use here in the Inspector
    public Sprite _CharSprite;
    public string _CharName;
    public string _CharDesc;

    public GameObject _targetUIImage;
    public GameObject _targetName;
    public GameObject _targetDesc;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void onUse()
    {
        _CharSprite = GetComponent<Sprite>();
        _CharName = GetComponent<string>();
        _CharDesc = GetComponent<string>();
        //_CharSprite.Image = 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
