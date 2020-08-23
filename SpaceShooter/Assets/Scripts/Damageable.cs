using UnityEngine;

public class Damageable : MonoBehaviour
{
    [SerializeField]
    private float maxHp;

    private float currentHp;

    private void Awake()
    {
        currentHp = maxHp;
    }

    public void Damage(float damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
