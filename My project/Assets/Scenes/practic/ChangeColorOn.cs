using UnityEngine;
using System.Collections;

public class ChangeColorOn : MonoBehaviour
{
    public GameObject ElementtoHighlight; // Элемент, который нужно выделить
    public Color highlightColor = Color.yellow; // Цвет выделения
    private Color originalColor; // Исходный цвет
    private Renderer elementRenderer; // Компонент Renderer
    private bool isHighlighted = false; // Текущее состояние выделения

    void Start()
    {
        if (ElementtoHighlight != null)
        {
            elementRenderer = ElementtoHighlight.GetComponent<Renderer>();
            if (elementRenderer != null)
            {
                originalColor = elementRenderer.material.color;
            }
            else
            {
                Debug.LogError("Компонент Renderer не найден у целевого объекта!");
            }
        }
        else
        {
            Debug.LogError("Целевой объект не назначен!");
        }
    }

    public void ToggleHighlight()
    {
        if (elementRenderer != null)
        {
            if (!isHighlighted)
            {
                elementRenderer.material.color = highlightColor; // Установить цвет выделения
                StartCoroutine(ResetColorAfterDelay(2f)); // Запускаем корутину для возврата исходного цвета через 2 секунды
            }
            isHighlighted = !isHighlighted; // Переключить состояние
        }
    }

    // Корутина для возврата исходного цвета через delay секунд
    private IEnumerator ResetColorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Ждем заданное количество времени
        if (elementRenderer != null)
        {
            elementRenderer.material.color = originalColor; // Возвращаем исходный цвет
        }
    }
}
