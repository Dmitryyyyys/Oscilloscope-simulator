using UnityEngine;
using UnityEngine.UI;

public class SecondCalculated : MonoBehaviour
{
    public InputField deltaXField; 
    public InputField distanceXField; 
    public InputField periodField; 
    public InputField frequencyField; 
    // Метод для обновления параметров сигнала
    public void UpdateSignalParameters()
    {
        Debug.Log("UpdateSignalParameters called."); 

        if (float.TryParse(deltaXField.text, out float deltaX) &&
            float.TryParse(distanceXField.text, out float distanceX))
        {
            Debug.Log($"deltaX: {deltaX}, distanceX: {distanceX}"); 

            // Вычисляем период
            float period = distanceX * deltaX;

            // Вычисляем частоту
            float frequency = (period != 0) ? 1f / period : 0f;

            periodField.text = period.ToString("F2");
            frequencyField.text = frequency.ToString("F2");

            Debug.Log($"Period calculated: {period}, Frequency calculated: {frequency}"); 
        }
        else
        {
            periodField.text = "";
            frequencyField.text = "";
            Debug.LogWarning("Invalid input in deltaXField or distanceXField."); 
        }
    }
}
