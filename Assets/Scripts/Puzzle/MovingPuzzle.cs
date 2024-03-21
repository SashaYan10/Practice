using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPuzzle : MonoBehaviour
{
    bool move;
    Vector2 mousePos;
    float startPosX;
    float startPosY;
    public GameObject form;
    bool finish;
    bool inCorrectPosition; // New boolean variable to track correct position

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            move = true;
            mousePos = Input.mousePosition;

            startPosX = mousePos.x - this.transform.localPosition.x;
            startPosY = mousePos.y - this.transform.localPosition.y;

            // Check if puzzle piece is in the correct position
            inCorrectPosition = Mathf.Abs(this.transform.localPosition.x - form.transform.localPosition.x) <= 5f &&
                                Mathf.Abs(this.transform.localPosition.y - form.transform.localPosition.y) <= 5f;
        }
    }

    void OnMouseUp()
    {
        move = false;

        // Only trigger victory if the puzzle piece was moved and is now in the correct position
        if (!inCorrectPosition && finish == false)
        {
            if (Mathf.Abs(this.transform.localPosition.x - form.transform.localPosition.x) <= 5f &&
                Mathf.Abs(this.transform.localPosition.y - form.transform.localPosition.y) <= 5f)
            {
                this.transform.localPosition = new Vector2(form.transform.localPosition.x, form.transform.localPosition.y);
                finish = true;
                WinScript.AddElement();
            }
        }
    }

    void Update()
    {
        if (move == true && finish == false)
        {
            mousePos = Input.mousePosition;

            this.gameObject.transform.localPosition = new Vector2(mousePos.x - startPosX, mousePos.y - startPosY);
        }
    }
}
