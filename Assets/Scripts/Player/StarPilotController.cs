using UnityEngine;
using UnityEngine.InputSystem;

namespace StarboundExpedition.Player
{
    [RequireComponent(typeof(CharacterController))]
    public sealed class StarPilotController : MonoBehaviour
    {
        [SerializeField] float moveSpeed = 7f;
        [SerializeField] float dashSpeed = 18f;
        [SerializeField] float dashDuration = .25f;
        [SerializeField] Transform muzzle;
        [SerializeField] GameObject projectilePrefab;
        CharacterController controller;
        Vector2 moveInput;
        float dashTimer;

        void Awake() => controller = GetComponent<CharacterController>();
        public void OnMove(InputAction.CallbackContext c) => moveInput = c.ReadValue<Vector2>();
        public void OnDash(InputAction.CallbackContext c) { if (c.performed) dashTimer = dashDuration; }
        public void OnFire(InputAction.CallbackContext c)
        {
            if (c.performed && projectilePrefab && muzzle)
                Instantiate(projectilePrefab, muzzle.position, muzzle.rotation);
        }
        void Update()
        {
            dashTimer = Mathf.Max(0, dashTimer - Time.deltaTime);
            var direction = new Vector3(moveInput.x, 0, moveInput.y);
            controller.Move(direction * (dashTimer > 0 ? dashSpeed : moveSpeed) * Time.deltaTime);
            if (direction.sqrMagnitude > .01f) transform.forward = Vector3.Slerp(transform.forward, direction, 14f * Time.deltaTime);
        }
    }
}
