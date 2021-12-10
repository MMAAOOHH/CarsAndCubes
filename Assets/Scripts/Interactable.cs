using Assets.QuickOutline.Scripts;
using UnityEngine;

[RequireComponent(typeof(QuickOutline))]
public class Interactable : MonoBehaviour
{
    private QuickOutline _outline;

    private void Awake()
    {
        _outline = GetComponent<QuickOutline>();
    }
    
    private void ToggleHighlight()
    {
        _outline.enabled = !_outline.enabled;
    }
}
