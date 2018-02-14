/*
 * This Class handles flipping the global _StencilTest property when the device
 * moves throught the portal, from any direction
 */



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Portal : MonoBehaviour
{

    public Transform device;
    public Material[] materials;


    //bool for checking if the device is not in the same direction as it was
    bool wasInFront;
    //bool for knowing that on the next change of state, what to set the stencil test
    bool inOtherWorld;

    

    void Start()
    {
        //start outside other world
        SetMaterials(false);
    }

    void SetMaterials(bool fullRender)
    {
        var stencilTest = fullRender ? CompareFunction.NotEqual : CompareFunction.Equal;
        foreach (var mat in materials)
        {
            mat.SetInt("_StencilTest", (int)stencilTest);
        }
    }

    bool GetIsInFront()
    {

        Vector3 pos = transform.InverseTransformPoint(device.position);
        return pos.z >= 0 ? true : false;
    }


    //This technique registeres if the device has hit the portal, flipping the bool

    void OnTriggerEnter(Collider other)
    {
        if (other.transform != device)
            return;
        //Important to do this for if the user re-enters the portal from the same side
        wasInFront = GetIsInFront();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.transform != device)
            return;
        bool isInFront = GetIsInFront();
        if ((isInFront && !wasInFront) || (wasInFront && !isInFront))
        {
            inOtherWorld = !inOtherWorld;
            SetMaterials(inOtherWorld);
        }

        wasInFront = isInFront;

    }


  

    void OnDestroy()
    {
        //ensure geometry renders in the editor
        SetMaterials(true);
    }


    void Update()
    {
    }
}