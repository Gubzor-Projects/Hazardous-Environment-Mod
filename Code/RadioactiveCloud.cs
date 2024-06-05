using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using RadioactiveShit;
namespace RadioactiveShit
{
    public class RadioactiveCloud : MonoBehaviour
    {
        float stuff;
        float stuff2;
        void Update()
        {
            stuff += Time.fixedDeltaTime;
            stuff2 += Time.fixedDeltaTime;
            if (stuff >= 1)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 15);
                foreach (Collider2D collider in colliders)
                {
                    if (UnityEngine.Random.value >= 0.5f) collider.transform.SendMessage("OnEMPHit", SendMessageOptions.RequireReceiver);
                }
                stuff = 0;
            }
            if (stuff2 >= 1f)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 15);
                foreach (Collider2D collider in colliders)
                {
                    LimbBehaviour limb = collider.GetComponent<LimbBehaviour>();
                    if (!collider.transform.root.GetComponent<Hazmat_OxygenTank_Functionality>()) limb.Person.OxygenLevel = 0;
                    if (!collider.transform.root.GetComponent<Hazmat_Suit_Functionality>() && !collider.transform.root.GetComponent<Hazmat_Suit2_Functionality>())
                    {
                        if (limb)
                        {
                            if (UnityEngine.Random.value >= 0.5f) collider.transform.SendMessage("Damage", 50f, SendMessageOptions.RequireReceiver);
                            limb.SkinMaterialHandler.RottenProgress += 0.011f;
                            limb.SkinMaterialHandler.AcidProgress += 0.011f;
                            if (UnityEngine.Random.value >= 0.99f) limb.Slice();
                        }
                    }
                    else if (collider.transform.root.GetComponent<Hazmat_Suit_Functionality>())
                    {
                        if (limb)
                        {
                            limb.SkinMaterialHandler.RottenProgress += 0.001f;
                            limb.SkinMaterialHandler.AcidProgress += 0.001f;
                        }
                    }
                    else if (collider.transform.root.GetComponent<Hazmat_Suit2_Functionality>())
                    {
                    }
                }
                stuff2 = 0;
            }
            Destroy(gameObject, 60);
        }
    }
}