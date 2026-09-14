using UnityEngine;

namespace KirbyFanPrototype.Abilities
{
    public enum CopyAbility { None, Sword, Fire, Ice, Drill, Hammer }

    public sealed class CopyAbilitySystem : MonoBehaviour
    {
        [SerializeField] float inhaleRadius = 5f;
        [SerializeField] LayerMask inhalableMask;
        public CopyAbility Current { get; private set; }

        public void Inhale()
        {
            foreach (var hit in Physics.OverlapSphere(transform.position, inhaleRadius, inhalableMask))
            {
                if (!hit.TryGetComponent<AbilitySource>(out var source)) continue;
                Current = source.ability;
                Destroy(source.gameObject);
                break;
            }
        }
        public void DropAbility() => Current = CopyAbility.None;
    }

    public sealed class AbilitySource : MonoBehaviour
    {
        public CopyAbility ability;
    }
}
