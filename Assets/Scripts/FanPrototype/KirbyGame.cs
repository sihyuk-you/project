using UnityEngine;
using UnityEngine.InputSystem;

namespace KirbyFanPrototype
{
    public sealed class KirbyGame : MonoBehaviour
    {
        GameObject kirby;
        Vector3 velocity;
        readonly System.Collections.Generic.List<GameObject> enemies = new();

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static void Boot()
        {
            if (FindFirstObjectByType<KirbyGame>() != null) return;
            new GameObject("Kirby Fan Game").AddComponent<KirbyGame>();
        }

        void Start()
        {
            BuildWorld();
            BuildKirby();
            for (int i = 0; i < 8; i++) BuildWaddleDee(new Vector3((i % 4 - 1.5f) * 4, .8f, -8 - i * 4));
        }

        GameObject Part(PrimitiveType type, string name, Vector3 position, Vector3 scale, Color color, Transform parent = null)
        {
            var part = GameObject.CreatePrimitive(type);
            part.name = name; part.transform.position = position; part.transform.localScale = scale;
            if (parent) part.transform.SetParent(parent, true);
            part.GetComponent<Renderer>().material.color = color;
            return part;
        }

        void BuildWorld()
        {
            Part(PrimitiveType.Plane, "Dream Meadow", Vector3.zero, new Vector3(8, 1, 14), new Color(.28f, .78f, .35f));
            var light = new GameObject("Sun").AddComponent<Light>(); light.type = LightType.Directional; light.intensity = 1.7f;
            light.transform.rotation = Quaternion.Euler(45, -35, 0);
            var cameraObject = new GameObject("Main Camera"); cameraObject.tag = "MainCamera";
            var cam = cameraObject.AddComponent<Camera>(); cam.fieldOfView = 52; cam.transform.position = new Vector3(0, 10, 14);
            cam.transform.rotation = Quaternion.Euler(30, 180, 0);
            RenderSettings.ambientLight = new Color(.55f, .65f, .8f);
        }

        void BuildKirby()
        {
            kirby = new GameObject("Kirby");
            Part(PrimitiveType.Sphere, "Pink Body", new Vector3(0, 1.25f, 2), new Vector3(2.2f, 2.2f, 2.1f), new Color(1, .38f, .63f), kirby.transform);
            Part(PrimitiveType.Sphere, "Left Foot", new Vector3(-.65f, .35f, 2.15f), new Vector3(1.05f, .45f, 1.35f), new Color(.82f, .05f, .22f), kirby.transform);
            Part(PrimitiveType.Sphere, "Right Foot", new Vector3(.65f, .35f, 2.15f), new Vector3(1.05f, .45f, 1.35f), new Color(.82f, .05f, .22f), kirby.transform);
            foreach (float x in new[] { -.38f, .38f })
                Part(PrimitiveType.Sphere, "Eye", new Vector3(x, 1.55f, 2.96f), new Vector3(.18f, .48f, .12f), new Color(.04f, .05f, .12f), kirby.transform);
        }

        void BuildWaddleDee(Vector3 p)
        {
            var enemy = new GameObject("Waddle Dee");
            Part(PrimitiveType.Sphere, "Body", p, new Vector3(1.5f, 1.5f, 1.4f), new Color(1, .45f, .16f), enemy.transform);
            Part(PrimitiveType.Sphere, "Face", p + new Vector3(0, 0, .65f), new Vector3(1.05f, .82f, .25f), new Color(1, .78f, .45f), enemy.transform);
            enemies.Add(enemy);
        }

        void Update()
        {
            if (!kirby) return;
            var keyboard = Keyboard.current;
            float x = 0, z = 0;
            if (keyboard != null)
            {
                x = (keyboard.rightArrowKey.isPressed ? 1 : 0) - (keyboard.leftArrowKey.isPressed ? 1 : 0);
                z = (keyboard.upArrowKey.isPressed ? -1 : 0) + (keyboard.downArrowKey.isPressed ? 1 : 0);
                if (keyboard.spaceKey.wasPressedThisFrame) velocity.y = 7;
            }
            velocity.y -= 18 * Time.deltaTime;
            kirby.transform.position += new Vector3(x * 6, velocity.y, z * 6) * Time.deltaTime;
            if (kirby.transform.position.y < 0) { var p = kirby.transform.position; p.y = 0; kirby.transform.position = p; velocity.y = 0; }
            foreach (var enemy in enemies)
                if (enemy) enemy.transform.position += (kirby.transform.position - enemy.transform.position).normalized * 1.2f * Time.deltaTime;
        }
    }
}
