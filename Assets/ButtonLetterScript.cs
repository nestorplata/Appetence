using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLetterScript : MonoBehaviour
{
    [SerializeField]
    public Sprite OpenedLetterSprite;
    public Vector3 OpenedLocalPosition;
    public Vector3 OpenedLocalScale;

    Transform OriginalTransform;
    // Start is called before the first frame update
    void Start()
    {
        OriginalTransform = transform;

    }

    // Update is called once per frame
    public void OpenLetter()
    {
        transform.localPosition = OpenedLocalPosition;
        transform.localScale = OpenedLocalScale;
    }

    public void CloseLetter()
    {
        transform.position = OriginalTransform.position;
        transform.localScale = OriginalTransform.localScale;
    }

    
}
