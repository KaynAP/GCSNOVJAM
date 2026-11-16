using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void onUse()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("TitleScene");
        transform.parent.gameObject.SetActive(false);
    }
}
