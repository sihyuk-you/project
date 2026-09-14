using UnityEngine;

namespace StarboundExpedition.Combat
{
    public sealed class StarProjectile : MonoBehaviour
    {
        [SerializeField] float speed = 24f;
        [SerializeField] int damage = 1;
        [SerializeField] float lifetime = 3f;
        void Start() => Destroy(gameObject, lifetime);
        void Update() => transform.position += transform.forward * speed * Time.deltaTime;
        void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<Damageable>(out var target)) target.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    public sealed class Damageable : MonoBehaviour
    {
        [SerializeField] int maxHealth = 3;
        int health;
        public System.Action Defeated;
        void Awake() => health = maxHealth;
        public void TakeDamage(int amount)
        {
            health = Mathf.Max(0, health - amount);
            if (health == 0) { Defeated?.Invoke(); Destroy(gameObject); }
        }
    }
}
