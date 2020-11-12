using System.Linq;
using UnityEngine;

namespace Task
{
    [CreateAssetMenu(fileName = "PersonsConfig", menuName = "Task/PersonsConfig", order = 0)]
    public class PersonsConfig : ScriptableObject
    {
        [SerializeField] private string[] persons;

        public string[] Persons => persons;
        
        public GameObject GetPerson(string personName)
        {
            var objName = persons.FirstOrDefault(e => e == personName);
            return string.IsNullOrEmpty(objName) ? null : LoadObject(personName);
        }
        
        private static GameObject LoadObject(string personName)
        {
            return Resources.Load<GameObject>($"Persons/{personName}");
        }
        
#if UNITY_EDITOR
        private void Reset()
        {
            var objects = Resources.LoadAll<GameObject>("Persons");
            persons = new string[objects.Length];
            for (var i = 0; i < persons.Length; i++)
            {
                persons[i] = objects[i].name;
            }
        }
#endif
    }
}