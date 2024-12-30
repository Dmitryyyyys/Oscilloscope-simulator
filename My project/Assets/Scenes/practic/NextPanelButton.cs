using UnityEngine;

public class NextPanelButton : MonoBehaviour
{
    public GameObject currentPanel; // Ссылка на текущую панель
    public GameObject nextPanel; // Ссылка на следующую панель

    public GameObject elementToHighlight; // Элемент установки, который нужно выделить
    public Color highlightColor = Color.yellow; // Цвет выделения
    private Color originalColor; // Исходный цвет элемента
    private Renderer elementRenderer; // Рендерер элемента

    private void Start()
    {
        if (elementToHighlight != null)
        {
            elementRenderer = elementToHighlight.GetComponent<Renderer>();
            if (elementRenderer != null)
            {
                // Сохраняем исходный цвет элемента
                originalColor = elementRenderer.material.color;
            }
            else
            {
                Debug.LogError("Элемент установки не имеет Renderer!");
            }
        }
        else
        {
            Debug.LogError("Элемент установки не назначен!");
        }
    }

    public void ShowNextPanel()
    {
        if (currentPanel != null)
        {
            currentPanel.SetActive(false); // Скрываем текущую панель
        }

        if (nextPanel != null)
        {
            nextPanel.SetActive(true); // Показываем следующую панель
        }

        HighlightElement(); // Выделяем элемент установки
    }

    private void HighlightElement()
    {
        if (elementRenderer != null)
        {
            elementRenderer.material.color = highlightColor; // Меняем цвет на выделяющий
            // Возвращаем цвет обратно через 2 секунды
            Invoke(nameof(ResetElementColor), 2f);
        }
    }

    private void ResetElementColor()
    {
        if (elementRenderer != null)
        {
            elementRenderer.material.color = originalColor; // Возвращаем исходный цвет
        }
    }
}
