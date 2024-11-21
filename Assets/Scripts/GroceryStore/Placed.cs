using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placed : MonoBehaviour
{

    private CanvasRenderer canvasRenderer;

    public void ToggleActive() {
        if(canvasRenderer != null) {
            Debug.Log("made it in placed.cs");
            canvasRenderer.SetAlpha(1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        canvasRenderer = GetComponent<CanvasRenderer>();

        if(canvasRenderer != null) {
            canvasRenderer.SetAlpha(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
