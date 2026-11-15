using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Rendering;
using System.Text.RegularExpressions;
using System.Diagnostics;

public class Dialog : MonoBehaviour
{

    //Canvas and text setup
    public DialogSO _dialogSO; 
    public TextMeshProUGUI _BodyText;
    public TextMeshProUGUI _NameText;
    public Image _CharSprite;
    public float _TextSpeed;
    public GameObject _TextCan;

    [SerializeField] TMP_Text _button1TXT;
    [SerializeField] TMP_Text _button2TXT;

    //singleton reference to pull this script's data from other scripts
    public static Dialog i_DIA;

    // character Scriptable Object (grabbing the correct character)
    public Characters _Character;

// audio
    private AudioSource _audioPlayer;

    //Activate the singleton
    void Awake()
    {
        i_DIA = this;
    }

    // Start is called before the first frame update
    void Start()
    {   
        //Firing audio

        
    }
    
    void OnEnable()
    {
        //Clear text and fire starting dialogue
        _audioPlayer = gameObject.GetComponent<AudioSource>();
        _Character = GameManager._currentChar;
        _dialogSO = GameManager._currentDialog;
        _audioPlayer.clip = _Character._charSound;
        _BodyText.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {   
        //set all the sprites and dialogue options
        _CharSprite.sprite = _Character._charImages[_dialogSO._NpcSprite];
        _button1TXT.text = _dialogSO._option1TXT;
        _button2TXT.text = _dialogSO._option2TXT;

        if (!GameManager._GamePause)
        {
            // autocomplete if you press button
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                if (_BodyText.text != _dialogSO._dialogText)
                {
                    StopAllCoroutines();
                    _BodyText.text = _dialogSO._dialogText;
                }

            }
        }
        
    }
    
    public void StartDialogue(){
        
    //  PlayerControl.i_PC._CanMove = false;

        StartCoroutine(TypeLine());
        
       _NameText.text = _Character._CharName;
    }
    IEnumerator TypeLine(){
        //type the line character by character
        foreach(char c in _dialogSO._dialogText.ToCharArray()){
            _BodyText.text += c;
            yield return new WaitForSeconds(_TextSpeed);
        }
    }
    
    //Skip to the next one
    void NextLine(){
       
            _BodyText.text = string.Empty;
            StartCoroutine(TypeLine());
    }

    //Functions called from the buttons
    public void OPTION1(){
        addRelationship(_dialogSO._AddLove);
        if(_dialogSO._EndDialog == false)
        {
            //moves on if not ended
            _dialogSO = _dialogSO._option1;
            NextLine();
        }
        else
        {
             //swaps scene back to the main one
             GameManager.i_GM.SCENECHANGE();
        }

    }
    //same as option one
    public void OPTION2()
    {
        addRelationship(_dialogSO._AddLove);
        if(_dialogSO._EndDialog == false){
            
            _dialogSO = _dialogSO._option2;
            NextLine();
        }
        else
        {
            GameManager.i_GM.SCENECHANGE();
        }
    }
   
    //add relationship stores
    void addRelationship(int amountToAdd)
    {
        switch(_Character._currentCharID){
            case 1: 
                if(!_Character._IsEvil){
                    GameManager._CRelationshipMeter += amountToAdd;
                }
                else
                {
                    GameManager._CRelationshipMeter -= amountToAdd;
                }
            break;

            case 2: 
                if(!_Character._IsEvil){
                    GameManager._TDRelationshipMeter += amountToAdd;
                }
                else
                {
                    GameManager._TDRelationshipMeter -= amountToAdd;
                }
            break;

            case 3: 
                if(!_Character._IsEvil){
                    GameManager._LRelationshipMeter += amountToAdd;
                }
                else
                {
                    GameManager._LRelationshipMeter -= amountToAdd;
                }
            break;

        }
    } 

}
