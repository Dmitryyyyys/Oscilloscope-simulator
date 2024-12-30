using UnityEngine;
using UnityEngine.UI;

public class CalculateAmplitude : MonoBehaviour
{
    public InputField deltaYField; 
    public InputField distanceField; 
    public InputField amplitudeField; 

    public void UpdateAmplitude()
    {
        Debug.Log("UpdateAmplitude called."); 

       
        if (float.TryParse(deltaYField.text, out float deltaY) &&
            float.TryParse(distanceField.text, out float distance))
        {
            Debug.Log($"deltaY: {deltaY}, distance: {distance}"); 

            
            float amplitude = (distance * deltaY) / 2f;

            // Записываем результат в поле амплитуды
            amplitudeField.text = amplitude.ToString("F2"); 

            Debug.Log($"Amplitude calculated: {amplitude}"); 
        }
        else
        {
            amplitudeField.text = "";
            Debug.LogWarning("Invalid input in deltaYField or distanceField."); 
        }
    }
}
