using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedFamily : MonoBehaviour
{
    // list of sprites/images to cycle through
    public Sprite[] sprites;

    //duration of each sprite in the animation, adjust for speed
    private float duration = 0.03F;

    //refrence the image that will play the animation, make sure the actual image component has none as the source
    public Image img;
    //where we are in sprites array
    int index = 0;
    //advance the animation
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        img.sprite = sprites[0];
    }

    // Update is called once per frame
    void Update()
    {
        //
        if((timer + Time.deltaTime) >= (duration / sprites.Length)) {
            img.sprite = sprites[index];
            //used to loop around when we hit max length
            index = (index + 1) % sprites.Length;
        }
    }
}


