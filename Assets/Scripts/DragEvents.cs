using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragEvents : MonoBehaviour
{
   
    public GameObject Place;
    //public GameObject Tick;
    private bool moving;

    private float startPosX;
    private float startPosY;

    private Vector3 resetPosition;
    private Camera mainCamera;

    private SpriteRenderer spriteRenderer;

    public Color highlightColor = Color.yellow;

    private Color originalColor;

    
    public UnityEvent OnCorrectPlacement;
    public UnityEvent OnIncorrectPlacement;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }

        resetPosition = this.transform.position;
        mainCamera = Camera.main;

        

        if (OnCorrectPlacement == null)
            OnCorrectPlacement = new UnityEvent();
        if (OnIncorrectPlacement == null)
            OnIncorrectPlacement = new UnityEvent();
    }

    void Update()
    {
        if (moving)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = mainCamera.ScreenToWorldPoint(mousePos);

            this.transform.position = new Vector3(mousePos.x - startPosX, mousePos.y - startPosY, this.transform.position.z);
        }
    }


    private void OnMouseDown()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.sortingOrder = 10;
            spriteRenderer.color = highlightColor;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos = mainCamera.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - this.transform.position.x;
            startPosY = mousePos.y - this.transform.position.y;
            moving = true;

           
        }
    }

    private void OnMouseUp()
    {
        moving = false;

        if (spriteRenderer != null)
        {
            spriteRenderer.sortingOrder = 1;
            spriteRenderer.color = originalColor;
        }

        

        if (Place == null)
        {
            this.transform.position = resetPosition;

            
            OnIncorrectPlacement.Invoke();
            return;
        }

        if (Vector3.Distance(this.transform.position, Place.transform.position) <= 2f)
        {
            this.transform.position = Place.transform.position;

            // Invoke the correct placement event
            OnCorrectPlacement.Invoke();
        }
        else
        {
            this.transform.position = resetPosition;

            // Invoke the incorrect placement event
            OnIncorrectPlacement.Invoke();
        }
    }
}


