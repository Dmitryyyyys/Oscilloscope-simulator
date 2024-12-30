using UnityEngine;

public class MoveToTarget : MonoBehaviour
{
    public Transform targetObject1;
    public Transform targetObject2;
    public Transform targetObject3;
    public Transform targetObject4;
    public Transform targetObject5;

    public GameObject infoPanel1; 
    public GameObject infoPanel2; 
    public GameObject infoPanel3; 
    public GameObject infoPanel4; 
    public GameObject infoPanel5; 
    public Color highlightColor = Color.yellow; 
    public float moveSpeed = 5f; 
    public float distanceFromTarget = 5f; 
    private Camera mainCamera;
    private Transform currentTarget;
    private Renderer currentTargetRenderer;
    private Color originalColor;

    void Start()
    {
        mainCamera = Camera.main;
        HideAllPanels(); 
    }

    public void MoveCameraToTarget(Transform target, GameObject infoPanel)
    {
        HideAllPanels(); 

        if (target != null)
        {
            if (currentTargetRenderer != null)
            {
                currentTargetRenderer.material.color = originalColor;
            }

            currentTarget = target;
            currentTargetRenderer = target.GetComponent<Renderer>();

            if (currentTargetRenderer != null)
            {
                originalColor = currentTargetRenderer.material.color;
                currentTargetRenderer.material.color = highlightColor;
            }

            Vector3 direction = (mainCamera.transform.position - target.position).normalized;
            Vector3 targetPosition = target.position + direction * distanceFromTarget;

            StartCoroutine(MoveToPosition(targetPosition));

            if (infoPanel != null)
            {
                infoPanel.SetActive(true);
            }
        }
        else
        {
            Debug.LogError("Целевой объект не назначен!");
        }
    }

    private System.Collections.IEnumerator MoveToPosition(Vector3 targetPosition)
    {
        while (Vector3.Distance(mainCamera.transform.position, targetPosition) > 0.1f)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private void HideAllPanels()
    {
        if (infoPanel1 != null) infoPanel1.SetActive(false);
        if (infoPanel2 != null) infoPanel2.SetActive(false);
        if (infoPanel3 != null) infoPanel3.SetActive(false);
        if (infoPanel4 != null) infoPanel4.SetActive(false);
        if (infoPanel5 != null) infoPanel5.SetActive(false);
    }

    public void MoveToObject1() => MoveCameraToTarget(targetObject1, infoPanel1);
    public void MoveToObject2() => MoveCameraToTarget(targetObject2, infoPanel2);
    public void MoveToObject3() => MoveCameraToTarget(targetObject3, infoPanel3);
    public void MoveToObject4() => MoveCameraToTarget(targetObject4, infoPanel4);
    public void MoveToObject5() => MoveCameraToTarget(targetObject5, infoPanel5);
}
