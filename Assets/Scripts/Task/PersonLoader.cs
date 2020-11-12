using System;
using UnityEngine;

namespace Task
{
    public class PersonLoader : MonoBehaviour
    {
        [SerializeField] private PersonButton baseButton;
        [SerializeField] private Transform root;

        public static Action OnMaleClick;
        public static Action OnFemaleClick;
        
        private PersonsConfig _config;
        private GameObject currentPerson;

        private void Start()
        {
            _config = Resources.Load<PersonsConfig>("PersonsConfig");
            var names = _config.Persons;
            foreach (var name in names)
            {
                var btn = Instantiate(baseButton, baseButton.transform.parent);
                btn.Setup(name, OnPersonButton);
            }
            Destroy(baseButton.gameObject);
        }
        
        private void OnPersonButton(string id)
        {
            var asset = _config.GetPerson(id);
            if (currentPerson != null) Destroy(currentPerson);
            currentPerson = Instantiate(asset, root.position, root.rotation);
            switch (id)
            {
                case "Male":
                    OnMaleClick?.Invoke();
                    break;
                case "Female":
                    OnFemaleClick?.Invoke();
                    break;
            }
        }
    }
}