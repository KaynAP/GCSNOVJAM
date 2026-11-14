using UnityEngine;

public class NPCTransformScript : MonoBehaviour
{
    public Transform[] _waypoints;
    public float speed = 3f;
    public bool loop = true;
    public Transform _firstPoint;

    private int currentIndex = 0;

    private void Start()
    {
        transform.position = _firstPoint.position;
    }

    void Update()
    {
        if (GameManager._gameHasBegin)
        {
            if (_waypoints.Length == 0) return;

            // Move toward the current waypoint
            Transform target = _waypoints[currentIndex];
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            // Check if the character has reached the point
            if (Vector3.Distance(transform.position, target.position) < 0.1f)
            {
                currentIndex++;

                // Reset to the first point if looping, or stop at the end
                if (currentIndex >= _waypoints.Length)
                {
                    if (loop)
                        currentIndex = 0;
                    else
                        enabled = false;
                }
            }
        }
    }
}