using UnityEngine;

[SelectionBase]
public class Door : MonoBehaviour
{
    // Компонент аниматора двери
    private Animator _animator;
    // Флаг состояния двери
    private bool _isOpen = false;
    // Флаг, указывающий, что игрок рядом с дверью
    private bool _isPlayerNear = false;
    // Компонент источника звука
    private AudioSource _audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Получаем компонент Animator на этом объекте
        _animator = GetComponent<Animator>();
        // Получаем компонент AudioSource на этом объекте
        _audioSource = GetComponent<AudioSource>();
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
            // Запускаем анимацию открытия двери через Trigger "Open"
            _animator.SetTrigger("Open");
            // Устанавливаем флаг, что дверь теперь открыта
            _isOpen = true;
            // Задаём свойству pitch случайное значение от 0.9 до 1.1
            _audioSource.pitch = Random.Range(0.9f, 1.1f);
            // Запускаем звук открытия двери
            _audioSource.Play();
        }
    }
}
