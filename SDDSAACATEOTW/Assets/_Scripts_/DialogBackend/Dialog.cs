using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Rendering;
using System.Text.RegularExpressions;
using System.Diagnostics;

public class Dialog : MonoBehaviour
{

    public DialogSO _dialogSO; 
    public TextMeshProUGUI _BodyText;
    public TextMeshProUGUI _NameText;
    public Image _CharSprite;
    public float _TextSpeed;
    public GameObject _TextCan;

    [SerializeField] TMP_Text _button1TXT;
    [SerializeField] TMP_Text _button2TXT;



    public Characters _Character;

    // Start is called before the first frame update
    void Start()
    {   
        _BodyText.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {   
        //_CharSprite.sprite = _Character._charImages[_dialogSO._NpcSprite];
        _button1TXT.text = _dialogSO._option1TXT;
        _button2TXT.text = _dialogSO._option2TXT;


            if(Input.GetMouseButtonDown(0)|| Input.GetKeyDown(KeyCode.Space)){
                if(_BodyText.text != _dialogSO._dialogText){
                    StopAllCoroutines();
                    _BodyText.text = _dialogSO._dialogText;
                }
    
            }
        
    }
    
    public void StartDialogue(){
        
    //        PlayerControl.i_PC._CanMove = false;

        StartCoroutine(TypeLine());
        
       _NameText.text = _Character._CharName;
    }
    IEnumerator TypeLine(){

        foreach(char c in _dialogSO._dialogText.ToCharArray()){
            _BodyText.text += c;
            yield return new WaitForSeconds(_TextSpeed);
        }
    }
    
    void NextLine(){
       
            _BodyText.text = string.Empty;
            StartCoroutine(TypeLine());
    }
    public void OPTION1(){
        addRelationship(_dialogSO._AddLove);
        if(!_dialogSO._EndDialog)
        {
            
            _dialogSO = _dialogSO._option1;
            NextLine();
        }
        else
        {
             
             GameManager.i_GM.SCENECHANGE();
        }

    }
    public void OPTION2()
    {
        addRelationship(_dialogSO._AddLove);
        if(!_dialogSO._EndDialog){
            
            _dialogSO = _dialogSO._option2;
            NextLine();
        }
        else
        {
            GameManager.i_GM.SCENECHANGE();
        }
    }
   

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
