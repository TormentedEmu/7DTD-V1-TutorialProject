using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MixamoCreateStructure : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        CreateChildren();
		DestroyImmediate(this);
    }

    public void CreateChildren()
    {
        var Hips = FindGameObject("Hips");
        var LeftUpLeg = FindGameObject("LeftUpLeg");
        var LeftLeg = FindGameObject("LeftLeg");
        var RightUpLeg = FindGameObject("RightUpLeg");
        var RightLeg = FindGameObject("RightLeg");
        var Spine2 = FindGameObject("Spine2");
        var Head = FindGameObject("Head");
        var LeftShoulder = FindGameObject("LeftShoulder");
        var LeftArm = FindGameObject("LeftArm");
        var LeftForeArm = FindGameObject("LeftForeArm");
        var LeftHand = FindGameObject("LeftHand");
        var RightShoulder = FindGameObject("RightShoulder");
        var RightArm = FindGameObject("RightArm");
        var RightForeArm = FindGameObject("RightForeArm");
        var RightHand = FindGameObject("RightHand");

        var Origin = CreateGameObject("Origin", gameObject);
        Hips.transform.parent = Origin.transform;

        CreateGameObject("Footsteps", Hips);

        var Collider = CreateGameObject("Collider", gameObject);
        var capsule = Collider.AddComponent<CapsuleCollider>();
        // These are just estimates to get started, still need to adjust later
        capsule.radius = 0.2f;
        capsule.height = 1.5f;
        capsule.center = new Vector3(0, 1, 0);

        var IconTag = CreateGameObject("IconTag", gameObject);
        IconTag.transform.position = new Vector3(0, 2.0f, 0);

        // Gore objects - these will get their transform values from the game objects that are
        // removed when dismemberment occurs
        CreateGameObject("LeftUpperLegGore", Hips, LeftUpLeg);
        CreateGameObject("LeftLowerLegGore", LeftUpLeg, LeftLeg);
        CreateGameObject("RightUpperLegGore", Hips, RightUpLeg);
        CreateGameObject("RightLowerLegGore", RightUpLeg, RightLeg);
        CreateGameObject("LeftLowerArmGore", LeftArm, LeftForeArm);
        CreateGameObject("LeftUpperArmGore", LeftShoulder, LeftArm);
        CreateGameObject("RightLowerArmGore", RightArm, RightForeArm);
        CreateGameObject("RightUpperArmGore", RightShoulder, RightArm);
        CreateGameObject("HeadGore", Spine2, Head);

        // A19 weapon objects - need to be replaced for A20 vanilla weapons
        CreateGameObject("RightWeapon", RightHand, new Vector3(0, 0, 180));
        CreateGameObject("LeftWeapon", LeftHand, new Vector3(0, 0, 0));
        CreateGameObject("Gunjoint", RightHand, new Vector3(0, 0, 180));
    }

    /// <summary>
    /// Creates a new game object, as a child of the parent, with the specified euler rotation (if any).
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private GameObject CreateGameObject(string name, GameObject parent, Vector3? eulers = null)
    {
        var obj = new GameObject
        {
            name = name
        };

        if (parent != null)
        {
            obj.transform.parent = parent.transform;
            // Move the object to the same position as the parent
            obj.transform.localPosition = new Vector3(0, 0, 0);
        }

        if (eulers.HasValue)
        {
            obj.transform.Rotate(eulers.Value);
        }

        return obj;
    }

    /// <summary>
    /// Creates a new game object, as a child of the parent, with the local transform values copied
    /// from the transform source object.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="parent"></param>
    /// <param name="transformSource"></param>
    /// <returns></returns>
    private GameObject CreateGameObject(string name, GameObject parent, GameObject transformSource)
    {
        var obj = new GameObject
        {
            name = name
        };

        if (parent != null)
        {
            obj.transform.parent = parent.transform;
        }

        if (transformSource != null)
        {
            if (obj.transform.parent == null)
            {
                // Assume our local position should be the transform source's position relative to
                // its parent object.
                obj.transform.localPosition = transformSource.transform.localPosition;
            }
            else
            {
                // Our local position should be the transform source's position relative to
                // our parent object, not their parent object.
                var position = obj.transform.parent.transform.InverseTransformPoint(
                    transformSource.transform.position);
                obj.transform.localPosition = position;
            }

            obj.transform.localRotation = transformSource.transform.localRotation;
        }

        return obj;
    }

    /// <summary>
    /// Finds an existing object by name, renames it, and returns it.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    private GameObject FindGameObject(string name)
    {
        var obj = GameObject.Find(name);
        obj.name = name;
        return obj;
    }
}