using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class FootstepAudio : MonoBehaviour
{
    [Header("Настройки звуков шагов")]
    public AudioClip[] footstepClips; // Массив звуков шагов
    public float minPitch = 0.9f;     // Минимальный тон
    public float maxPitch = 1.1f;     // Максимальный тон

    [Header("Параметры воспроизведения")]
    public float stepInterval = 0.5f; // Интервал между шагами (в секундах)
    public float speedThreshold = 0.1f; // Минимальная скорость для шагов

    private AudioSource audioSource;
    private float nextStepTime = 0f;
    private CharacterController characterController;

    public Vector3 velocity;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        print(characterController.velocity);
        velocity = characterController.velocity;
        velocity.y = 0; // Игнорируем вертикальную скорость
        float speed = velocity.magnitude; // Текущая скорость игрока


        // Если игрок движется и пора делать следующий шаг
        if (speed > speedThreshold && Time.time >= nextStepTime)
        {
            PlayRandomFootstep();
            nextStepTime = Time.time + stepInterval;
        }
    }

    void PlayRandomFootstep()
    {
        if (footstepClips.Length == 0 || audioSource == null) return;

        int randomIndex = Random.Range(0, footstepClips.Length);
        AudioClip clip = footstepClips[randomIndex];

        // Случайный тон для разнообразия
        float pitch = Random.Range(minPitch, maxPitch);
        audioSource.pitch = pitch;

        audioSource.PlayOneShot(clip);
    }
}