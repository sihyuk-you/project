using UnityEngine;
using UnityEngine.EventSystems;

namespace StarboundExpedition.UI
{
    public sealed class MobileActionButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public enum Action { Fire, Dash, Jump, Gravity }
        [SerializeField] Action action;
        public static event System.Action<Action, bool> Changed;
        public void OnPointerDown(PointerEventData eventData) => Changed?.Invoke(action, true);
        public void OnPointerUp(PointerEventData eventData) => Changed?.Invoke(action, false);
    }
}
