using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseManager : MonoBehaviour
{
    [SerializeField] Texture2D _iconMove;
    [SerializeField] Texture2D _iconSize;
    [SerializeField] float _minRadius = 1f;
    [SerializeField] float _maxRadius = 5f;
    [SerializeField] float _minMForce = 4f;
    [SerializeField] float _radiusRat = 4f;

    Ray _ray;
    bool _pressed;
    GameObject _moveZone = null;
    CircleShape _changeSize = null;
    AreaEffector2D _changeEffector = null;
    Vector3 _worldPos;

    void Update()
    {
        Debug.Log(_pressed);
        if(_pressed && _moveZone != null)
        {
            Debug.Log($"je dois deplacer{_moveZone.name}");
            _moveZone.transform.position = _worldPos;
        }
        if(_pressed && _changeSize != null)
        {
            Debug.Log($"je dois deplacer{_changeSize.name}");
            float radius = Vector2.Distance(_changeSize.transform.position, _worldPos);
            _changeSize.Radius = Mathf.Clamp(radius, _minRadius, _maxRadius);
            _changeEffector.forceMagnitude = _minMForce - (_radiusRat) + _radiusRat * _changeSize.Radius;
        }
        if(!_pressed)
        {
            _moveZone = null;
            _changeSize = null;
        }
    }

    public void MouseMove(InputAction.CallbackContext context)
    {
        Vector2 pointerPos = context.ReadValue<Vector2>();
        _ray = Camera.main.ScreenPointToRay(pointerPos);

        RaycastHit2D hit = Physics2D.GetRayIntersection(_ray);

        _worldPos = Camera.main.ScreenToWorldPoint(pointerPos);
        _worldPos.z = 0;

        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("CenterZone"))
            {
                Debug.Log("Je suis au centre");
                Cursor.SetCursor(_iconMove, new Vector2(256, 256), CursorMode.Auto);
                _moveZone = hit.collider.transform.parent.gameObject;
            }
            else if (hit.collider.CompareTag("OuterZone"))
            {
                Debug.Log("Je suis sur la bordure");
                Cursor.SetCursor(_iconSize, new Vector2(256, 256), CursorMode.Auto);
                _changeSize = hit.collider.GetComponent<CircleShape>();
                _changeEffector = hit.collider.GetComponent<AreaEffector2D>();
            }
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }

    public void MouseClick(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Started:
                break;
            case InputActionPhase.Performed:
                _pressed = true;
                break;
            case InputActionPhase.Canceled:
                _pressed = false;
                break;
            default:
                break;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(_ray.origin, _ray.direction * 1000f);
    }
}
