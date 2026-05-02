using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Player : MonoBehaviour
{
    public float movementSpeed;
    private Rigidbody2D rb;
    private float horizontalInput;
    private int z = 1;
    public Sprite potionSprite;
    public float health = 1;

    
    public List<GameObject> inventoryList;
    public List<int> itemAmounts;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        for(int i=0;i<inventoryList.Count;i++)
        { if (itemAmounts[i]== 0){
                inventoryList[i].GetComponent<Image>().sprite = null;
                inventoryList[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = null;

            } }

        if (Input.GetKeyDown(KeyCode.H))
        {
            for (int i = 0; i < inventoryList.Count; i++)
            {
                if (inventoryList[i].GetComponent<Image>().sprite == potionSprite && itemAmounts[i]>0)
                {
                    health++;
                    itemAmounts[i]--;
                    inventoryList[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = itemAmounts[i].ToString();
                    break;
                }
            }
        }
        print(health);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * movementSpeed, rb.linearVelocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            for (int i = 0; i < inventoryList.Count; i++)
            {
                if (inventoryList[i].GetComponent<Image>().sprite == other.gameObject.GetComponent<SpriteRenderer>().sprite)
                {

                    itemAmounts[i]++;
                    inventoryList[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = itemAmounts[i].ToString();
                    Destroy(other.gameObject);
                    break;
                }
                else if (inventoryList[i].GetComponent<Image>().sprite == null)
                {
                    inventoryList[i].GetComponent<Image>().sprite = other.gameObject.GetComponent<SpriteRenderer>().sprite;
                    itemAmounts[i] = 1;
                    Destroy(other.gameObject);
                    break;
                }
                Debug.Log("Am luat item-ul: " + other.gameObject.name);



            }

            
        }
        }
    }

