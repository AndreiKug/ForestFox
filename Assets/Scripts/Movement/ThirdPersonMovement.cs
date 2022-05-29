using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))] //Автоматически добавляем компонент на объект, которому присваиваем этот скрипт. Без него не будет работать
[RequireComponent(typeof(Animator))]

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] private MovementCharacteristicsTest _characteristics; //Поле для контейнера с характеристиками 
    [SerializeField] private Transform _camera; //Персонжа будет перемещаться относительно камеры
    [SerializeField] private JoyStickInput _joystick; // поле для класса джойстика

    private bool _canJumping; // Флаг для проверки возможности прыжка

    private float _vertical, _horizontal, _run; //В эти поля записываем значения нажатых клавиш

    private readonly string STR_VERTICAL = "Vertical";
    private readonly string STR_HORIZONTAL = "Horizontal";
    // private readonly string STR_RUN = "Run"; 
    // private readonly string STR_SPEED = "Speed";
    private readonly string STR_JUMP = "Jump"; // Добавляем название кнопки в Input Manager Unity 


    private const float DISTANCE_OFFSET_CAMERA = 5f; // Расстояние от камеры до точки, в которую будем поворачивать персонажа

    private CharacterController _controller; //Получаем контроллер, через который будем двигать персонажа.
    private Animator _animator;

    private Vector3 _direction; //Для направления перемещения
    private Quaternion _look; // Для отслеживания поворота персонажа

    // private Vector3 TargetRotate => _camera.forward * DISTANCE_OFFSET_CAMERA; //В даную точку мы будем поворачивать персонажа
    private Vector3 TargetRotate => _direction;
    private bool Idle => _horizontal == 0.0f && _vertical == 0.0f; //Если не нажаты никакие клавиши, то будет true. Значит, персонаж стоит на месте

    private float MaxMovementValue => Mathf.Max(Mathf.Abs(_horizontal), Mathf.Abs(_vertical)); // Получаем максимальное значение по горизонтали или вертикали. Далее будем назначать скорость перемещения в аниматоре



    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();

        Cursor.visible = _characteristics.VisibleCursor; //Устанавливаем видимость курсора в зависимости от флага в контейнере
    }

    
    void Update()
    {
        Movement();
        Rotate();
    }

    public void EnabledJumping(bool isActive) => _canJumping = isActive; // Передаем бул через аргумент и устанавливаем в _canJumping

    private void Movement()
    {
        

        if (_controller.isGrounded) // Если контроллер на земле, то записываем значения нажатых клавиш
        {
            // _horizontal = Input.GetAxis(STR_HORIZONTAL);
            _horizontal = _joystick.Horizontal;
            
            // _vertical = Input.GetAxis(STR_VERTICAL);
            _vertical = _joystick.Vertical;
            
            // _run = Input.GetAxis(STR_RUN);

            // _direction = transform.TransformDirection(_horizontal, 0, _vertical).normalized; // Вычисляем новое направление движения в зависимости от нажатых клавиш
            _direction = _camera.TransformDirection(_horizontal, 0, _vertical).normalized;

           

            PlayAnimation();
            Jump();

        }

        _direction.y -= _characteristics.Gravity * Time.deltaTime; //Отнимаем у вектора направления движения по оси Y значение гравитации для притягивания к земле. Умножаем на 60 для плавного смещения

        // float speed = _run * _characteristics.RunSpeed + _characteristics.MovementSpeed; // вычисляем скорость в зависимости от нажатых клавиш. Т.е. к стандартной скорости перемещения будет прибавляться либо 0, либо 1 * на скорость бега, если зажат shift 
        float speed = _characteristics.MovementSpeed * MaxMovementValue;

        Vector3 dir = _direction * _characteristics.MovementSpeed * Time.deltaTime; // Умножаем наше направление на стандартную скорость перемещения. Для run заменяем _characteristics.MovementSpeed на speed

        // dir.y = _direction.y; // В перемещение по y записываем старое значение, т.к. с новыми расчетами speed от run гравитация будет работать некорректно


        _controller.Move(dir); //Перемещаем наш контроллер

    }

    private void Rotate()
    {
        if (Idle) return;

        Vector3 target = TargetRotate; // Точка, в которую должен повернуться персонаж
        target.y = 0; // Обнуляем по y, чтобы персонаж вращался правильно и не наклонялся

        _look = Quaternion.LookRotation(target); //Вычисляем угол

        float speed = _characteristics.AngularSpeed * Time.deltaTime;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, _look, speed); //Поворачиваем персонажа
        // _camera.transform.rotation = Quaternion.RotateTowards(transform.rotation, _look, speed/2);
    }

    private void Jump()
    {
        if(_canJumping) // Если нажата кнопка прыжка
        {       
            _animator.SetTrigger(STR_JUMP);
            _direction.y += _characteristics.JumpForce; // прибавляем силу прыжка к значению направления движения по y
            _canJumping = false;
           
        }
    } 

    private void PlayAnimation()
    {
        // float horizontal = run * _horizontal + _horizontal; Для бега
        // float vertical = run * _vertical + _vertical;
        _animator.SetFloat(STR_VERTICAL, _vertical);
        _animator.SetFloat(STR_HORIZONTAL, _horizontal);
        //_animator.SetFloat(STR_SPEED, MaxMovementValue);
    }

}
