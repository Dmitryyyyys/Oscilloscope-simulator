using UnityEngine;

public class RotateButton2 : MonoBehaviour
{
    public Animator animator; // Анимация кнопки
    public Material graphMaterial; // Материал, на который применён шейдер
    private bool isRotatingForward = true; // Направление вращения
    private float defaultAmplitude = 0.2f; // Стандартное значение амплитуды
    private float lowAmplitude = 0.1f; // Уменьшенное значение амплитуды

    private void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        animator.SetBool("Play1", false);

        // Устанавливаем начальное значение амплитуды
        if (graphMaterial != null)
        {
            graphMaterial.SetFloat("_Amplitude", defaultAmplitude);
        }
    }

    private void OnMouseDown()
    {
        if (animator != null)
        {
            animator.SetBool("Play1", true);

            // Управляем анимацией в зависимости от направления
            if (isRotatingForward)
            {
                animator.Play("OnRotate2");
            }
            else
            {
                animator.Play("OnRotate2Back");
            }

            // Переключаем направление вращения
            isRotatingForward = !isRotatingForward;
        }

        // Меняем амплитуду в шейдере при каждом нажатии
        if (graphMaterial != null)
        {
            float newAmplitude = isRotatingForward ? lowAmplitude : defaultAmplitude;
            graphMaterial.SetFloat("_Amplitude", newAmplitude);
        }
    }
}
