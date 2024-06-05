using System;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UmmAPI;

namespace UmmAPI
{
    public static class UmAPI
    {
        #region Jednostki
        public const float ton = 25f;
        public const float kg = 0.025f;
        #endregion

        public static float RandomFloat(float min, float max)
        {
            float f = UnityEngine.Random.Range(min, max);
            return f;
        }
        public static int RandomInt(float min, float max)
        {
            int i = (int)UnityEngine.Random.Range(min, max);
            return i;
        }

        #region Disable Collision
        public static void DisableCollision(this GameObject go)
        {
            Utils.SetLayer(go, 9, true);
        }
        #endregion
        #region Set Physical Mass (in kilograms)
        public static void SetPhysicalMass(this PhysicalBehaviour phys, float mass)
        {
            phys.InitialMass = mass * kg;
            phys.TrueInitialMass = mass * kg;
            phys.rigidbody.mass = mass * kg;
        }
        #endregion
        #region Create Audio Source
        public static AudioSource CreateAudioSource(GameObject g, float maxd, AudioClip clip, bool loop = false)
        {
            var audio = g.AddComponent<AudioSource>();
            g.AddComponent<AudioSourceTimeScaleBehaviour>();
            audio.dopplerLevel = 0f;
            audio.playOnAwake = false;
            audio.rolloffMode = AudioRolloffMode.Linear;
            audio.minDistance = 1f;
            audio.maxDistance = maxd;
            audio.spatialBlend = 1f;
            audio.volume = 2f;
            audio.loop = loop;
            audio.clip = clip;

            return audio;
        }
        #endregion

