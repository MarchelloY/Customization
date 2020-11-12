using DefaultNamespace;
using UnityEngine;

public class EffectsPlayer : MonoBehaviour
{
    [SerializeField] private EffectButton baseButton;
    private EffectsConfig _config;
  
    private void Start()
    {
        _config = Resources.Load<EffectsConfig>("EffectsConfig");
        var names = _config.Effects;
        foreach (var objName in names)
        {
            var btn = Instantiate(baseButton, baseButton.transform.parent);
            btn.Setup(objName, OnEffectButton);
        }
      
        baseButton.Setup("Random", OnRandomEffectButton);
    }
    
    private void OnEffectButton(string id)
    {
        var asset = _config.GetEffect(id);
        var obj = Instantiate(asset, Vector3.zero, Quaternion.identity);
        Destroy(obj, 5f);
    }
    
    private void OnRandomEffectButton(string id)
    {
        var asset = _config.GetRandomEffect();
        var obj = Instantiate(asset, Vector3.zero, Quaternion.identity);
        Destroy(obj, 5f);
    }
}