using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragNDrop : MonoBehaviour
{
    // Start is called before the first frame update
    public string fruitNames;
    private bool isDragging;
    public GameObject slotPos;
    public GameObject objDrag;
    private Placed placed;
    private GameObject obj;
    private bool locked;
    Vector2 originalPos, offset, CurrSlotPos;

    Collider2D collider;

/*    public AudioSource lettuceGrab, canGrab, onionGrab, cabbageGrab, jarGrab;

    public AudioSource lettuceDrop, canDrop, onionDrop, cabbageDrop, jarDrop;

    public AudioSource trashCanOpen, trashCanClose;*/

    public AudioClip clickDown;
    public AudioClip clickUp;

    private AudioSource sfx;

    public AudioSource correct, wrong;

    private TMP_Text currency;

    void Awake()
    {
        currency = GameObject.Find("Money").GetComponent<TMP_Text>();
        correct = GameObject.Find("Correct").GetComponent<AudioSource>();
        wrong = GameObject.Find("Wrong").GetComponent<AudioSource>();

        if(fruitNames != "trash") {
            obj = GameObject.FindWithTag(fruitNames);
            if(obj != null) {
                placed = obj.GetComponent<Placed>();
            } else {
                Debug.Log("obj is null");
            }
        }
    }

    void Start()
    {
        originalPos = transform.position;
        sfx = GetComponent<AudioSource>();
    }

    public void OnMouseDown()
    {
        isDragging = true;
        offset = GetMousePos() - (Vector2)transform.position;
        if(fruitNames != "trash") {
            sfx.PlayOneShot(clickDown);
        }
    }

    public void OnMouseUp()
    {
        isDragging = false;

        if (collider.gameObject.TryGetComponent(out SlotScript fruitSlot) && fruitSlot.fruitNames == fruitNames)
        {
            if(fruitNames != "trash") {
                sfx.PlayOneShot(clickUp);
                CurrSlotPos = slotPos.transform.position;
                CurrencySystem.Instance.AddCurrency(40);
                Debug.Log("Plus 40");
                if(placed != null) {
                    placed.ToggleActive();
                } else {
                    Debug.LogError("placed is null");
                }
                correct.Play();

                objDrag.transform.position = CurrSlotPos;
                Spawner.Instance.trash.closeTrash();
                Destroy(this);
                Destroy(GetComponent<Rigidbody2D>());

                Destroy(gameObject);
            } else if (fruitNames == "trash") {
                objDrag.transform.position = CurrSlotPos;
                Spawner.Instance.trash.closeTrash();
                Destroy(this);
                Destroy(GetComponent<Rigidbody2D>());

                Destroy(gameObject);
                //CurrencySystem.Instance.AddCurrency(40);
                //Debug.Log("Plus 40");
                correct.Play();
            }
        }
        else
        {  
            CurrencySystem.Instance.AddCurrency(-60);
            Debug.Log("Minus 60");
            wrong.Play();    
            StartCoroutine(check_fruit());
        }
        Spawner.Instance.change_fruit();
    }

    IEnumerator check_fruit()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<Rigidbody2D>().gravityScale = 1;
        Destroy(gameObject, 2f);
    }

    public void Update()
    {
        currency.text = CurrencySystem.Instance.GetCurrency().ToString();
        if (!isDragging) return;

        var mousePosition = GetMousePos();
        transform.position = mousePosition - offset;
    }

    Vector2 GetMousePos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        collider = collision;
    }

    /** commenting this out makes the hitboxes more reliable when dropping in the correct slot, still off though gonna leave here for now though **/
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out SlotScript fruitSlot) && CurrSlotPos == new Vector2(fruitSlot.transform.position.x, fruitSlot.transform.position.y))
        {
            CurrSlotPos = Vector2.zero;
        }
    }
}
