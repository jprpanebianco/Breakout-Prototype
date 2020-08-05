using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour
{
    public bool hittingPaddle = false;

    // Update is called once per frame
    void Update()
    {
        Vector3 paddlePos = new Vector3(-8f, 0f, 0f);
        float mousePosInBlocks = ((Input.mousePosition.y / Screen.height) * 11.25f) - 5f;
        paddlePos.y = Mathf.Clamp(mousePosInBlocks, -4f, 4f);
        transform.position = paddlePos;
    }

    void OnCollisionEnter2D(Collision2D colInfo)
    { 
        foreach (ContactPoint2D contact in colInfo.contacts)
        {
            if (colInfo.collider.tag == "Ball")
            {
                hittingPaddle = true;
                Vector2 hitPoint = contact.point;
                float calc = Mathf.Clamp(((hitPoint.y - transform.position.y) * 0.5f), -0.5f, 0.5f); 
                Rigidbody2D ballBody = contact.collider.GetComponent<Rigidbody2D>();
                ballBody.velocity *= 0;
                ballBody.AddForce(new Vector2(50f * (1 - Mathf.Abs(calc)), 50f * calc));
            }
            if (colInfo.collider.tag == "Collectible")
            {
                Destroy(colInfo.gameObject);
            }
        }
    }

    void OnCollisionExit2D(Collision2D colInfo)
    {
        if (colInfo.collider.tag == "Ball")
        {
            hittingPaddle = false;
        }
    }
}
