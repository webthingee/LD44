using MyEvents;
using TMPro;
using UnityEngine;

public class PointerMaster : MonoBehaviour
{
    public LayerMask floorLayer;

    private LineRenderer _lineRenderer;
    public SpriteRenderer spriteRenderer;
    [SerializeField] private TextMeshProUGUI _mousePositionText; // it is being used silly unity
    private Vector2 _mousePosition;
    private GameObject _objUnderPoint;
    
    public Sprite[] cursors;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        spriteRenderer.sprite = cursors[0];
        Cursor.visible = false;
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


        if (FindObjectOfType<PlayerFlight>().enabled == false)
        {
            DisplayFloorLine(transform.position, GetFloorPoint(transform.position));
            spriteRenderer.sprite = cursors[0];
        }
        else
        {
            DisplayFloorLine(transform.position, FindObjectOfType<PlayerFlight>().transform.position); 
            spriteRenderer.sprite = cursors[2];
        }
        
        ObjectUnderPointer();
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

                var x = hit.GetComponent<Interactable>();
                if (x != null)
                {
                    _mousePositionText.text = hit.name;
                    spriteRenderer.sprite = cursors[1];                    
                }
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

        if (_floorPoint == Vector3.zero || _startingPoint == Vector3.zero)
        {
            _lineRenderer.enabled = false;
        }
        else
        {
            _lineRenderer.enabled = true;
        }
        
        _lineRenderer.SetPositions(positions);
        _lineRenderer.startWidth = 0.05f;

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