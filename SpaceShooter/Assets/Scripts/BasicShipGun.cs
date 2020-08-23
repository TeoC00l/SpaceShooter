
using Unity.Mathematics;
using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/BasicGun", fileName = "BasicGun")]
public class BasicShipGun : ShipGunBase
{
    public override void Fire(Vector2 pos)
    {
        Bullet bullet = ObjectPooler.instance.GetPooledObject();
        
        if (!bullet) return;
        
        bullet.gameObject.SetActive(true);
        bullet.transform.position = pos;
        bullet.Init(velocity, lifeTime);
    }
}
