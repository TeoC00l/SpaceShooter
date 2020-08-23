using UnityEngine;

namespace SpaceShooter
{
    [CreateAssetMenu(menuName = "Weapon/ScatterGun", fileName = "ScatterGun")]
    public class ScatterGun : ShipGunBase
    {
        [SerializeField] private int numberOfProjectiles = 3;
        [SerializeField] private float spreadAmount = 10;

        public override void Fire(Vector2 pos)
        {
            for (int i = 0; i < numberOfProjectiles; i++)
            {
                Vector2 rotatedVector =
                    Quaternion.AngleAxis((-spreadAmount * numberOfProjectiles / 2) + spreadAmount * i,
                        Vector3.forward) * Vector2.right;

                Bullet bullet = ObjectPooler.instance.GetPooledObject();

                if (!bullet) return;

                bullet.gameObject.SetActive(true);
                bullet.transform.position = pos;
                bullet.Init(velocity, lifeTime, rotatedVector);
            }
        }
    }
}
