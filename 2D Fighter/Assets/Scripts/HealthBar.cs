using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    private Transform Bar;

   private void Start()
    {
         Bar = transform.Find("Bar");
    }

    public void SetSize(float sizeNormalized)
    {
        Bar.localScale = new Vector3(sizeNormalized, 1f);
    }


    void Update()
    {
        
    }
}
