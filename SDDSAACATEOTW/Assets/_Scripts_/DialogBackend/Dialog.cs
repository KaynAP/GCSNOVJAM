using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Rendering;

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
        _CharSprite.sprite = _Character._charImages[_dialogSO._NpcSprite];
        _button1TXT.text = _dialogSO._option1TXT;
        _button1TXT.text = _dialogSO._option1TXT;



        if (_dialogSO._EndDialog == false){
            if(Input.GetMouseButtonDown(0)|| Input.GetKeyDown(KeyCode.Space)){
             if(_BodyText.text == _dialogSO._dialogText){
                
                NextLine();
                }
            
            
                else {
                    StopAllCoroutines();
                    _BodyText.text = _dialogSO._dialogText;
                }
    
            }
        }
    }
    public void StartDialogue(){
        
        PlayerControl.i_PC._CanMove = false;

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
        if(_dialogSO._EndDialog != false){
            _BodyText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }
    public void OPTION1(){
        if(!_dialogSO._EndDialog)
        {
            _BodyText.text = string.Empty;
            _dialogSO = _dialogSO._option1;
        }
        else
        {
            //swap scenes
        }

    }
    public void OPTION2()
    {
        if(!_dialogSO._EndDialog){
            _BodyText.text = string.Empty;
            _dialogSO = _dialogSO._option2;
        }
        else
        {
            // swap le scene
        }
    }
   

}
