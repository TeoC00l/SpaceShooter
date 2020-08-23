using UnityEngine;

namespace SpaceShooter
{
    [CreateAssetMenu(menuName = "Weapon/ParallelGun", fileName = "ParallelGun")]
    public class ParallelGun : ShipGunBase
    {
        [SerializeField]
        private int numberOfProjectiles = 3;
        [SerializeField]
        private float offsetAmount = 10;
    
        public override void Fire(Vector2 pos)
        {
            for (int i = 0; i < numberOfProjectiles; i++)
            {
                Vector2 offsetVector = new Vector2(0, -((numberOfProjectiles - 1) * offsetAmount / 2) + offsetAmount * i);
                
                    Bullet bullet = ObjectPooler.instance.GetPooledObject();
        
                if (!bullet) return;
        
                bullet.gameObject.SetActive(true);
                bullet.transform.position = pos + offsetVector;
                bullet.Init(velocity, lifeTime);
            }
        }
        
    }

}