        #region Create Mask Object
        public static GameObject CreateMaskObject(this GameObject parent, Sprite sprite, Color maskColor, float maskIntensity, Color glowColor, float glowRadius, float glowIntensity, Vector3 offset, bool onTop = false)
        {
            var glowObject = new GameObject("Glow");
            glowObject.transform.SetParent(parent.transform);
            glowObject.transform.localRotation = Quaternion.identity;
            glowObject.transform.localPosition = Vector3.zero;
            glowObject.transform.localScale = Vector3.one;
            var glowObjectRenderer = glowObject.AddComponent<SpriteRenderer>();
            if (!onTop)
            {
                glowObjectRenderer.sortingLayerName = parent.GetComponent<SpriteRenderer>().sortingLayerName;
                glowObjectRenderer.sortingOrder = parent.GetComponent<SpriteRenderer>().sortingOrder + 1;
            }
            else
            {
                glowObjectRenderer.sortingLayerName = "Top";
            }
            glowObjectRenderer.sprite = sprite;
            glowObjectRenderer.material = ModAPI.FindMaterial("VeryBright");
            glowObjectRenderer.color = new Color(maskColor.r, maskColor.g, maskColor.b, maskIntensity);

            var glow = ModAPI.CreateLight(parent.transform, glowColor, 5, 1);
            glow.Color = glowColor;
            glow.Brightness = glowIntensity;
            glow.Radius = glowRadius;
            glow.transform.localPosition = new Vector3(0, 0, 0) + offset;

            return glowObject;
        }
        #endregion
        #region Create Detail object
        public static GameObject CreateDetailObject(this GameObject parent, Sprite sprite, Vector3 offset, bool retainOriginalSorting = true, int sortingOrder = 0, string sortingLayerName = "Default")
        {
            var gameObject = new GameObject("Detail");
            gameObject.transform.SetParent(parent.transform);
            gameObject.transform.localRotation = Quaternion.identity;
            gameObject.transform.localPosition = offset;
            gameObject.transform.localScale = Vector3.one;
            var gameObjectRenderer = gameObject.AddComponent<SpriteRenderer>();
            gameObjectRenderer.sprite = sprite;
            if (retainOriginalSorting)
            {
                gameObjectRenderer.sortingLayerName = parent.GetComponent<SpriteRenderer>().sortingLayerName;
                gameObjectRenderer.sortingOrder = parent.GetComponent<SpriteRenderer>().sortingOrder + 1;
            }
            else
            {
                gameObjectRenderer.sortingLayerName = sortingLayerName;
                gameObjectRenderer.sortingOrder = sortingOrder;
            }
            return gameObject;
        }
        #endregion
        #region Create Rigidbody Object
        public static GameObject CreateRigidbodyObject(this Transform parent, string name, Sprite sprite, Vector3 offset, bool shouldHaveDisabledCollision)
        {
            GameObject rbobject = ModAPI.CreatePhysicalObject(name, sprite);

            if (shouldHaveDisabledCollision)
            {
                rbobject.layer = LayerMask.NameToLayer("Debris");
            }

            rbobject.transform.SetParent(parent);
            rbobject.transform.localRotation = Quaternion.identity;
            rbobject.transform.position = parent.position;
            rbobject.transform.localPosition = Vector3.zero + offset;
            rbobject.transform.localScale = (parent.localScale.x > 0f) ? new Vector3(1f, 1f) : new Vector3(1f, 1f);
            return rbobject;
        }
        #endregion
        #region Instantiate Spawnable Asset
        public static void InstantiateSpawnableAsset(SpawnableAsset spawnableAsset, Transform parent, Vector3 offset, bool shouldBeParentOfBaseObject = false)
        {
            GameObject assetItem = UnityEngine.Object.Instantiate(spawnableAsset.Prefab, parent.position + offset, parent.rotation);
            assetItem.transform.localScale = parent.localScale;
            if (shouldBeParentOfBaseObject)
            {
                assetItem.transform.SetParent(parent);
                assetItem.transform.localPosition = Vector3.zero + offset;
                assetItem.transform.localRotation = Quaternion.identity;
                assetItem.transform.localScale = Vector3.one;
            }
        }
        #endregion
        #region Create Debris Particles
        public static void CreateDebrisParticles(Transform parent, Color[] colors, Sprite[] sprites, Vector3 pos, int minAmount = 20, int maxAmount = 25, float size = 0.3f, float speed = 17f)
        {
            int ma = UnityEngine.Random.Range(minAmount, maxAmount);

            for (int i = 0; i < ma; i++)
            {
                int rc = UnityEngine.Random.Range(0, colors.Length);
                int rs = UnityEngine.Random.Range(0, sprites.Length);
                GameObject particles = UnityEngine.Object.Instantiate(ModAPI.FindSpawnable("Pumpkin").Prefab.GetComponent<DestroyableBehaviour>().DebrisPrefab.gameObject.transform.Find("chunks").gameObject, parent.position, parent.rotation);
                particles.transform.SetParent(parent);
                if (pos != null)
                    particles.transform.localPosition = pos;
                particles.transform.SetParent(null);

                var ps = particles.GetComponent<ParticleSystem>().main;
                ps.maxParticles = 1;
                ps.startColor = colors[rc];
                ps.startSize = size;
                ps.gravityModifier = 1.0f;

                var sizeModule = particles.GetComponent<ParticleSystem>().sizeOverLifetime;
                sizeModule.enabled = false;

                var textureSheetAnimation = particles.GetComponent<ParticleSystem>().textureSheetAnimation;
                textureSheetAnimation.RemoveSprite(0);
                textureSheetAnimation.AddSprite(sprites[rs]);

                var collisionModule = particles.GetComponent<ParticleSystem>().collision;
                collisionModule.enabled = true;
                collisionModule.dampen = 0.1f;

                particles.GetComponent<ParticleSystem>().Play();
            }
        }
        #endregion
        #region Create Physical Debris Particles
        public static void CreatePhysicalDebrisParticles(Transform parent, Color[] colors, Sprite[] sprites, Vector3 pos, int minAmount = 20, int maxAmount = 25, float speed = 15f, float rotationalSpeed = 2f)
        {
            int ma = UnityEngine.Random.Range(minAmount, maxAmount);

            for (int i = 0; i < ma; i++)
            {
                var DebrisObject = new GameObject("Debris");
                DebrisObject.transform.SetParent(parent.transform);
                DebrisObject.transform.localRotation = Quaternion.identity;
                DebrisObject.transform.localPosition = pos;
                DebrisObject.transform.localScale = Vector3.one;
                DebrisObject.transform.SetParent(null);
                var DebrisObjectRenderer = DebrisObject.AddComponent<SpriteRenderer>();
                DebrisObjectRenderer.sortingLayerName = "Top";
                int rc = UnityEngine.Random.Range(0, colors.Length);
                int rs = UnityEngine.Random.Range(0, sprites.Length);
                DebrisObjectRenderer.sprite = sprites[rs];
                DebrisObjectRenderer.color = colors[rc];
                float v1 = UnityEngine.Random.Range(-speed, speed);
                float v2 = UnityEngine.Random.Range(-speed, speed);
                DebrisObject.AddComponent<Rigidbody2D>().velocity = new Vector2(v1, v2);
                DebrisObject.GetComponent<Rigidbody2D>().AddTorque(UnityEngine.Random.Range(-1f, 1f) * rotationalSpeed, ForceMode2D.Impulse);
                DebrisObject.layer = 10;
                PhysicsMaterial2D mat = new PhysicsMaterial2D();
                mat.bounciness = 0.2f;
                DebrisObject.AddComponent<BoxCollider2D>().sharedMaterial = mat;
                DebrisObject.GetComponent<BoxCollider2D>().size = new Vector2(0.05f, 0.05f);
                DebrisObject.AddComponent<DebrisComponent>();
            }
        }
        #endregion

