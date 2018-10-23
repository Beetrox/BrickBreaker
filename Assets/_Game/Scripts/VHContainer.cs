using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VHContainer : MonoBehaviour
{
    GameObject container;
    public VariableHandler variableHandler;

	void Start ()
    {

        if (!GameObject.FindGameObjectWithTag("VariableHandler"))
        {
            Instantiate(variableHandler);
        }
    }
}
