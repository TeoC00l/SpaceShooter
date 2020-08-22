using UnityEngine;

public class DeathZoneCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Object.Destroy(other.gameObject);
            Debug.Log("Killed!");
        }
    }
}
