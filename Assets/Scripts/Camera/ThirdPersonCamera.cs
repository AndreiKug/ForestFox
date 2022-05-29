using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Tooltip("Цель слежки")]
    [SerializeField] private Transform _target;

    [Tooltip("Стартовый ввод - управление")]
    [SerializeField] private GameObject _startInput;

    [Tooltip("Сенса")]
    [SerializeField] [Range(50f, 250f)] private float _sensivity = 150f;

    /*[Tooltip("Скорость вращения")]
    [SerializeField] [Range(50f, 250f)] private float _angularSpeed = 120f;*/

    [Tooltip("Ограничитель поворта")]
    [SerializeField] private Vector2 _clampAngle = new Vector2 { x = -50f, y = 80f };

    // Значение поворота
    private Vector2 _angle;

    // Дочерняя камера
    private Transform _childCamera;

    // Интерфейс текущего управления
    private IInputable _input;


    private void Start()
    {
        // Установка данных для текущего обьекта - родителя
        _input = _startInput.GetComponent<IInputable>();

        Vector3 rot = transform.localRotation.eulerAngles;

        _angle.x = rot.x;
        _angle.y = rot.y;

        // Установка данных для дочернего обьекта - дочерняя камера
        _childCamera = transform.GetChild(0);

        //_childCamera.localPosition = Vector3.zero;
        //_childCamera.localRotation = Quaternion.Euler(0f, 0f, 0f);
    }

    private void LateUpdate()
    {
        Follow();
        Rotate();
    }

    // Перемещение
    private void Follow()
    {
        // Перемещение текущего обьекта в цель
        transform.position = _target.position;
    }

    // Вращение
    private void Rotate()
    {
        // Считывание значений поворота
        float horizontal = _input.Horizontal;
        float vertical = _input.Vertical;

        // Вычисление поворота
        _angle.x -= horizontal * _sensivity * Time.deltaTime;
        _angle.y += vertical * _sensivity * Time.deltaTime;

        // Огранечение поворота
        _angle.y = Mathf.Clamp(_angle.y, _clampAngle.x, _clampAngle.y);

        // Выполнение поворота
        //Quaternion localRot = Quaternion.Euler(_angle.y * -1, _angle.x * -1, 0);
        Quaternion localRot = Quaternion.Euler(_angle.y, _angle.x, 0);
        transform.localRotation = localRot;
    }

    // Установка текущего интерфейса управления
    public void SetInput(GameObject inputable)
    {
        _input = inputable.GetComponent<IInputable>();
    }
}