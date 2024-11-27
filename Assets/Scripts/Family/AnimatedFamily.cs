using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedFamily : MonoBehaviour
{
    // list of sprites/images to cycle through
    public Sprite[] sprites;

    //duration of each sprite in the animation, adjust for speed
    private float duration = 0.5F;

    //refrence the image that will play the animation, make sure the actual image component has none as the source
    public Image img;
    //where we are in sprites array
    int index = 0;
    //advance the animation
    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayAnimation());
    }

    IEnumerator PlayAnimation() {
        while(true) {
            if(sprites.Length > 0) {
            img.sprite = sprites[index];
            }
            yield return new WaitForSeconds(duration);
            //used to loop around when we hit max length
            index = (index + 1) % sprites.Length;
        }
    }
}
