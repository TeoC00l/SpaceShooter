using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using  UnityEngine.Audio;

public class PlayerDamageCollision : MonoBehaviour
{

    private WeaponController weaponController;
    [SerializeField]
    private GameObject explosionPrefab;
    [SerializeField]
    private AudioSource audioSource;

    private void Awake()
    {
        weaponController = GetComponent<WeaponController>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            weaponController.gun = other.gameObject.GetComponent<PickUp>().GetPickup();
            other.gameObject.SetActive(false);
        }
        else 
        {
            gameObject.SetActive(false);
            Instantiate(explosionPrefab, transform.position, quaternion.identity);
            EndGame();
        }
    }

    private IEnumerator EndGame()
    {
        GameManager.instance.SaveScore();
    }
}
