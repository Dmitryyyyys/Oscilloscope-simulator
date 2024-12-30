using System.Collections;
using UnityEngine;

public class ButtonRotation : MonoBehaviour
{
    public Animator animator; // Анимация кнопки
    public Material oscilloscopeMaterial; // Материал с шейдером графика
    public float targetAmplitude = 0.26f; // Целевое значение амплитуды
    private float originalAmplitude; // Исходное значение амплитуды
    private float originalSpeed; // Исходная скорость графика
    private bool isRotatingForward = true; // Направление вращения
    private bool isAnimatingAmplitude = false; // Флаг анимации амплитуды

    private void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        if (oscilloscopeMaterial == null)
        {
            Debug.LogError("Oscilloscope material is not assigned!");
            return;
        }

        // Сохраняем исходные значения амплитуды и скорости
        if (oscilloscopeMaterial.HasProperty("_Amplitude") && oscilloscopeMaterial.HasProperty("_Speed"))
        {
            originalAmplitude = oscilloscopeMaterial.GetFloat("_Amplitude");
            originalSpeed = oscilloscopeMaterial.GetFloat("_Speed");
        }
        else
        {
            Debug.LogError("Material does not have required properties (_Amplitude, _Speed)!");
        }

        // Устанавливаем начальное состояние анимации
        animator.SetBool("Play", false);
    }

    private void OnMouseDown()
    {
        // Переключение анимации
        if (animator != null)
        {
            animator.SetBool("Play", true);

            if (isRotatingForward)
            {
                animator.Play("OnRotate");
            }
            else
            {
                animator.Play("BackRotate");
            }

            isRotatingForward = !isRotatingForward;
        }

        // Плавное изменение амплитуды
        if (oscilloscopeMaterial != null && !isAnimatingAmplitude)
        {
            StartCoroutine(ChangeAmplitude(targetAmplitude));
        }
    }

    private IEnumerator ChangeAmplitude(float targetValue)
    {
        isAnimatingAmplitude = true;

        if (oscilloscopeMaterial.HasProperty("_Amplitude"))
        {
            float currentAmplitude = oscilloscopeMaterial.GetFloat("_Amplitude");

            while (Mathf.Abs(currentAmplitude - targetValue) > 0.01f)
            {
                currentAmplitude = Mathf.Lerp(currentAmplitude, targetValue, originalSpeed * Time.deltaTime);
                oscilloscopeMaterial.SetFloat("_Amplitude", currentAmplitude);
                yield return null;
            }

            // Убедимся, что значение точно достигнуто
            oscilloscopeMaterial.SetFloat("_Amplitude", targetValue);
        }

        isAnimatingAmplitude = false;
    }

    private void OnDestroy()
    {
        // Восстанавливаем исходные значения, если материал используется повторно
        if (oscilloscopeMaterial != null)
        {
            oscilloscopeMaterial.SetFloat("_Amplitude", originalAmplitude);
        }
    }
}
