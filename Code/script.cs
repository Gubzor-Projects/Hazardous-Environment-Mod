using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static RadioactiveShit.Resources;
using UmmAPI;
using TMPro;
namespace RadioactiveShit
{
    public class Mod : MonoBehaviour
    {
        public static string ModTag = " [Gubzor][HEM]";
        public static Sprite RArea = ModAPI.LoadSprite("Sprites/Area.png", 100f, true);
        public static string CategoryName = "Hazardous Environmentt Mod";
        public static void Main()
        {
            Resources.LoadResources();
            ModAPI.FindSpawnable("Atom Bomb").Prefab.AddComponent<RadioactiveNuke>();
            ModAPI.FindSpawnable("Atom Bomb").Prefab.GetComponent<RadioactiveNuke>().ExplosionPrefab = ModAPI.FindSpawnable("Atom Bomb").Prefab.GetComponent<AtomBombBehaviour>().ExplosionPrefab;
            Destroy(ModAPI.FindSpawnable("Atom Bomb").Prefab.GetComponent<AtomBombBehaviour>());

            ModAPI.RegisterCategory(CategoryName, "Contains hazardous environment stuff.", ModAPI.LoadSprite("Sprites/Category.png"));

            #region Content
            #region Suits
            #region Mk1
            #region White
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Stick"),
                    NameOverride = "Hazmat Suit [White]" + ModTag,
                    NameToOrderByOverride = "Radioactive",
                    DescriptionOverride = "The only thing that can protect you from biohazards.",
                    CategoryOverride = ModAPI.FindCategory(CategoryName),
                    ThumbnailOverride = ModAPI.LoadSprite("Thumbnails/HazmatSuitWhite.png", 5f),
                    AfterSpawn = (Instance) =>
                    {
                        string Color = "White";
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite($"Sprites/Hazmat Shit/Suit1/{Color}/Cloth.png");
                        Instance.FixColliders();
                        Hazmat_Suit suit = Instance.GetOrAddComponent<Hazmat_Suit>();
                        suit.Skin = ModAPI.LoadTexture($"Sprites/Hazmat Shit/Suit1/{Color}/Suit.png");
                        suit.Lowerarm = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit1/Lower Arm.png");
                        suit.Lowerleg = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit1/Lower Leg.png");
                        suit.Upperarm = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit1/Upper Arm.png");
                        suit.Upperleg = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit1/Upper Leg.png");
                        suit.Lowerbody = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit1/Lower Body.png");

                        if (!Instance.GetComponent<FirstSpawn>())
                        {
                            Instance.AddComponent<FirstSpawn>();
                        }
                    }
                }
            );
            #endregion
            #region Grey
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Stick"),
                    NameOverride = "Hazmat Suit [Grey]" + ModTag,
                    NameToOrderByOverride = "Radioactive",
                    DescriptionOverride = "The only thing that can protect you from biohazards.",
                    CategoryOverride = ModAPI.FindCategory(CategoryName),
                    ThumbnailOverride = ModAPI.LoadSprite("Thumbnails/HazmatSuitGrey.png", 5f),
                    AfterSpawn = (Instance) =>
                    {
                        string Color = "Grey";
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite($"Sprites/Hazmat Shit/Suit1/{Color}/Cloth.png");
                        Instance.FixColliders();
                        Hazmat_Suit suit = Instance.GetOrAddComponent<Hazmat_Suit>();
                        suit.Skin = ModAPI.LoadTexture($"Sprites/Hazmat Shit/Suit1/{Color}/Suit.png");
                        suit.Lowerarm = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit1/Lower Arm.png");
                        suit.Lowerleg = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit1/Lower Leg.png");
                        suit.Upperarm = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit1/Upper Arm.png");
                        suit.Upperleg = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit1/Upper Leg.png");
                        suit.Lowerbody = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit1/Lower Body.png");

                        if (!Instance.GetComponent<FirstSpawn>())
                        {
                            Instance.AddComponent<FirstSpawn>();
                        }
                    }
                }
            );
            #endregion
            #region Red
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Stick"),
                    NameOverride = "Hazmat Suit [Red]" + ModTag,
                    NameToOrderByOverride = "Radioactive",
                    DescriptionOverride = "The only thing that can protect you from biohazards.",
                    CategoryOverride = ModAPI.FindCategory(CategoryName),
                    ThumbnailOverride = ModAPI.LoadSprite("Thumbnails/HazmatSuitRed.png", 5f),
                    AfterSpawn = (Instance) =>
                    {
                        string Color = "Red";
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite($"Sprites/Hazmat Shit/Suit1/{Color}/Cloth.png");
                        Instance.FixColliders();
                        Hazmat_Suit suit = Instance.GetOrAddComponent<Hazmat_Suit>();
                        suit.Skin = ModAPI.LoadTexture($"Sprites/Hazmat Shit/Suit1/{Color}/Suit.png");
                        suit.Lowerarm = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit1/Lower Arm.png");
                        suit.Lowerleg = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit1/Lower Leg.png");
                        suit.Upperarm = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit1/Upper Arm.png");
                        suit.Upperleg = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit1/Upper Leg.png");
                        suit.Lowerbody = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit1/Lower Body.png");

                        if (!Instance.GetComponent<FirstSpawn>())
                        {
                            Instance.AddComponent<FirstSpawn>();
                        }
                    }
                }
            );
            #endregion
            #region Yellow
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Stick"),
                    NameOverride = "Hazmat Suit [Yellow]" + ModTag,
                    NameToOrderByOverride = "Radioactive",
                    DescriptionOverride = "The only thing that can protect you from biohazards.",
                    CategoryOverride = ModAPI.FindCategory(CategoryName),
                    ThumbnailOverride = ModAPI.LoadSprite("Thumbnails/HazmatSuitYellow.png", 5f),
                    AfterSpawn = (Instance) =>
                    {
                        string Color = "Yellow";
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite($"Sprites/Hazmat Shit/Suit1/{Color}/Cloth.png");
                        Instance.FixColliders();
                        Hazmat_Suit suit = Instance.GetOrAddComponent<Hazmat_Suit>();
                        suit.Skin = ModAPI.LoadTexture($"Sprites/Hazmat Shit/Suit1/{Color}/Suit.png");
                        suit.Lowerarm = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit1/Lower Arm.png");
                        suit.Lowerleg = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit1/Lower Leg.png");
                        suit.Upperarm = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit1/Upper Arm.png");
                        suit.Upperleg = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit1/Upper Leg.png");
                        suit.Lowerbody = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit1/Lower Body.png");

                        if (!Instance.GetComponent<FirstSpawn>())
                        {
                            Instance.AddComponent<FirstSpawn>();
                        }
                    }
                }
            );
            #endregion
            #region Green
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Stick"),
                    NameOverride = "Hazmat Suit [Green]" + ModTag,
                    NameToOrderByOverride = "Radioactive",
                    DescriptionOverride = "The only thing that can protect you from biohazards.",
                    CategoryOverride = ModAPI.FindCategory(CategoryName),
                    ThumbnailOverride = ModAPI.LoadSprite("Thumbnails/HazmatSuitGreen.png", 5f),
                    AfterSpawn = (Instance) =>
                    {
                        string Color = "Green";
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite($"Sprites/Hazmat Shit/Suit1/{Color}/Cloth.png");
                        Instance.FixColliders();
                        Hazmat_Suit suit = Instance.GetOrAddComponent<Hazmat_Suit>();
                        suit.Skin = ModAPI.LoadTexture($"Sprites/Hazmat Shit/Suit1/{Color}/Suit.png");
                        suit.Lowerarm = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit1/Lower Arm.png");
                        suit.Lowerleg = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit1/Lower Leg.png");
                        suit.Upperarm = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit1/Upper Arm.png");
                        suit.Upperleg = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit1/Upper Leg.png");
                        suit.Lowerbody = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit1/Lower Body.png");

                        if (!Instance.GetComponent<FirstSpawn>())
                        {
                            Instance.AddComponent<FirstSpawn>();
                        }
                    }
                }
            );
            #endregion
            #endregion
            #region Mk2
            #region White
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Metal Cube"),
                    NameOverride = "Hazmat Suit Mk2 [White]" + ModTag,
                    NameToOrderByOverride = "Radioactive",
                    DescriptionOverride = "Guarantees 100% protection from radioactivity. Comes packed with Oxygen Tank by default",
                    CategoryOverride = ModAPI.FindCategory(CategoryName),
                    ThumbnailOverride = ModAPI.LoadSprite("Thumbnails/HazmatSuit2White.png", 5f),
                    AfterSpawn = (Instance) =>
                    {
                        string Color = "White";
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite($"Sprites/Hazmat Shit/Suit2/{Color}/Pack.png");
                        Instance.FixColliders();
                        Hazmat_Suit2 suit = Instance.GetOrAddComponent<Hazmat_Suit2>();
                        suit.Skin = ModAPI.LoadTexture($"Sprites/Hazmat Shit/Suit2/{Color}/Suit.png");
                        suit.Lowerarm = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Lower Arm.png");
                        suit.Lowerleg = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Lower Leg.png");
                        suit.Upperarm = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Upper Arm.png");
                        suit.Upperleg = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Upper Leg.png");
                        suit.Lowerbody = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Lower Body.png");
                        suit.Upperbody = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Oxygen Tank Body 2.png");
                        suit.Middlebody = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Oxygen Tank Body 1.png");

                        if (!Instance.GetComponent<FirstSpawn>())
                        {
                            Instance.AddComponent<FirstSpawn>();
                        }
                    }
                }
            );
            #endregion
            #region Grey
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Metal Cube"),
                    NameOverride = "Hazmat Suit Mk2 [Grey]" + ModTag,
                    NameToOrderByOverride = "Radioactive",
                    DescriptionOverride = "Guarantees 100% protection from radioactivity. Comes packed with Oxygen Tank by default",
                    CategoryOverride = ModAPI.FindCategory(CategoryName),
                    ThumbnailOverride = ModAPI.LoadSprite("Thumbnails/HazmatSuit2Grey.png", 5f),
                    AfterSpawn = (Instance) =>
                    {
                        string Color = "Grey";
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite($"Sprites/Hazmat Shit/Suit2/{Color}/Pack.png");
                        Instance.FixColliders();
                        Hazmat_Suit2 suit = Instance.GetOrAddComponent<Hazmat_Suit2>();
                        suit.Skin = ModAPI.LoadTexture($"Sprites/Hazmat Shit/Suit2/{Color}/Suit.png");
                        suit.Lowerarm = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Lower Arm.png");
                        suit.Lowerleg = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Lower Leg.png");
                        suit.Upperarm = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Upper Arm.png");
                        suit.Upperleg = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Upper Leg.png");
                        suit.Lowerbody = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Lower Body.png");
                        suit.Upperbody = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Oxygen Tank Body 2.png");
                        suit.Middlebody = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Oxygen Tank Body 1.png");

                        if (!Instance.GetComponent<FirstSpawn>())
                        {
                            Instance.AddComponent<FirstSpawn>();
                        }
                    }
                }
            );
            #endregion
            #region Red
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Metal Cube"),
                    NameOverride = "Hazmat Suit Mk2 [Red]" + ModTag,
                    NameToOrderByOverride = "Radioactive",
                    DescriptionOverride = "Guarantees 100% protection from radioactivity. Comes packed with Oxygen Tank by default",
                    CategoryOverride = ModAPI.FindCategory(CategoryName),
                    ThumbnailOverride = ModAPI.LoadSprite("Thumbnails/HazmatSuit2Red.png", 5f),
                    AfterSpawn = (Instance) =>
                    {
                        string Color = "Red";
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite($"Sprites/Hazmat Shit/Suit2/{Color}/Pack.png");
                        Instance.FixColliders();
                        Hazmat_Suit2 suit = Instance.GetOrAddComponent<Hazmat_Suit2>();
                        suit.Skin = ModAPI.LoadTexture($"Sprites/Hazmat Shit/Suit2/{Color}/Suit.png");
                        suit.Lowerarm = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Lower Arm.png");
                        suit.Lowerleg = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Lower Leg.png");
                        suit.Upperarm = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Upper Arm.png");
                        suit.Upperleg = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Upper Leg.png");
                        suit.Lowerbody = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Lower Body.png");
                        suit.Upperbody = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Oxygen Tank Body 2.png");
                        suit.Middlebody = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Oxygen Tank Body 1.png");

                        if (!Instance.GetComponent<FirstSpawn>())
                        {
                            Instance.AddComponent<FirstSpawn>();
                        }
                    }
                }
            );
            #endregion
            #region Yellow
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Metal Cube"),
                    NameOverride = "Hazmat Suit Mk2 [Yellow]" + ModTag,
                    NameToOrderByOverride = "Radioactive",
                    DescriptionOverride = "Guarantees 100% protection from radioactivity. Comes packed with Oxygen Tank by default",
                    CategoryOverride = ModAPI.FindCategory(CategoryName),
                    ThumbnailOverride = ModAPI.LoadSprite("Thumbnails/HazmatSuit2Yellow.png", 5f),
                    AfterSpawn = (Instance) =>
                    {
                        string Color = "Yellow";
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite($"Sprites/Hazmat Shit/Suit2/{Color}/Pack.png");
                        Instance.FixColliders();
                        Hazmat_Suit2 suit = Instance.GetOrAddComponent<Hazmat_Suit2>();
                        suit.Skin = ModAPI.LoadTexture($"Sprites/Hazmat Shit/Suit2/{Color}/Suit.png");
                        suit.Lowerarm = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Lower Arm.png");
                        suit.Lowerleg = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Lower Leg.png");
                        suit.Upperarm = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Upper Arm.png");
                        suit.Upperleg = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Upper Leg.png");
                        suit.Lowerbody = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Lower Body.png");
                        suit.Upperbody = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Oxygen Tank Body 2.png");
                        suit.Middlebody = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Oxygen Tank Body 1.png");

                        if (!Instance.GetComponent<FirstSpawn>())
                        {
                            Instance.AddComponent<FirstSpawn>();
                        }
                    }
                }
            );
            #endregion
            #region Green
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Metal Cube"),
                    NameOverride = "Hazmat Suit Mk2 [Green]" + ModTag,
                    NameToOrderByOverride = "Radioactive",
                    DescriptionOverride = "Guarantees 100% protection from radioactivity. Comes packed with Oxygen Tank by default",
                    CategoryOverride = ModAPI.FindCategory(CategoryName),
                    ThumbnailOverride = ModAPI.LoadSprite("Thumbnails/HazmatSuit2Green.png", 5f),
                    AfterSpawn = (Instance) =>
                    {
                        string Color = "Green";
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite($"Sprites/Hazmat Shit/Suit2/{Color}/Pack.png");
                        Instance.FixColliders();
                        Hazmat_Suit2 suit = Instance.GetOrAddComponent<Hazmat_Suit2>();
                        suit.Skin = ModAPI.LoadTexture($"Sprites/Hazmat Shit/Suit2/{Color}/Suit.png");
                        suit.Lowerarm = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Lower Arm.png");
                        suit.Lowerleg = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Lower Leg.png");
                        suit.Upperarm = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Upper Arm.png");
                        suit.Upperleg = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Upper Leg.png");
                        suit.Lowerbody = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Lower Body.png");
                        suit.Upperbody = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Oxygen Tank Body 2.png");
                        suit.Middlebody = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit2/Oxygen Tank Body 1.png");

                        if (!Instance.GetComponent<FirstSpawn>())
                        {
                            Instance.AddComponent<FirstSpawn>();
                        }
                    }
                }
            );
            #endregion
            #endregion
            #endregion
            #region Oxygen Tank
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Stick"),
                    NameOverride = "Oxygen Tank" + ModTag,
                    NameToOrderByOverride = "Radioactive",
                    DescriptionOverride = "You need it to not suffocate.",
                    CategoryOverride = ModAPI.FindCategory(CategoryName),
                    ThumbnailOverride = ModAPI.LoadSprite("Thumbnails/OxygenTank.png", 5f),
                    AfterSpawn = (Instance) =>
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit1/Oxygen Tank.png");
                        Instance.FixColliders();
                        Hazmat_OxygenTank Gastank = Instance.GetOrAddComponent<Hazmat_OxygenTank>();
                        Gastank.Upperbody = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit1/Oxygen Tank Body 2.png");
                        Gastank.Middlebody = ModAPI.LoadSprite("Sprites/Hazmat Shit/Suit1/Oxygen Tank Body 1.png");

                        if (!Instance.GetComponent<FirstSpawn>())
                        {
                            Instance.AddComponent<FirstSpawn>();
                        }
                    }
                }
            );
            #endregion
            #region Gasmask Mk1
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Stick"),
                    NameOverride = "Gasmask Mk1" + ModTag,
                    NameToOrderByOverride = "Radioactive",
                    DescriptionOverride = "Ig for safe breathing",
                    CategoryOverride = ModAPI.FindCategory(CategoryName),
                    ThumbnailOverride = ModAPI.LoadSprite("Thumbnails/Gasmask1.png", 5f),
                    AfterSpawn = (Instance) =>
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Sprites/Hazmat Shit/Gasmask 1.png");
                        Instance.FixColliders();
                        Hazmat_Gasmask Gastank = Instance.GetOrAddComponent<Hazmat_Gasmask>();
                        Gastank.Head = ModAPI.LoadSprite("Sprites/Hazmat Shit/Gasmask 1.png");

                        if (!Instance.GetComponent<FirstSpawn>())
                        {
                            Instance.AddComponent<FirstSpawn>();
                        }
                    }
                }
            );
            #endregion
            #region Gasmask Mk2
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Stick"),
                    NameOverride = "Gasmask Mk2" + ModTag,
                    NameToOrderByOverride = "Radioactive",
                    DescriptionOverride = "Ig for safe breathing",
                    CategoryOverride = ModAPI.FindCategory(CategoryName),
                    ThumbnailOverride = ModAPI.LoadSprite("Thumbnails/Gasmask2.png", 5f),
                    AfterSpawn = (Instance) =>
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Sprites/Hazmat Shit/Gasmask 2.png");
                        Instance.FixColliders();
                        Hazmat_Gasmask Gastank = Instance.GetOrAddComponent<Hazmat_Gasmask>();
                        Gastank.Head = ModAPI.LoadSprite("Sprites/Hazmat Shit/Gasmask 2.png");

                        if (!Instance.GetComponent<FirstSpawn>())
                        {
                            Instance.AddComponent<FirstSpawn>();
                        }
                    }
                }
            );
            #endregion
            #region Geiger Meter
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Rod"),
                    NameOverride = "Geiger Meter" + ModTag,
                    NameToOrderByOverride = "Radioactive",
                    DescriptionOverride = "For measuring radioactivity.",
                    CategoryOverride = ModAPI.FindCategory(CategoryName),
                    ThumbnailOverride = ModAPI.LoadSprite("Thumbnails/RadioactiveBarrel.png", 5f),
                    AfterSpawn = (Instance) =>
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Sprites/Geiger Meter.png");
                        Instance.FixColliders();

                        Instance.GetComponent<PhysicalBehaviour>().InitialMass = 2 * 0.025f;
                        Instance.GetComponent<PhysicalBehaviour>().TrueInitialMass = 2 * 0.025f;
                        Instance.GetComponent<PhysicalBehaviour>().rigidbody.mass = 2 * 0.025f;

                        GameObject Text = Instantiate<GameObject>(ModAPI.FindSpawnable("Text Display").Prefab.transform.Find("Text").gameObject, Instance.transform.position, Instance.transform.rotation);
                        Text.transform.SetParent(Instance.transform);
                        Text.transform.localPosition = new Vector3(-0.2062f, 0.225f);
                        Text.transform.localScale = new Vector3(0.4502f, 0.4502f);
                        TextMeshPro TextScript = Text.GetComponent<TextMeshPro>();
                        TextScript.text = "0";
                        TextScript.color = Color.green;
                        TextScript.enableAutoSizing = false;
                        TextScript.fontSize = 1f;


                        if (!Instance.GetComponent<FirstSpawn>())
                        {
                            Instance.AddComponent<FirstSpawn>();
                        }
                    }
                }
            );
            #endregion
            #region Radioactive Barrel
            ModAPI.Register(
                new Modification()
                {
                    OriginalItem = ModAPI.FindSpawnable("Brick"),
                    NameOverride = "Radioactive Barrel" + ModTag,
                    NameToOrderByOverride = "Radioactive",
                    DescriptionOverride = "Powerful explosive. I legit don't fucking know what in the hell did they put here but it's so strong that area that's affected by it literally makes people have their limbs fall off",
                    CategoryOverride = ModAPI.FindCategory(CategoryName),
                    ThumbnailOverride = ModAPI.LoadSprite("Thumbnails/RadioactiveBarrel.png", 5f),
                    AfterSpawn = (Instance) =>
                    {
                        Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Sprites/Barrel.png");
                        Instance.GetOrAddComponent<RandomSpriteBehaviour>().sprites = new Sprite[]
                        {
                            ModAPI.LoadSprite("Sprites/Barrel.png"),
                            ModAPI.LoadSprite("Sprites/Barrel Sign.png"),
                        };
                        Instance.FixColliders();

                        Instance.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Metal");
                        Instance.GetComponent<PhysicalBehaviour>().InitialMass = 20;
                        Instance.GetComponent<PhysicalBehaviour>().TrueInitialMass = 20;
                        Instance.GetComponent<PhysicalBehaviour>().rigidbody.mass = 20;

                        Instance.GetOrAddComponent<RadioactiveBarrelBehaviour>();

                        if (!Instance.GetComponent<FirstSpawn>())
                        {
                            Instance.AddComponent<FirstSpawn>();
                        }
                    }
                }
            );
            #endregion
            #endregion
        }
    }
    #region Functionalities
    public class Hazmat_Suit_Functionality : MonoBehaviour
    {

    }
    public class Hazmat_Suit2_Functionality : MonoBehaviour
    {

    }
    public class Hazmat_OxygenTank_Functionality : MonoBehaviour
    {

    }
    public class Hazmat_Gasmask_Functionality : MonoBehaviour
    {

    }
    #endregion
    #region Suit Stuff
    public class Hazmat_OxygenTank : MonoBehaviour
    {
        public Sprite Upperbody;
        public Sprite Middlebody;
        public void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<LimbBehaviour>() && other.gameObject.transform.root.gameObject.GetComponent<PersonBehaviour>() && !other.gameObject.transform.root.gameObject.GetComponent<Hazmat_OxygenTank_Functionality>())
            {
                var UpperBody = other.gameObject.transform.root.Find("Body/UpperBody").gameObject;
                var MiddleBody = other.gameObject.transform.root.Find("Body/MiddleBody").gameObject;
                UmAPI.CreateDetailObject(UpperBody, Upperbody, Vector3.zero);
                UmAPI.CreateDetailObject(MiddleBody, Middlebody, Vector3.zero);

                other.gameObject.transform.root.gameObject.AddComponent<Hazmat_OxygenTank_Functionality>();

                Destroy(gameObject);
            }
        }
    }
    public class Hazmat_Gasmask : MonoBehaviour
    {
        public Sprite Head;
        public void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<LimbBehaviour>() && other.gameObject.transform.root.gameObject.GetComponent<PersonBehaviour>() && !other.gameObject.transform.root.gameObject.GetComponent<Hazmat_Gasmask_Functionality>())
            {
                var Head = other.gameObject.transform.root.Find("Head").gameObject;
                UmAPI.CreateDetailObject(Head, this.Head, Vector3.zero);

                other.gameObject.transform.root.gameObject.AddComponent<Hazmat_Gasmask_Functionality>();

                Destroy(gameObject);
            }
        }
    }
    public class Hazmat_Suit2 : MonoBehaviour
    {
        public Texture2D Skin;
        public Sprite Lowerbody;
        public Sprite Upperbody;
        public Sprite Middlebody;
        public Sprite Upperarm;
        public Sprite Upperleg;
        public Sprite Lowerarm;
        public Sprite Lowerleg;
        public void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<LimbBehaviour>() && other.gameObject.transform.root.gameObject.GetComponent<PersonBehaviour>() && !other.gameObject.transform.root.gameObject.GetComponent<Hazmat_Suit2_Functionality>())
            {
                Texture2D OriginalSkin = other.transform.root.Find("Head").GetComponent<SpriteRenderer>().sprite.texture;

                if (OriginalSkin.width == Skin.width || OriginalSkin.height == Skin.height)
                {
                    Texture2D NewSkin = new Texture2D(OriginalSkin.width, OriginalSkin.height);

                    for (int y = 0; y < OriginalSkin.height; y++)
                    {
                        for (int x = 0; x < OriginalSkin.width; x++)
                        {
                            Color OriginalSkinColor = OriginalSkin.GetPixel(x, y);
                            Color SkinColor = Skin.GetPixel(x, y);

                            Color NewColor = new Color(SkinColor.r, SkinColor.g, SkinColor.b, 0f);

                            if (SkinColor.a != 0f && OriginalSkinColor.a != 0f)
                            {
                                NewColor = new Color(SkinColor.r, SkinColor.g, SkinColor.b, SkinColor.a);
                            }

                            else
                            {
                                NewColor = new Color(OriginalSkinColor.r, OriginalSkinColor.g, OriginalSkinColor.b, OriginalSkinColor.a);
                            }

                            NewSkin.SetPixel(x, y, NewColor);
                        }
                    }

                    NewSkin.Apply();
                    NewSkin.filterMode = FilterMode.Point;

                    other.gameObject.GetComponent<LimbBehaviour>().Person.SetBodyTextures(NewSkin);

                    var LowerBody = other.gameObject.transform.root.Find("Body/LowerBody").gameObject;
                    var UpperBody = other.gameObject.transform.root.Find("Body/UpperBody").gameObject;
                    var MiddleBody = other.gameObject.transform.root.Find("Body/MiddleBody").gameObject;
                    var UpperArm = other.gameObject.transform.root.Find("BackArm/UpperArm").gameObject;
                    var UpperLeg = other.gameObject.transform.root.Find("BackLeg/UpperLeg").gameObject;
                    var LowerArm = other.gameObject.transform.root.Find("BackArm/LowerArm").gameObject;
                    var LowerLeg = other.gameObject.transform.root.Find("BackLeg/LowerLeg").gameObject;
                    var UpperArmFront = other.gameObject.transform.root.Find("FrontArm/UpperArmFront").gameObject;
                    var UpperLegFront = other.gameObject.transform.root.Find("FrontLeg/UpperLegFront").gameObject;
                    var LowerArmFront = other.gameObject.transform.root.Find("FrontArm/LowerArmFront").gameObject;
                    var LowerLegFront = other.gameObject.transform.root.Find("FrontLeg/LowerLegFront").gameObject;
                    var Foot = other.gameObject.transform.root.gameObject.GetComponent<PersonBehaviour>().Limbs[6].gameObject;

                    UmAPI.CreateDetailObject(LowerBody, Lowerbody, Vector3.zero);
                    UmAPI.CreateDetailObject(UpperBody, Upperbody, Vector3.zero);
                    UmAPI.CreateDetailObject(MiddleBody, Middlebody, Vector3.zero);
                    UmAPI.CreateDetailObject(UpperArm, Upperarm, Vector3.zero);
                    UmAPI.CreateDetailObject(UpperLeg, Upperleg, Vector3.zero);
                    UmAPI.CreateDetailObject(UpperArmFront, Upperarm, Vector3.zero);
                    UmAPI.CreateDetailObject(UpperLegFront, Upperleg, Vector3.zero);
                    UmAPI.CreateDetailObject(LowerArm, Lowerarm, Vector3.zero);
                    UmAPI.CreateDetailObject(LowerLeg, Lowerleg, Vector3.zero);
                    UmAPI.CreateDetailObject(LowerArmFront, Lowerarm, Vector3.zero);
                    UmAPI.CreateDetailObject(LowerLegFront, Lowerleg, Vector3.zero);
                    other.gameObject.transform.root.gameObject.AddComponent<Hazmat_Suit2_Functionality>();
                    other.gameObject.transform.root.gameObject.AddComponent<Hazmat_OxygenTank_Functionality>();
                }

                Destroy(gameObject);
            }
        }
    }
    public class Hazmat_Suit : MonoBehaviour
    {
        public Texture2D Skin;
        public Sprite Lowerbody;
        public Sprite Upperarm;
        public Sprite Upperleg;
        public Sprite Lowerarm;
        public Sprite Lowerleg;
        public void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<LimbBehaviour>() && other.gameObject.transform.root.gameObject.GetComponent<PersonBehaviour>() && !other.gameObject.transform.root.gameObject.GetComponent<Hazmat_Suit_Functionality>())
            {
                Texture2D OriginalSkin = other.transform.root.Find("Head").GetComponent<SpriteRenderer>().sprite.texture;

                if (OriginalSkin.width == Skin.width || OriginalSkin.height == Skin.height)
                {
                    Texture2D NewSkin = new Texture2D(OriginalSkin.width, OriginalSkin.height);

                    for (int y = 0; y < OriginalSkin.height; y++)
                    {
                        for (int x = 0; x < OriginalSkin.width; x++)
                        {
                            Color OriginalSkinColor = OriginalSkin.GetPixel(x, y);
                            Color SkinColor = Skin.GetPixel(x, y);

                            Color NewColor = new Color(SkinColor.r, SkinColor.g, SkinColor.b, 0f);

                            if (SkinColor.a != 0f && OriginalSkinColor.a != 0f)
                            {
                                NewColor = new Color(SkinColor.r, SkinColor.g, SkinColor.b, SkinColor.a);
                            }

                            else
                            {
                                NewColor = new Color(OriginalSkinColor.r, OriginalSkinColor.g, OriginalSkinColor.b, OriginalSkinColor.a);
                            }

                            NewSkin.SetPixel(x, y, NewColor);
                        }
                    }

                    NewSkin.Apply();
                    NewSkin.filterMode = FilterMode.Point;

                    other.gameObject.GetComponent<LimbBehaviour>().Person.SetBodyTextures(NewSkin);

                    var LowerBody = other.gameObject.transform.root.Find("Body/LowerBody").gameObject;
                    var UpperBody = other.gameObject.transform.root.Find("Body/UpperBody").gameObject;
                    var MiddleBody = other.gameObject.transform.root.Find("Body/MiddleBody").gameObject;
                    var UpperArm = other.gameObject.transform.root.Find("BackArm/UpperArm").gameObject;
                    var UpperLeg = other.gameObject.transform.root.Find("BackLeg/UpperLeg").gameObject;
                    var LowerArm = other.gameObject.transform.root.Find("BackArm/LowerArm").gameObject;
                    var LowerLeg = other.gameObject.transform.root.Find("BackLeg/LowerLeg").gameObject;
                    var UpperArmFront = other.gameObject.transform.root.Find("FrontArm/UpperArmFront").gameObject;
                    var UpperLegFront = other.gameObject.transform.root.Find("FrontLeg/UpperLegFront").gameObject;
                    var LowerArmFront = other.gameObject.transform.root.Find("FrontArm/LowerArmFront").gameObject;
                    var LowerLegFront = other.gameObject.transform.root.Find("FrontLeg/LowerLegFront").gameObject;
                    var Foot = other.gameObject.transform.root.gameObject.GetComponent<PersonBehaviour>().Limbs[6].gameObject;

                    UmAPI.CreateDetailObject(LowerBody, Lowerbody, Vector3.zero);
                    //UmAPI.CreateDetailObject(UpperBody, Upperbody, Vector3.zero);
                    //UmAPI.CreateDetailObject(MiddleBody, Middlebody, Vector3.zero);
                    UmAPI.CreateDetailObject(UpperArm, Upperarm, Vector3.zero);
                    UmAPI.CreateDetailObject(UpperLeg, Upperleg, Vector3.zero);
                    UmAPI.CreateDetailObject(UpperArmFront, Upperarm, Vector3.zero);
                    UmAPI.CreateDetailObject(UpperLegFront, Upperleg, Vector3.zero);
                    UmAPI.CreateDetailObject(LowerArm, Lowerarm, Vector3.zero);
                    UmAPI.CreateDetailObject(LowerLeg, Lowerleg, Vector3.zero);
                    UmAPI.CreateDetailObject(LowerArmFront, Lowerarm, Vector3.zero);
                    UmAPI.CreateDetailObject(LowerLegFront, Lowerleg, Vector3.zero);
                    other.gameObject.transform.root.gameObject.AddComponent<Hazmat_Suit_Functionality>();
                }

                Destroy(gameObject);
            }
        }
    }
    #endregion

    public class GeigerMeter : MonoBehaviour
    {
        public TextMeshPro Text;

        void Start
    }

    public class RadioactiveCloudNuke : MonoBehaviour
    {
        float stuff;
        float stuff2;
        void Update()
        {
            stuff += Time.fixedDeltaTime;
            stuff2 += Time.fixedDeltaTime;
            if (stuff >= 1)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 35000);
                foreach (Collider2D collider in colliders)
                {
                    if (UnityEngine.Random.value >= 0.5f) collider.transform.SendMessage("Damage", 10f, SendMessageOptions.RequireReceiver);
                    if (UnityEngine.Random.value >= 0.5f) collider.transform.SendMessage("OnEMPHit", SendMessageOptions.RequireReceiver);
                }
                stuff = 0;
            }
            if (stuff2 >= 0.5f)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 35000);
                foreach (Collider2D collider in colliders)
                {
                    LimbBehaviour limb = collider.GetComponent<LimbBehaviour>();
                    if (limb)
                    {
                        limb.SkinMaterialHandler.RottenProgress += 0.01f;
                        limb.SkinMaterialHandler.AcidProgress += 0.005f;
                    }
                }
                stuff2 = 0;
            }
            Destroy(gameObject, 300);
        }
    }
    public class RadioactiveNuke : MonoBehaviour, Messages.IUse
    {
        public void Use(ActivationPropagation activation)
        {
            if (!base.enabled)
            {
                return;
            }
            UnityEngine.Object.Instantiate<GameObject>(this.ExplosionPrefab, base.transform.position, Quaternion.identity);
            UnityEngine.Object.Destroy(base.gameObject);
            Resources.SpawnResources(transform.position, "Radioactive Explosion Cloud Nuke", false, null).transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Mod.RArea;
        }
        [SkipSerialisation]
        public GameObject ExplosionPrefab;
    }
    public class RadioactiveBarrelBehaviour : MonoBehaviour
    {
        public float MaxDamage = 50f;
        public float Damage;
        public float MinimumImpactForce = 175f;
        private static readonly ContactPoint2D[] buffer = new ContactPoint2D[8];

        private void OnCollisionEnter2D(Collision2D collision)
        {
            EvaluateCollision(collision);
        }
        private void OnCollisionStay2D(Collision2D collision)
        {
            EvaluateCollision(collision);
        }
        private void EvaluateCollision(Collision2D collision)
        {
            int contacts = collision.GetContacts(buffer);
            if (Utils.GetMinImpulse(buffer, contacts) < MinimumImpactForce)
            {
                return;
            }
            Explode();
        }

        public void Shot(Shot shot)
        {
            Damage += shot.damage;
            if (Damage < MaxDamage)
            {
                return;
            }
            else
            {
                Explode();
            }
        }
        void Explode()
        {
            for (int i = 0; i < 25; i++)
            {
                Resources.SpawnResources(transform.position, "Radioactive Explosion Debris", false, null);
            }
            Resources.SpawnResources(transform.position, "Radioactive Explosion Cloud", false, null).transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Mod.RArea;
            ExplosionCreator.CreateFragmentationExplosion(new ExplosionCreator.ExplosionParameters(32, transform.position, 50f, 15f, true, ExplosionCreator.EffectSize.Large, 0.7f, 20));
            Destroy(gameObject);
        }
        void Update()
        {
        }
    }
    public class FirstSpawn : MonoBehaviour
    {

    }
}