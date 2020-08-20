
using Unity.Mathematics;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/BasicGun", fileName = "BasicGun")]
public class BasicShipGun : ShipGunBase
{
    public override void Fire(Vector2 pos)
    {
        GameObject bullet = ObjectPooler.instance.GetPooledObject();
        
        if (!bullet) return;
        
        bullet.SetActive(true);
        bullet.transform.position = pos;
        bullet.GetComponent<Bullet>().Init(velocity, lifeTime);
    }
}
