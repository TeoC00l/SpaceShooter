using UnityEngine;

public class PickUp : MonoBehaviour
{
    public ShipGunBase[] pickupGun;

    public ShipGunBase GetPickup()
    {
        int randomIndex = Random.Range(0, pickupGun.Length);
        return pickupGun[randomIndex];
    }
}
