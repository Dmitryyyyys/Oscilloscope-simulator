using UnityEngine;

public class OpenNotepad : MonoBehaviour
{
    public GameObject notepadPanel; 
    
    public void ToggleNotepadPanel()
    {
        notepadPanel.SetActive(!notepadPanel.activeSelf);
        
    }
}
