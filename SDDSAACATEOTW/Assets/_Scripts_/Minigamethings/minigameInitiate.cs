using UnityEngine;

public class minigameInitiate : MonoBehaviour
{
    public GameObject _canvasThing;

    private void Start()
    {
        canvasVisibility(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("colliding");
        if (Input.GetKeyDown(KeyCode.E) && collision.CompareTag("Player"))
        {
            Debug.Log("Interacted");
            canvasVisibility(true);
            PlayerControl.i_PC._CanMove = false;
        }
    }
    public void canvasVisibility(bool isVisible)
    {
        _canvasThing.SetActive(isVisible);
    }
}
