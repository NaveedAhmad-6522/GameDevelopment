using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;



public class playercontroller : MonoBehaviour
{
    public Rigidbody rb;
    public float movespeed;
    public float rotatespeed;
    public float jumpforce;
    public float resourceCount;
    public Text resourceText;
    

    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        UpdateUI();

    }

  
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            this.transform.Rotate(Vector3.up * rotatespeed * Time.deltaTime);

        }

        if (Input.GetKey(KeyCode.O))
        {
            this.transform.Rotate(Vector3.down * rotatespeed * Time.deltaTime);

        }
        if (Input.GetKeyDown(KeyCode.E))
        {    
            rb.AddForce(Vector3.up * jumpforce * Time.deltaTime, ForceMode.Impulse );

        }
        


      
    }

    void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");
        float verti = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horiz, 0, verti);
        rb.AddRelativeForce(movement * movespeed);
    }

     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("resource"))
        {
            resourceCount++;
            UpdateUI();
            Destroy(other.gameObject);

            
            if (resourceCount >= 10)
            {
                Debug.Log("You Win!");
                Time.timeScale = 0f;
            }
        }
    }
   void UpdateUI()
    {
        resourceText.text = "Resources: " + resourceCount + " / 10";
    }
}