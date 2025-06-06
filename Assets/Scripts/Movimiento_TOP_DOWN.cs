using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_TOP_DOWN : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private Vector2 direccion;
    [SerializeField] private float initialEnergy = 10f;


    private float currentEnergy;
    private Rigidbody2D rb2D;

    private float movimientoX;
    private float movimientoY;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        currentEnergy = initialEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        direccion = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    private void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + direccion * velocidadMovimiento * Time.fixedDeltaTime);
    }
}
