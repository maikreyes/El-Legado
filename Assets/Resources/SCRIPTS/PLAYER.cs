using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER : MonoBehaviour
{
    public GameObject MapaPrincipal;
    public GameObject MapaSecundario;
    bool canJump;
    float jump;
    float anteriorposy;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKey("left"))
         {
            gameObject.transform.Translate(-10f * Time.deltaTime,0,0);
         }
         if (Input.GetKey("right"))
         {
            gameObject.transform.Translate(10f * Time.deltaTime,0,0);
         }
        if(Input.GetKey("up"))
        {
            Debug.Log(gameObject.transform.position.y == anteriorposy);
            ManageJump();
        }
        if(Input.GetKeyDown("x"))
        {
            Teleport();
        }

       

       
    }

    void FixedUpdate()
    {
        anteriorposy = gameObject.transform.position.y;
    }
    void ManageJump()
    {

        if(gameObject.transform.position.y == anteriorposy){
            canJump = true;
        }
        else 
        {
            canJump = false;
        }

        if(canJump)
        {
            jump += 20f ;
        }

        gameObject.transform.Translate(0, jump * Time.deltaTime, 0);
        if (jump > 0)
        {
            jump -= .005f + (jump/50);
        } 
        else
        {
            jump = 0;
        }
    }

    void Teleport() 
    {
        

        if(MapaPrincipal.activeSelf == false)
        {
            MapaPrincipal.SetActive(true);
            MapaSecundario.SetActive(false);
        }
        else 
        {
            MapaPrincipal.SetActive(false);
            MapaSecundario.SetActive(true);
        }

        
        
    }

}
