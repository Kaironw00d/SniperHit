using UnityEngine;

public class RayCastBasedTagSelector : MonoBehaviour, ISelector
{
    [SerializeField] private string selectableTag = "Selectable";
    
    private Transform _selection;
    private Vector3 _hitPoint;
    
    public void Check(Ray ray)
    {
        _selection = null;
        if(!Physics.Raycast(ray, out var hit, Mathf.Infinity)) return;
        
        var selection = hit.transform;
        if (selection.CompareTag(selectableTag))
        {
            _selection = selection;
            _hitPoint = hit.point;
        }
    }

    public Transform GetSelection() => _selection;

    public Vector3 GetHitPoint() => _hitPoint;
}