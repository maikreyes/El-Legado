using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAYER : MonoBehaviour
{
    public GameObject MapaPrincipal;
    public GameObject MapaSecundario;
    public LayerMask capaSuelo;
    public float velocidad;
    public float fuerzaSalto;

    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;
    bool canJump;
    float jump;
    float jumpSpeed;
    float anteriorposy;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("x"))
        {
            Teleport();
        }

        ProcesarMovimiento();

        ProcesarSalto();
    }

    void ProcesarMovimiento()
    {
        float inputMovimiento = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(inputMovimiento * velocidad, rigidbody.velocity.y);
    }

    void ProcesarSalto()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && EstaEnELSuelo())
        {
            rigidbody.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }

    bool EstaEnELSuelo()
    {
        RaycastHit2D raycasthit = Physics2D.BoxCast(boxCollider.bounds.center, new Vector2(boxCollider.bounds.size.x, boxCollider.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
        return raycasthit.collider != null; 
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
