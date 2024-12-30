using UnityEngine;

public class SpeedButton : MonoBehaviour
{
    public Animator animator;
    public Material graphMaterial; // Материал, на который применён шейдер
    private bool isOn = false;  // Текущее состояние кнопки (включено/выключено)
    private float defaultSpeed = 3f; // Стандартная скорость графика
    private float slowSpeed = 0.1f;  // Замедленная скорость графика

    private void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>(); // Получаем компонент Animator, если он не назначен
        }

        // Устанавливаем начальное состояние анимации
        animator.SetBool("Play", false);

        if (graphMaterial != null)
        {
            graphMaterial.SetFloat("_Speed", defaultSpeed); // Устанавливаем начальную скорость графика
        }
    }

    private void OnMouseDown()
    {
        if (animator != null)
        {
            // Включаем/выключаем анимацию при нажатии
            isOn = !isOn;
            animator.SetBool("Play", isOn);
        }

        // Изменяем скорость графика
        if (graphMaterial != null)
        {
            float newSpeed = isOn ? slowSpeed : defaultSpeed;
            graphMaterial.SetFloat("_Speed", newSpeed);
        }
    }
}
