using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powScript : MonoBehaviour
{
    public GameObject[] powWalls;
    private int state = -1;
    private bool init = false;
    private bool finish;

    // Update is called once per frame
    void Update()
    {
        if (init)
        {
            finish = true;
            for(int i=0; i<powWalls.Length && finish; i++)
            {
                finish = powWalls[i].GetComponent<PowActivation>().isFinish();
            }
            if (finish)
            {
                init = false;
                state *= -1;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!init)
        {
            GetComponent<Animator>().SetTrigger("animar");
            init = true;
            for (int i = 0; i < powWalls.Length; i++)
            {
                powWalls[i].GetComponent<PowActivation>().cambiarBloques(state);
            }
        } 
    }

    public bool isInit()
    {
        return init;
    }
}
