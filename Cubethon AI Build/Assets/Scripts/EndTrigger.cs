using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter(Collider collidision)
    {
        if (collidision.gameObject.tag == "Player")
            gameManager.CompleteLevel();
    }
}
