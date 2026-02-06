using UnityEngine;

[SelectionBase]
public class Door : MonoBehaviour
{
    public bool IsNeedKey;
    public int IdKey;

    private Inventory _inventory;

    // Компонент аниматора двери
    private Animator _animator;
    // Флаг состояния двери
    private bool _isOpen = false;
    // Флаг, указывающий, что игрок рядом с дверью
    private bool _isPlayerNear = false; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Получаем компонент Animator на этом объекте
        _animator = GetComponent<Animator>();
        _inventory = FindFirstObjectByType<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, является ли объект игроком
        if (other.CompareTag("Player"))
        {
            // Устанавливаем флаг, что игрок рядом с дверью
            _isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Проверяем, является ли объект игроком
        if (other.CompareTag("Player"))
        {
            // Сбрасываем флаг, что игрок рядом с дверью
            _isPlayerNear = false;
        }
    }

    private void OnInteract()
    {

        // Проверяем, что дверь закрыта и игрок рядом
        if (_isOpen == false && _isPlayerNear == true)
        {
            bool canOpen = !IsNeedKey || _inventory.UseKey(IdKey);

            if (canOpen == false)
            {
                return;
            }   

            // Запускаем анимацию открытия двери через Trigger "Open"
            _animator.SetTrigger("Open");
            // Устанавливаем флаг, что дверь теперь открыта
            _isOpen = true;
        }
    }
}
