using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeActionMap : MonoBehaviour
{
    [SerializeField] private PlayerGroundController playerGroundController;
    [SerializeField] private ChangeActionMap actionMapForest;
    [SerializeField] private PlayerSpaceController playerSpaceController;
    [SerializeField] private PlanetaryGravityBody planetaryGravityBody;
    [SerializeField] private List<GravityAttractor> gravityPlanet = new List<GravityAttractor>();
    [SerializeField] private Orbit planetOrbit;
    public int planetNumber;
    private InputManager inputManager;
    public bool inAttraction = false;
    public bool InAttration => inAttraction;

    private void Awake()
    {
        inputManager = InputManager.GetInstance();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(planetNumber == 1)
            {
                planetaryGravityBody.attractor = gravityPlanet[0];
            }
            else if(planetNumber == 2)
            {
                planetaryGravityBody.attractor = gravityPlanet[1];
            }

            planetOrbit.enabled = false;
            inAttraction = true;
            

            playerSpaceController.enabled = false;
            playerGroundController.enabled = true;
        }
        if(other.CompareTag("Ship"))
        {
            if(planetNumber == 1)
            {
                planetaryGravityBody.attractor = gravityPlanet[0];
            }
            else if(planetNumber == 2)
            {
                planetaryGravityBody.attractor = gravityPlanet[1];
            }

            planetOrbit.enabled = false;
            inAttraction = true;

            playerSpaceController.enabled = false;
            playerGroundController.enabled = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            planetOrbit.enabled = true;
            inAttraction = false;

            playerSpaceController.enabled = true;
            playerGroundController.enabled = false; 
        }
        if(other.CompareTag("Ship"))
        {
            planetOrbit.enabled = true;
            inAttraction = false;

            playerSpaceController.enabled = true;
            playerGroundController.enabled = false; 
        }

        Debug.Log("Exit" + inAttraction);
          
    }



}
