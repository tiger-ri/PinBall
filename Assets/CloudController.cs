using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{

    //ç≈è¨ÉTÉCÉY
    private float minimum = 1.0f;
    //ägëÂèkè¨ÉXÉsÅ[Éh
    private float magSpeed = 10.0f;
    //ägëÂó¶
    private float magnification = 0.07f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //â_ÇägëÂèkè¨
        this.transform.localScale = new Vector3(this.minimum + Mathf.Sin(Time.time * this.magSpeed) * this.magnification, this.transform.localScale.y, this.minimum + Mathf.Sin(Time.time * this.magSpeed) * this.magnification);
    }
}
