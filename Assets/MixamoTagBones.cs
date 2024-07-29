using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class MixamoTagBones : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TagChildren();
		DestroyImmediate(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject Origin;
    public GameObject Collider;
    public GameObject LeftLowerLegGore;
    public GameObject RightLowerLegGore;
    public GameObject LeftLowerArmGore;
    public GameObject LeftUpperArmGore;
    public GameObject RightLowerArmGore;
    public GameObject RightUpperArmGore;
    public GameObject HeadGore;
    public GameObject LeftUpperLegGore;
    public GameObject RightUpperLegGore;

    public GameObject Hips;
    public GameObject LeftUpLeg;
    public GameObject LeftLeg;
    public GameObject RightUpLeg;
    public GameObject RightLeg;
    public GameObject LeftArm;
    public GameObject LeftForeArm;
    public GameObject RightArm;
    public GameObject RightForeArm;
    public GameObject Head;
    public GameObject Spine1;

    public void TagChildren()
    {
       
        //Initializes Child Objects
        GameObject Origin = GameObject.Find("Origin");
        GameObject Collider = GameObject.Find("Collider");
        GameObject Hips = GameObject.Find("Hips");
        GameObject LeftUpLeg = GameObject.Find("LeftUpLeg");
        GameObject LeftLeg = GameObject.Find("LeftLeg");
        GameObject RightUpLeg = GameObject.Find("RightUpLeg");
        GameObject RightLeg = GameObject.Find("RightLeg");
        GameObject Spine1 = GameObject.Find("Spine1");
        GameObject LeftArm = GameObject.Find("LeftArm");
        GameObject LeftForeArm = GameObject.Find("LeftForeArm");
        GameObject RightArm = GameObject.Find("RightArm");
        GameObject RightForeArm = GameObject.Find("RightForeArm");
        GameObject Head = GameObject.Find("Head");

        GameObject Spine = GameObject.Find("Spine");
        GameObject Spine2 = GameObject.Find("Spine2");
        GameObject LeftShoulder = GameObject.Find("LeftShoulder");
        GameObject RightShoulder = GameObject.Find("RightShoulder");
        GameObject LeftHand = GameObject.Find("LeftHand");
        GameObject Neck = GameObject.Find("Neck");
        GameObject RightHand = GameObject.Find("RightHand");
        GameObject LeftLowerLegGore = GameObject.Find("LeftLowerLegGore");
        GameObject RightLowerLegGore = GameObject.Find("RightLowerLegGore");
        GameObject LeftLowerArmGore = GameObject.Find("LeftLowerArmGore");
        GameObject LeftUpperArmGore = GameObject.Find("LeftUpperArmGore");
        GameObject RightLowerArmGore = GameObject.Find("RightLowerArmGore");
        GameObject RightUpperArmGore = GameObject.Find("RightUpperArmGore");
        GameObject HeadGore = GameObject.Find("HeadGore");
        GameObject LeftUpperLegGore = GameObject.Find("LeftUpperLegGore");
        GameObject RightUpperLegGore = GameObject.Find("RightUpperLegGore");

        //Tags Children
        Origin.tag = "E_BP_BipedRoot";
        Hips.tag = "E_BP_Body";
        LeftUpLeg.tag = "E_BP_LLeg";
        LeftLeg.tag = "E_BP_LLowerLeg";
        RightUpLeg.tag = "E_BP_RLeg";
        RightLeg.tag = "E_BP_RLowerLeg";
        Spine1.tag = "E_BP_Body";
        LeftArm.tag = "E_BP_LArm";
        LeftForeArm.tag = "E_BP_LLowerArm";
        RightArm.tag = "E_BP_RArm";
        RightForeArm.tag = "E_BP_RLowerArm";
        Head.tag = "E_BP_Head";
        Collider.tag = "LargeEntityBlocker";
        Collider.layer = 19;

        LeftLowerLegGore.tag = "L_LeftLowerLegGore";
        RightLowerLegGore.tag = "L_RightLowerLegGore";
        LeftLowerArmGore.tag = "L_LeftLowerArmGore";
        LeftUpperArmGore.tag = "L_LeftUpperArmGore";
        RightLowerArmGore.tag = "L_RightLowerArmGore";
        RightUpperArmGore.tag = "L_RightUpperArmGore";
        HeadGore.tag = "L_HeadGore";
        LeftUpperLegGore.tag = "L_LeftUpperLegGore";
        RightUpperLegGore.tag = "L_RightUpperLegGore";
    }
}