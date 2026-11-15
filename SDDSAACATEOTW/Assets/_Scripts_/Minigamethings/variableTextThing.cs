using UnityEngine;
using TMPro;

public class variableTextThing : MonoBehaviour
{
    // Reference to the UI text object
    [SerializeField] private TextMeshProUGUI _canvasThing;

    //line of text that will be displayed
    public string _variableText = "Pick a Drink";

    void Start()
    {
        UpdateText(_variableText);
    }

    private void UpdateText(string text)
    {
        _canvasThing.text = $"{_variableText}";
    }
}