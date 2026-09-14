using UnityEngine;
using StarboundExpedition.Progress;

namespace KirbyFanPrototype.Village
{
    public enum FacilityType { Cafe, WeaponShop, ItemShop, Theater, Arena, Fishing, Delivery, Home }

    public sealed class VillageFacility : MonoBehaviour
    {
        [SerializeField] FacilityType type;
        public void Use()
        {
            var save = SaveSystem.Load();
            switch (type)
            {
                case FacilityType.Fishing: save.coins += 5; break;
                case FacilityType.Delivery: save.coins += 10; break;
                case FacilityType.Home: SaveSystem.Save(save); return;
            }
            SaveSystem.Save(save);
        }
    }
}
