using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace Task
{
    //Я думал сделать подгрузку картинок в панель чтобы можно было видеть что выбираешь, все работает но картинки в
    //формате tga и они на сцене отображаются как красные вопросики
    public class StreamingLoader : MonoBehaviour
    {
        [SerializeField] private GameObject icon;
        private List<GameObject> _currentIcons;

        private void Start()
        {
            icon.gameObject.SetActive(false);
        }
        
        private void OnEnable()
        {
            PersonLoader.OnMaleClick += Male;
            PersonLoader.OnFemaleClick += Female;
        }
        
        private void OnDisable()
        {
            PersonLoader.OnMaleClick -= Male;
            PersonLoader.OnFemaleClick -= Female;
        }

        private void Male()
        {
            Read("Male");
        }
        
        private void Female()
        {
            Read("Female");
        }

        private void Read(string name)
        {
            icon.gameObject.SetActive(true);

            var path = Path.Combine(Application.streamingAssetsPath, name);
            var directoryInfo = new DirectoryInfo(path);

            var allFiles = directoryInfo.GetFiles("*.*");
            if(_currentIcons != null)
                foreach (var current in _currentIcons)
                {
                    Destroy(current);
                }
            _currentIcons = new List<GameObject>();
            foreach (var file in allFiles)
            {
                if (file.Name.Contains("meta")) continue;
            
                var imageData = Instantiate(icon, icon.transform.parent);
                _currentIcons.Add(imageData);
                var bytes = File.ReadAllBytes(file.FullName);
                var texture2D = new Texture2D(1,1);
                texture2D.LoadImage(bytes);

                var rect = new Rect(0, 0, texture2D.width, texture2D.height);
                var pivot = new Vector2(0.5f,0.5f);

                var sprite = Sprite.Create(texture2D, rect, pivot);
                imageData.GetComponent<Image>().sprite = sprite;
            }
            icon.gameObject.SetActive(false);
        }
    }
}