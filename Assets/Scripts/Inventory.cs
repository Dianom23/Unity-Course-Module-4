using System.Collections.Generic;
using UnityEngine;


public class Inventory : MonoBehaviour
{
    // Список для ключей
    public List<Key> Keys = new();
    // Дальность подбора предметов
    public float RayLength = 5;
    // Ссылка на камеру
    private Camera _camera;

    void Start()
    {
        // Получить ссылку на камеру с тегом MainCamera
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Метод, активирующийся на E
    private void OnInteract()
    {
        // Информация о столкновении луча
        RaycastHit hit;
        // Луч с основанием в центре камеры и направлением вперёд
        Ray ray = new(_camera.transform.position, _camera.transform.forward);

        // Проверяем, столкнулся ли луч с объектом в пределах RayLength
        // Если луч с чем-то столкнулся, то информацию записать в hit и выполнить код в if.
        if (Physics.Raycast(ray, out hit, RayLength))
        {
            // Берём коллайдер из информации о столкновении
            // Если получилось из колладера получить компонент Key, 
            // то записать ссылку на ключ в переменную key
            if (hit.collider.TryGetComponent(out Key key))
            {
                // В список добавить ключ
                Keys.Add(key);
                // Через коллайдер ключа обратиться к игровому объекту и выключить его
                hit.collider.gameObject.SetActive(false);
            }
        }
    }
}
