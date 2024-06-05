using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RadioactiveShit
{
    public struct Resources
    {
        public static ResourceObject[] ResourceObjects;

        public static void LoadResources()
        {
            ResourceObjects = new ResourceObject[]
            {
                #region Radioactive Stuff
                new ResourceObject
                {
                    gameObject = ModAPI.FindSpawnable("Particle Projector").Prefab.transform.GetChild(0).gameObject,
                    ID = "Radioactive Explosion Debris",
                    Action = (Object) =>
                    {
                        ParticleSystem particles = Object.GetComponent<ParticleSystem>();
                        particles.gravityModifier = 0f;
                        particles.emissionRate = 5f;
                        particles.startSpeed = 0f;
                        particles.startLifetime = 7f;
                        particles.startSize = 0.4f;
                        particles.startColor = new Color(0f, 1f, 0f, 0.4f);
                        particles.playbackSpeed = 3;
                        particles.loop = true;
                        particles.Play();
                        ParticleSystem.MainModule main = particles.main;
                        main.duration = 21f;
                        main.scalingMode = ParticleSystemScalingMode.Hierarchy;
                        float v1 = UnityEngine.Random.Range(-25f, 25f);
                        float v2 = UnityEngine.Random.Range(-25f, 25f);
                        Object.AddComponent<Rigidbody2D>().velocity = new Vector2(v1, v2);
                        Object.layer = 9;
                        Object.AddComponent<DebrisComponent>();
                        PhysicsMaterial2D mat = new PhysicsMaterial2D();
                        mat.bounciness = 0.2f;
                        Object.AddComponent<BoxCollider2D>().sharedMaterial = mat;
                        Object.GetComponent<BoxCollider2D>().size = new Vector2(0.1f, 0.1f);
                        Object.GetComponent<BoxCollider2D>().isTrigger = true;
                        Object.AddComponent<RadioactiveDebris>();
                    }
                },
                new ResourceObject
                {
                    gameObject = ModAPI.FindSpawnable("Particle Projector").Prefab.transform.GetChild(0).gameObject,
                    ID = "Radioactive Explosion Cloud Nuke",
                    Action = (Object) =>
                    {
                        Object.layer = 9;
                        Object.AddComponent<DebrisComponent>();
                        ParticleSystem particles = Object.GetComponent<ParticleSystem>();
                        ParticleSystemRenderer renderer = Object.GetComponent<ParticleSystemRenderer>();
                        GameObject.Destroy(particles);
                        GameObject.Destroy(renderer);
                        Object.AddComponent<RadioactiveShit.RadioactiveCloudNuke>();
                        GameObject Area = new GameObject("Area Indicator");
                        Area.transform.SetParent(Object.transform, false);
                        Area.AddComponent<SpriteRenderer>();
                        Area.transform.localScale = Vector3.one * 60000;
                        Area.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
                        Area.layer = 16;
                        Area.AddComponent<ExistInDetailView>();
                    }
                },
                new ResourceObject
                {
                    gameObject = ModAPI.FindSpawnable("Particle Projector").Prefab.transform.GetChild(0).gameObject,
                    ID = "Radioactive Explosion Cloud",
                    Action = (Object) =>
                    {
                        Object.layer = 9;
                        Object.AddComponent<DebrisComponent>();
                        ParticleSystem particles = Object.GetComponent<ParticleSystem>();
                        ParticleSystemRenderer renderer = Object.GetComponent<ParticleSystemRenderer>();
                        GameObject.Destroy(particles);
                        GameObject.Destroy(renderer);
                        Object.AddComponent<RadioactiveShit.RadioactiveCloud>();
                        GameObject Area = new GameObject("Area Indicator");
                        Area.transform.SetParent(Object.transform, false);
                        Area.AddComponent<SpriteRenderer>();
                        Area.transform.localScale = Vector3.one * 26;
                        Area.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
                        Area.layer = 16;
                        Area.AddComponent<ExistInDetailView>();
                    }
                },
                #endregion
            };
        }
        public static GameObject SpawnResources(Vector3 position, string ID, bool shouldGetParented = false, Transform parent = null)
        {
            GameObject gameObject = null;
            for (int i = 0; i < ResourceObjects.Length; i++)
            {
                if (ResourceObjects[i].ID == ID)
                {
                    gameObject = UnityEngine.Object.Instantiate<GameObject>(ResourceObjects[i].gameObject, position, Quaternion.identity);

                    gameObject.name = ResourceObjects[i].ID;
                    if (shouldGetParented)
                        gameObject.transform.SetParent(parent);
                    ResourceObjects[i].Action(gameObject);
                    break;
                }
            }
            return gameObject;
        }
    }
    public struct ResourceObject
    {
        public GameObject gameObject;
        public string ID;
        public Action<GameObject> Action;
    }
}