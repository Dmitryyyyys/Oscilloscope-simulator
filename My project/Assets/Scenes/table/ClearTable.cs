using UnityEngine;
using UnityEngine.UI;

public class ClearTable : MonoBehaviour
{
    public InputField[] inputFields;

    
    public void ClearAllFields()
    {
        Debug.Log("ClearAllFields called."); 

        
        foreach (InputField inputField in inputFields)
        {
            inputField.text = ""; // Очищаем текстовое поле
        }

        Debug.Log("All fields cleared.");    }
}