        #region Setup Car Stats
        public static void SetupCarStats(this CarBehaviour carBehaviour, float speed, float suspensionSpringStrength, float suspensionDamper)
        {
            carBehaviour.MotorSpeed = -speed;
            foreach (WheelJoint2D wheel in carBehaviour.WheelJoints)
            {
                wheel.suspension = new JointSuspension2D()
                {
                    frequency = suspensionSpringStrength,
                    angle = 90f,
                    dampingRatio = suspensionDamper
                };
            }
        }
        #endregion
        #region Set Car Sprites
        #endregion

        #region Offset Slide
        public static void OffsetSlide(this GameObject instance, Transform slide, float xPixels, float yPixels)
        {
            GameObject offset = new GameObject("SlideOffset");
            offset.transform.SetParent(instance.transform);
            offset.transform.localPosition = Vector3.zero;
            offset.transform.localRotation = Quaternion.identity;
            offset.transform.localScale = Vector3.one;
            slide.SetParent(offset.transform);
            offset.transform.localPosition = new Vector3(xPixels * ModAPI.PixelSize, yPixels * ModAPI.PixelSize);
        }
        #endregion
        #region Set Slide Duration
        public static void SetSlideDuration(this Transform slide, float duration)
        {
            slide.GetComponent<TranslationAnimationBehaviour>().Duration = duration;
        }
        #endregion
        #region Set Slide Length
        public static void SetSlideLength(this Transform slide, float length)
        {
            slide.GetComponent<TranslationAnimationBehaviour>().Multiplier = (length * -0.0429f);
        }
        #endregion
        #region Set Precise Slide Length
        public static void SetPreciseSlideLength(this Transform slide, float length)
        {
            slide.GetComponent<TranslationAnimationBehaviour>().Multiplier = length;
        }
        #endregion

