using UnityEngine;

public class ChangeAmplitude : MonoBehaviour
{
    public Animator animator; // Анимация кнопки
    public Material graphMaterial; // Материал, на который применён шейдер
    private bool isRotatingForward = true; // Направление вращения
    private float defaultFrequency = 33.0f; // Стандартное значение частоты
    private float targetFrequency = 40.0f; // Значение, на которое будем переключать частоту

    private void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        animator.SetBool("Play1", false);

        // Устанавливаем начальное значение частоты
        if (graphMaterial != null)
        {
            graphMaterial.SetFloat("_Frequency", defaultFrequency);
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

        // Меняем частоту в шейдере при каждом нажатии
        if (graphMaterial != null)
        {
            // Если текущая частота равна стандартному значению, меняем на targetFrequency, иначе обратно на defaultFrequency
            float currentFrequency = graphMaterial.GetFloat("_Frequency");
            float newFrequency = (currentFrequency == defaultFrequency) ? targetFrequency : defaultFrequency;

            // Устанавливаем новую частоту
            graphMaterial.SetFloat("_Frequency", newFrequency);
        }
    }
}
