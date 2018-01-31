﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickPoi : MonoBehaviour
{

    public float force = 5;
    
    public GameObject uncMenu;
    public GameObject historyMenu;
    public GameObject eescMenu;
    public GameObject ecologyMenu;
    public GameObject compsciMenu;
    public GameObject anthroMenu;
    public GameObject resMenu;

    
    Dictionary<string, GameObject> PoiDict = new Dictionary<string, GameObject>();
    

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {

                    Rigidbody rb;


                    if (rb = hit.transform.GetComponent<Rigidbody>())

                    {
                        string name = hit.transform.gameObject.name;
                        //PrintName(hit.transform.gameObject);
                        LaunchIntoAir(rb);
                        print(name);
                        //AR POIs
                        try
                        {
                            //open scene AR scene if available
                            SceneManager.LoadScene(name, LoadSceneMode.Single);
                        }catch(System.Exception )
                        {

                        }

                        //Non AR POIs
                        //add all points to a dictionary for accessing
                        PoiDict.Add("unc", uncMenu);
                        PoiDict.Add("history", historyMenu);
                        PoiDict.Add("eesc", eescMenu);
                        PoiDict.Add("ecology", ecologyMenu);
                        PoiDict.Add("compsci", compsciMenu);
                        PoiDict.Add("anthro", anthroMenu);
                        PoiDict.Add("res", resMenu);

                        //set clicked menu active
                        PoiDict[name].SetActive(true);

                        /*
                        if (name == "unc")
                        {
                            uncMenu.SetActive(true);
                        }
                        
                        if (name == "history")
                        {
                            historyMenu.SetActive(true);

                        }
                        if (name == "eesc")
                        {
                            eescMenu.SetActive(true);

                        }
                        if (name == "ecology")
                        {
                            ecologyMenu.SetActive(true);

                        }
                        if (name == "compsci")
                        {
                            compsciMenu.SetActive(true);

                        }
                        if (name == "anthro")
                        {
                            anthroMenu.SetActive(true);

                        }
                        if (name == "res")
                        {
                            resMenu.SetActive(true);

                        }
                        */
                    }
                }
            }
        }
    }

    private void PrintName(GameObject go)
    {
        print(go.name);
    }

    private void LaunchIntoAir(Rigidbody rig)
    {

        rig.AddForce(rig.transform.up * force, ForceMode.Impulse);


    }

}
