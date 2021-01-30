using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonBeamSpell : Spell
{

    protected override float GetManaCost(float power)
    {
        return power;
    }

    protected override void Cast(SpellCaster caster, float power)
    {
        //aim at area
        //spawn temp cylinder
            //confirm spawn damage area for time
            //cancel temp vanished



    }
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




}
