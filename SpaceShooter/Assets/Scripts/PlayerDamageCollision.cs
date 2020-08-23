using UnityEngine;

public class PlayerDamageCollision : MonoBehaviour
{

    private WeaponController weaponController;

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
        else if(other.gameObject.CompareTag("Damageable"))
        {
            gameObject.SetActive(false);
        }
    }
}
