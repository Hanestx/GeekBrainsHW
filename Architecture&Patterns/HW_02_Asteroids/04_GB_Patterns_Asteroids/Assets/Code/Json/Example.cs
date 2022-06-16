using UnityEngine;


namespace Code.Json
{
    internal sealed class Example : MonoBehaviour
    {
        [SerializeField] private TextAsset _jsonFile;
        
        private void Start()
        {
            CompositeJson _compositeJson = new CompositeJson();
            _compositeJson.UnitFromJson(_compositeJson.ParseJSON(_jsonFile));
        }
    }
}