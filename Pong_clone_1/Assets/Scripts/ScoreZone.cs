using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    GameManager manager;
    public void Start()
    {
        manager = FindAnyObjectByType<GameManager>();
        if (manager == null)
        {
            Debug.LogError("GameManager not found in the scene. Please ensure a GameManager script is attached to a GameObject.");
        }
    }

    void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
       if(gameObject.tag == "Left Goal")
       {
            Debug.Log("Left Goal Scored On!");
            manager.IncrementRightScore();
       }
       else if(gameObject.tag == "Right Goal")
       {
            Debug.Log("Right Goal Scored On!");
            manager.IncrementLeftScore();

       }
    }
}
