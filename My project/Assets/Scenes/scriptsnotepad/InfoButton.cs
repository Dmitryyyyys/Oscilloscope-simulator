using UnityEngine;

public class InfoButton : MonoBehaviour
{
    public GameObject infoPanel; 
    public GameObject elementsPanel;
    
    public void ToggleInfoPanel()
    {
      
        infoPanel.SetActive(!infoPanel.activeSelf);
    }
    public void ToggleElementsPanel()
    {
      
        elementsPanel.SetActive(!elementsPanel.activeSelf);
    }
}
