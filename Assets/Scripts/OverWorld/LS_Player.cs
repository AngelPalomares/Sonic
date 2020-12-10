using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LS_Player : MonoBehaviour
{
    public MapPoint currentPoint;

    public float movespeed = 10f;

    private bool LevelLoading;

    public LSManager Manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, currentPoint.transform.position, movespeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentPoint.transform.position) < .1f && !LevelLoading)
        {


            if (Input.GetAxisRaw("Horizontal") > .5f)
            {
                if (currentPoint.right != null)
                {
                    SetNextPoint(currentPoint.right);
                }
            }

            if (Input.GetAxisRaw("Horizontal") < -.5f)
            {
                if (currentPoint.left != null)
                {
                    SetNextPoint(currentPoint.left);
                }
            }

            if (Input.GetAxisRaw("Vertical") > .5f)
            {
                if (currentPoint.up != null)
                {
                    SetNextPoint(currentPoint.up);
                }
            }

            if (Input.GetAxisRaw("Vertical") < -.5f)
            {
                if (currentPoint.down != null)
                {
                    SetNextPoint(currentPoint.down);
                }
            }

            if(currentPoint.islevel && currentPoint.leveltoload != ""  && !currentPoint.islocked)
            {
                LevelSelectUiCOntroller.instance.ShowInformation(currentPoint);
                if(Input.GetButtonDown("Jump"))
                {
                    LevelLoading = true;
                    Manager.LoadLevel();
                }
            }
        }
    }

    public void SetNextPoint(MapPoint nextpoint)
    {
        currentPoint = nextpoint;
        LevelSelectUiCOntroller.instance.HideInformation();
    }
}
