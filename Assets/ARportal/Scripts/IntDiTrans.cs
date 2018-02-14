using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class IntDiTrans : MonoBehaviour
{

    public Material[] materials;
	void Start ()
    {
		foreach(var mat in materials)
        {
            mat.SetInt("_StencilTest", (int)CompareFunction.Equal);
        }
	}

    private void OnTriggerStay(Collider other)
    {

        if (other.name != "Main Camera")
            return;
        //Outside the otherworld

        if (transform.position.z> other.transform.position.z)
        {
            Debug.Log("Outside other world");
            foreach (var mat in materials)
            {
                mat.SetInt("_StencilTest", (int)CompareFunction.Equal);
            }

        }

        //inside the otherworld
        else
        {
            Debug.Log("Inside other world");
            foreach(var mat in materials)
            {
                mat.SetInt("_StencilTest", (int)CompareFunction.NotEqual);
            }
        }
    }

    private void OnDestroy()
    {
        foreach(var mat in materials)
        {
            mat.SetInt("_StencilTest", (int)CompareFunction.NotEqual);
        }
    }

    void Update () {
		
	}
}
