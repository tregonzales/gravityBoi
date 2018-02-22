using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl2 : MonoBehaviour
{

    public GameObject player;       //Public variable to store a reference to the player game object

    public float boxHeight;         //Public variable for height of camera box
    public float boxWidth;          //Public variable for width of camera box
    public float zoomSize;         //how large to start the camera
    Vector3 gravBoiPoint;

    public float xCenter;
    public float yCenter;

    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    private bool startUpdate;

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        gravBoiPoint = new Vector3(player.transform.position.x, player.transform.position.y, -10);

        startUpdate = false;
        StartCoroutine(zoomIn());

    }

    // LateUpdate is called after Update each frame
    void Update()
    {

        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        if (player != null && boxWidth < Mathf.Abs(transform.position.x - player.transform.position.x) && startUpdate)
        {
            if (player.transform.position.x > transform.position.x)
            {
                transform.position = new Vector3(transform.position.x + Mathf.Abs(transform.position.x - player.transform.position.x) - boxWidth, transform.position.y, -10);
            }
            else
            {
                transform.position = new Vector3(transform.position.x - Mathf.Abs(transform.position.x - player.transform.position.x) + boxWidth, transform.position.y, -10);
            }
        }

        if (player != null && boxHeight < Mathf.Abs(transform.position.y - player.transform.position.y) && startUpdate)
        {
            if (player.transform.position.y > transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + Mathf.Abs(transform.position.y - player.transform.position.y) - boxHeight, -10);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - Mathf.Abs(transform.position.y - player.transform.position.y) + boxHeight, -10);
            }
        }


    }

    IEnumerator zoomIn()
    {
        Camera.main.orthographicSize = zoomSize;
        Camera.main.transform.position = new Vector3(xCenter, yCenter, -10);
        yield return new WaitForSeconds(3f);
        while (zoomSize >= 10)
        {
            Camera.main.transform.position = Vector3.MoveTowards(transform.position, gravBoiPoint, .5f);
            Camera.main.orthographicSize = zoomSize;
            yield return new WaitForSeconds(.01f);
            zoomSize -= .25f;
        }
        while(Camera.main.transform.position != gravBoiPoint)
        {
            Camera.main.transform.position = Vector3.MoveTowards(transform.position, gravBoiPoint, .5f);
            yield return new WaitForSeconds(.01f);
        }
        startUpdate = true;

    }

}
