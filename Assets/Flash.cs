using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    private CanvasGroup canvasGroup;

    [SerializeField]
    private float flashSpeed = 0.1f;

    // Start is called before the first frame update
    void Awake()
    {
      canvasGroup = GetComponent<CanvasGroup>();
        StartCoroutine(FlashScreen());
    }
   private IEnumerator FlashScreen()
    {
        while(true)
        {
            canvasGroup.alpha = 1f;
            yield return new WaitForSeconds(flashSpeed);
            canvasGroup.alpha = 0f;
            yield return new WaitForSeconds(flashSpeed);
        }
    }
}
