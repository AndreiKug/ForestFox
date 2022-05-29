using UnityEngine;
using UnityEngine.EventSystems;

public class TouchField : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IInputable
{
    [SerializeField] private bool _horizontal = true, _vertical = true;

    [SerializeField] [Range(1f, 12f)] private float _decreaseSensivity = 7.5f;

    private bool _pressed;
    private int _pointerId;

    private Vector2 _pointerOld, _touchDist;

    public float Horizontal => _touchDist.x / _decreaseSensivity;
    public float Vertical => _touchDist.y / _decreaseSensivity;


    private void Update()
    {
        if (_pressed)
        {
            if (_pointerId >= 0 && _pointerId < Input.touches.Length)
            {
                _touchDist = Input.touches[_pointerId].position - _pointerOld;
                _pointerOld = Input.touches[_pointerId].position;

                if (!_horizontal) _touchDist.x = 0f;
                if (!_vertical) _touchDist.y = 0f;
            }
            else
            {
                _touchDist = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - _pointerOld;
                _pointerOld = Input.mousePosition;

                if (!_horizontal) _touchDist.x = 0f;
                if (!_vertical) _touchDist.y = 0f;
            }
        }
        else
        {
            _touchDist = new Vector2();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _pressed = true;
        _pointerId = eventData.pointerId;
        _pointerOld = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _pressed = false;
    }
}