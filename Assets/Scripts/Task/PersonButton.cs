using System;
using UnityEngine;
using UnityEngine.UI;

namespace Task
{
    public class PersonButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private Text text;
        
        public void Setup(string id, Action<string> callback)
        {
            text.text = id;
      
            button.onClick.AddListener(delegate {
                callback?.Invoke(id);
            });
        }
    }
}