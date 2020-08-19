using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Object.Destroy(other.gameObject);
            Debug.Log("Killed outer bound");
        }
    }
}
