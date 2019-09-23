using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pitchfork : MonoBehaviour
{

    private bool taken;
    private GameObject farmer;
    private Rigidbody2D body;

    private bool thrusting;
    private bool ready = true;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        farmer = GameObject.Find("farmer");
    }

    // Update is called once per frame
    void Update()
    {
        if (taken && !thrusting)
        {
            this.transform.position = farmer.transform.position + new Vector3(0.45f, -0.2f, 0);
            rotateToMouse();
            if (Input.GetMouseButtonDown(0) && ready)
            {
                StartCoroutine(thrust());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == farmer)
        {
            taken = true;
        }
    }

    private void rotateToMouse()
    {
        
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, getAngle()));
    }

    private float getAngle()
    {
        Vector3 mousePos = Input.mousePosition;

        Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        return angle - 270;
    }

    IEnumerator thrust()
    {
        if (!thrusting)
        {
            thrusting = true;
            ready = false;

            Vector3 dir = Quaternion.AngleAxis(getAngle() - 90, Vector3.forward) * Vector3.right;
            Debug.Log(dir);
            body.AddForce(dir * 750);
            yield return new WaitForSeconds(0.1f);
            body.velocity = Vector3.zero;
            thrusting = false;

            yield return new WaitForSeconds(0.3f);

            ready = true;
        }
        
    }
}
