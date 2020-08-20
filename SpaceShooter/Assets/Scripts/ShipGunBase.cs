
using UnityEngine;

public abstract class ShipGunBase : ScriptableObject
{
    [SerializeField]
    protected float velocity;
    [SerializeField]
    protected float lifeTime;
    public abstract void Fire(Vector2 pos);
}
