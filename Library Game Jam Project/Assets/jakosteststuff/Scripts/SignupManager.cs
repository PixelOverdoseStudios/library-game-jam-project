using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignupManager : MonoBehaviour
{
    public static SignupManager instance;

    [SerializeField] private int teenSignups = 0;
    [SerializeField] private int adultSignups = 0;
    [SerializeField] private int elderlySignups = 0;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncrementTeenSignups()
    {
        teenSignups++;
    }

    public void IncrementAdultSignups()
    {
        adultSignups++;
    }

    public void IncrementElderlySignups()
    {
        elderlySignups++;
    }

    


}
