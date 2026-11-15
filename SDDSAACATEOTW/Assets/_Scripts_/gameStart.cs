using UnityEngine;
using UnityEngine.SceneManagement;

public class gameStart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void buttonIsPressed()
    {
        SceneManager.LoadScene("CafeScene");
    }
}
