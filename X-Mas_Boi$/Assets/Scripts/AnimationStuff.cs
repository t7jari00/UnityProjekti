using System;
using System.Threading.Tasks;
using UnityEngine;

public class AnimationStuff : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetInteger("conditionToWalk", 1);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetInteger("conditionToSprint", 1);
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                anim.SetInteger("conditionToSprint", 0);
            }

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetInteger("conditionToWalk", 0);
            anim.SetInteger("conditionToSprint", 0);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetInteger("conditionToJump", 1);
            Asd();
        }

    }

    private async void Asd()
    {
        await Task.Delay(1000);

        anim.SetInteger("conditionToJump", 0);
    }
}
