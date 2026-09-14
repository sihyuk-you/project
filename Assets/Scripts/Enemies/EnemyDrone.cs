using UnityEngine;
using StarboundExpedition.Combat;

namespace StarboundExpedition.Enemies
{
    [RequireComponent(typeof(Damageable))]
    public sealed class EnemyDrone : MonoBehaviour
    {
        [SerializeField] float speed = 2.8f;
        [SerializeField] float turnSpeed = 5f;
        Transform target;
        void Start() { var player = GameObject.FindGameObjectWithTag("Player"); if (player) target = player.transform; }
        void Update()
        {
            if (!target) return;
            var direction = (target.position - transform.position); direction.y = 0;
            if (direction.sqrMagnitude < .01f) return;
            transform.forward = Vector3.Slerp(transform.forward, direction.normalized, turnSpeed * Time.deltaTime);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
