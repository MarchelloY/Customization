using UnityEngine;

namespace DefaultNamespace
{
    public class ResourcesLoader : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Transform prefabRoot;
        
        [SerializeField] private string[] icons = new string[3];

        private GameObject obj;

        private void Update()
        {
            for (var i = 1; i < 4; i++)
            {
                if (Input.GetKeyDown($"{i}"))
                {
                    SetupIcon(icons[i - 1]);
                }
            }
        }

        private void SetupIcon(string icon)
        {
            var config = Resources.Load<IconInfo>($"Configs/{icon}");
            var sprite = Resources.Load<Sprite>($"Icons/{config.IconName}");
            var prefab = Resources.Load<GameObject>($"Prefabs/{config.PrefabName}");

            spriteRenderer.sprite = sprite;
            if (obj != null) Destroy(obj);
            obj = Instantiate(prefab, prefabRoot);
        }
    }
}