using UnityEngine;
using System.Collections;

public class OpenAmplitudePanel : MonoBehaviour
{
    // Ссылка на объект панели
    public GameObject panel;

    // Объект, цвет которого нужно изменить
    public GameObject objectToHighlight;

    // Цвет для выделения объекта
    public Color highlightColor = Color.yellow;

    // Оригинальный цвет объекта
    private Color originalColor;

    // Компонент Renderer объекта
    private Renderer objectRenderer;

    private void Start()
    {
        if (objectToHighlight != null)
        {
            // Получаем Renderer объекта
            objectRenderer = objectToHighlight.GetComponent<Renderer>();
            if (objectRenderer != null)
            {
                // Сохраняем оригинальный цвет
                originalColor = objectRenderer.material.color;
            }
            else
            {
                Debug.LogError("Объект для выделения не имеет компонента Renderer!");
            }
        }

        // Скрываем панель при запуске
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }

    // Метод вызывается при нажатии кнопки
    public void Toggle()
    {
        if (panel != null)
        {
            // Переключаем видимость панели
            bool isActive = !panel.activeSelf;
            panel.SetActive(isActive);

            // Меняем цвет объекта в зависимости от состояния панели
            if (objectRenderer != null)
            {
                objectRenderer.material.color = highlightColor; // Устанавливаем цвет выделения
                StartCoroutine(ResetColorAfterDelay(2f)); // Запускаем корутину для возврата исходного цвета через 2 секунды
            }
        }
    }

    // Корутина для возврата исходного цвета через delay секунд
    private IEnumerator ResetColorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Ждем заданное количество времени
        if (objectRenderer != null)
        {
            objectRenderer.material.color = originalColor; // Возвращаем исходный цвет
        }
    }
}
