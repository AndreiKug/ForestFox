using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler, IInputable
{
    [SerializeField] private bool _horizontal = true, _vertical = true;

    private Image _joystick;
    private Image _stickChild;

    private Vector2 _inputV;

    public float Horizontal => _inputV.x;
    public float Vertical => _inputV.y;


    private void Start()
    {
        _joystick = GetComponent<Image>();
        _stickChild = transform.GetChild(0).GetComponent<Image>();
    }

    public virtual void OnPointerUp(PointerEventData point)
    {
        _inputV = Vector2.zero;
        _stickChild.rectTransform.anchoredPosition = Vector2.zero;
    }

    public virtual void OnPointerDown(PointerEventData point)
    {
        OnDrag(point);
    }

    public virtual void OnDrag(PointerEventData point)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystick.rectTransform, point.position, point.pressEventCamera, out pos))
        {
            pos.x = (pos.x / _joystick.rectTransform.sizeDelta.x);
            pos.y = (pos.y / _joystick.rectTransform.sizeDelta.y);

            _inputV = new Vector2(pos.x * 2, pos.y * 2);
            _inputV = (_inputV.magnitude > 1.0f) ? _inputV.normalized : _inputV;

            if (!_horizontal) _inputV.x = 0f;
            if (!_vertical) _inputV.y = 0f;

            _stickChild.rectTransform.anchoredPosition = new Vector2(_inputV.x * (_joystick.rectTransform.sizeDelta.x / 2), _inputV.y * (_joystick.rectTransform.sizeDelta.y / 2));
        }
    }
}