        #region Set Bolt Color
        public static void SetBoltColor(this BlasterBehaviour blaster, BlasterboltBehaviour bolt, Color color = default(Color))
        {
            if (color == default(Color))
            {
                color = new Color(0f, 0.2f, 0.5f, 1f);
            }

            ParticleSystem.MainModule main1 = blaster.Muzzleflash.main;
            main1.startColor = color;

            ParticleSystem.MainModule main2 = blaster.Muzzleflash.transform.GetChild(0).GetComponent<ParticleSystem>().main;
            main2.startColor = color;

            bolt.Trail.colorGradient = new Gradient()
            {
                mode = GradientMode.Fixed,
                alphaKeys = new GradientAlphaKey[1]
                {
                    new GradientAlphaKey(1f, 0f)
                },
                colorKeys = new GradientColorKey[1]
                {
                    new GradientColorKey(color, 0f)
                }
            };

            bolt.transform.GetChild(1).GetComponent<SpriteRenderer>().color = color;
            bolt.transform.GetChild(2).GetComponent<SpriteRenderer>().color = color;
        }
        #endregion
        #region Create Box Collider
        public static BoxCollider2D CreateBoxCollider(this GameObject obj, Vector2 offset, Vector2 size)
        {
            BoxCollider2D box = obj.AddComponent<BoxCollider2D>();
            box.offset = offset;
            box.size = size;
            return box;
        }
        #endregion
        #region GetRigidbody
        public static Rigidbody2D GetRigidbody(this Transform obj)
        {
            return obj.GetComponent<Rigidbody2D>();
        }
        #endregion
        #region GetSpriteRenderer
        public static SpriteRenderer GetSpriteRenderer(this Transform obj)
        {
            return obj.GetComponent<SpriteRenderer>();
        }
        #endregion

        #region Set Limb Health Bar Color
        public static void SetLimbHealthBarColor(this LimbBehaviour limb, Color color)
        {
            GameObject myStatus = (GameObject)typeof(LimbBehaviour).GetField("myStatus", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(limb);
            myStatus.transform.Find("bar").GetComponent<SpriteRenderer>().color = color;
        }
        #endregion
        #region Set Limb Sprite
        public static void SetLimbSprite(this LimbBehaviour limbBehaviour, Sprite skin, Sprite flesh, Sprite bone, Sprite damage)
        {
            SpriteRenderer limbSpriteRenderer = limbBehaviour.GetComponent<SpriteRenderer>();
            limbSpriteRenderer.sprite = skin;
            limbSpriteRenderer.material.SetTexture("_FleshTex", flesh.texture);
            limbSpriteRenderer.material.SetTexture("_BoneTex", bone.texture);
            limbSpriteRenderer.material.SetTexture("_DamageTex", damage.texture);

            Sprite sprite = limbSpriteRenderer.sprite;
            LimbSpriteCache.LimbSprites limbSprites = LimbSpriteCache.Instance.LoadFor(sprite, skin.texture, flesh.texture, bone.texture, 1f);

            ShatteredObjectSpriteInitialiser shatteredObjectSpriteInitialiser;
            if (limbBehaviour.TryGetComponent<ShatteredObjectSpriteInitialiser>(out shatteredObjectSpriteInitialiser))
            {
                shatteredObjectSpriteInitialiser.UpdateSprites(limbSprites);
            }
        }
        #endregion
        #region Set Entity Damage Mask
        public static void SetEntityDamageMask(this PersonBehaviour person, Sprite damageMask)
        {
            foreach (LimbBehaviour limbBehaviour in person.Limbs)
            {
                SpriteRenderer renderer = limbBehaviour.SkinMaterialHandler.renderer;
                if (damageMask)
                {
                    renderer.material.SetTexture(ShaderProperties.Get("_DamageTex"), damageMask.texture);
                }
            }
        }
        #endregion
        #region Set Limb Effect Color ( EFFECTS : _SecondBruiseColor / _BloodColor / _Zombie / _BruiseColor / _ThirdBruiseColor )
        public static void SetLimbEffectColor(this LimbBehaviour limb, string id, byte red, byte green, byte blue)
        {
            int nameID = ShaderProperties.Get(id);
            Color value = new Color((float)red / 255f, (float)green / 255f, (float)blue / 255f);
            limb.SkinMaterialHandler.renderer.material.SetColor(nameID, value);
        }
        #endregion

    }
}
