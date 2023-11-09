using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER : MonoBehaviour
{
    public GameObject MapaPrincipal;
    public GameObject MapaSecundario;
    public LayerMask capaSuelo;

    private BoxCollider2D boxCollider;
    bool canJump;
    float jump;
    float jumpSpeed;
    float anteriorposy;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
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
            ManageJump();
        }
        if(Input.GetKeyDown("x"))
        {
            Teleport();
        }

       

       
    }

    bool EstaEnELSuelo()
    {
        RaycastHit2D raycasthit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
        return raycasthit != null; 
    }

    void FixedUpdate()
    {
        anteriorposy = gameObject.transform.position.y;
    }
    void ManageJump()
    {
        if (EstaEnELSuelo())
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }

        if (canJump)
        {
            jump += 1.5f;
            jumpSpeed = 2f;
        }

        float newY = Mathf.Lerp(gameObject.transform.position.y, (gameObject.transform.position.y + jump)*Time.deltaTime, Time.deltaTime * jumpSpeed);
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, newY, gameObject.transform.position.z);

        if (jump > 0)
        {
            jump -= 0.005f + (jump / 50);
        }
        else
        {
            jump = 0;
        }
    }


    void Teleport() 
    {
        
        

        if(MapaPrincipal.activeInHierarchy == false)
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
