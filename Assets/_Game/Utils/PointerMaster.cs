using MyEvents;
using UnityEngine;

public class PointerMaster : MonoBehaviour
{
    public LayerMask floorLayer;

    private LineRenderer _lineRenderer;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        // center on mouse
        var pos = Input.mousePosition;
        pos.z = 10;
        pos = Camera.main.ScreenToWorldPoint(pos);
        transform.position = pos;

        DisplayFloorLine(transform.position, GetFloorPoint(transform.position));
    }

    void DisplayFloorLine (Vector3 _startingPoint, Vector3 _floorPoint)
    {
        Vector3[] positions = new Vector3[2];
        positions[0] = _startingPoint;
        positions[1] = _floorPoint;
        
        _lineRenderer.SetPositions(positions);
        _lineRenderer.startWidth = 0.05f;

        _lineRenderer.enabled = _startingPoint != _floorPoint;
    }

    public Vector3 GetFloorPoint(Vector3 _startingPoint)
    {
        var rayStart = _startingPoint;
        var rayDir = Vector2.down;
        float rayDist = 10.0f;

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