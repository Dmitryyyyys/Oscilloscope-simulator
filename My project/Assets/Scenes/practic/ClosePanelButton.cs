using UnityEngine;

public class ClosePanelButton : MonoBehaviour
{
    public GameObject panel; // Ссылка на панель, которую нужно закрыть

   
    public void ClosePanel()
    {
        if (panel != null)
        {
            panel.SetActive(false); // Скрываем панель
        }
        else
        {
            Debug.LogError("Панель не назначена!");
        }
    }
}
