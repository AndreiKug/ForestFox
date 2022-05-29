using UnityEngine;

// <<<Коллизия камеры>>>.
// <<<Ограничение тачей по осям>>>.

public class CameraCollision : MonoBehaviour
{
    [Tooltip("Мин/Макс дистанция")]
    [SerializeField] private Vector2 _clampDistance = new Vector2 { x = 2f, y = 5f };

    [Tooltip("Сглаживание при перемещении")]
    [SerializeField] [Range(1f, 25f)] private float _smooth = 15f;

    [Tooltip("Слой детекции коллизии")]
    [SerializeField] private LayerMask _layerObstacles;

    // Направление
    private Vector3 _direction;

    // Дистанция
    private float _distance;


    private void Start()
    {
        // Запись направления и дистанции на Старте
        _direction = transform.localPosition.normalized;
        _distance = transform.localPosition.magnitude;
    }

    private void LateUpdate()
    {
        // Запись ThirdPersonCamera
        Transform parentCamera = transform.parent;

        // Перевод локальных координат в глобальные
        Vector3 desiredCameraPos = parentCamera.TransformPoint(_direction * _clampDistance.y);

        // Создаем и запускаем райкаст
        RaycastHit hit;

        if (Physics.Linecast(transform.parent.position, desiredCameraPos, out hit, _layerObstacles))
        {
            // Если коллизия обнаружена то уменьшаем дистанцию до ThirdPersonCamera
            _distance = Mathf.Clamp(hit.distance * 0.9f, _clampDistance.x, _clampDistance.y);
        }
        else
        {
            // Если нет то устанавливаем максимальную дистанцию, текущую дистанцию
            _distance = _clampDistance.y;
        }

        // Перемещаем 
        transform.localPosition = Vector3.Lerp(transform.localPosition, _direction * _distance, Time.deltaTime * _smooth);
    }
}