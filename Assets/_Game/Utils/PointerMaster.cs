using MyEvents;
using TMPro;
using UnityEngine;

public class PointerMaster : MonoBehaviour
{
    public LayerMask floorLayer;

    private LineRenderer _lineRenderer;
    [SerializeField] private TextMeshProUGUI _mousePositionText;
    private Vector2 _mousePosition;
    private GameObject _objUnderPoint;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    public Vector2 FloorUnderFoot(Transform pos)
    {
        return GetFloorPoint(pos.position);
    }

    private void Update()
    {
        // center on mouse
        var pos = Input.mousePosition;
        pos.z = 20;
        pos = Camera.main.ScreenToWorldPoint(pos);
        transform.position = pos;

        ObjectUnderPointer();

        DisplayFloorLine(transform.position, GetFloorPoint(transform.position));
    }

    private void ObjectUnderPointer()
    {        
        _mousePositionText.text = "";
        
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 0.001f);
        if (hits.Length > 0)
        {
            foreach (Collider2D hit in hits)
            {
                _objUnderPoint = hit.gameObject;
                _mousePositionText.text = hit.name;
            }
        }
        
//        FloorPointEvent OnGameObjectHover = new FloorPointEvent
//        {
//            description = "Unit " + gameObject.name + " Health Event.", 
//            obj = _objUnderPoint
//        };
    }

    private void DisplayFloorLine (Vector3 _startingPoint, Vector3 _floorPoint)
    {
        Vector3[] positions = new Vector3[2];
        positions[0] = _startingPoint;
        positions[1] = _floorPoint;
        
        _lineRenderer.SetPositions(positions);
        _lineRenderer.startWidth = 0.05f;

        _lineRenderer.enabled = _startingPoint != _floorPoint;
        _lineRenderer.enabled = _startingPoint != Vector3.zero;
    }

    public Vector3 GetFloorPoint(Vector3 _startingPoint)
    {
        var rayStart = _startingPoint;
        var rayDir = Vector2.down;
        float rayDist = 20.0f;

        Vector2 floorPosition = Vector2.zero;
        
        RaycastHit2D hit = Physics2D.Raycast(rayStart, rayDir, rayDist, floorLayer); //1 << LayerMask.NameToLayer("Enemy"));
        if (hit)
        {
            floorPosition = hit.point;
        }
        
        FloorPointEvent OnFloorPointEvent = new FloorPointEvent
        {
            description = "Unit " + gameObject.name + " Health Event.", 
            floorPoint = floorPosition
        };
        OnFloorPointEvent.FireEvent();

        return floorPosition;
    }
}