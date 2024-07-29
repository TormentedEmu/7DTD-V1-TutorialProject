    using UnityEditor;
    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
	
    public static class AssetPathToCopy {
      private static string GetPath(GameObject go) {

          if (go == null) {
            return "";
          }

          var path = go.name;

          while (go.transform.parent != null) {
            go = go.transform.parent.gameObject;
            path = string.Format("/{0}/{1}", go.name, path);
            path = path.Replace("//", "/");
          }
          return path;
        }
        [MenuItem("GameObject/Copy Path", false, 35)]
      private static void CopyPath() {
          var go = Selection.activeGameObject;
          EditorGUIUtility.systemCopyBuffer = GetPath(go);
        }
        [MenuItem("GameObject/Generate PhysicsBody", false, 34)]
      private static void GeneratePhysicsBody() {
          var go = Selection.activeGameObject;
          var tocopy = "<body name=\"" + go.transform.root.gameObject.name + "\"><collider>\n" + "<property name=\"tag\" value=\"" + go.tag + "\"/>\n" + "<property name=\"path\" value=\"" + go.name + "\"/>\n<property name=\"collisionLayer\" value=\"0\"/>\n<property name=\"ragdollLayer\" value=\"0\"/>\n<property name=\"collisionScale\" value=\"1 1 1\"/>\n<property name=\"ragdollScale\" value=\"1 1 1\"/>\n<property name=\"collisionOffset\" value=\"0 0 0\"/>\n<property name=\"ragdollOffset\" value=\"0 0 0\"/>\n<property name=\"type\" value=\"Detail\"/>\n<property name=\"flags\" value=\"collision;ragdoll\"/>\n</collider>\n";

          if (go == null) {
            return;
          }

          foreach(CharacterJoint child in go.GetComponentsInChildren < CharacterJoint > ()) {
            var subpath = GetPath(child.transform.gameObject);
            subpath = subpath.Substring(subpath.IndexOf(go.name));
            tocopy = tocopy + "<collider>\n" + "<property name=\"tag\" value=\"" + child.gameObject.tag + "\"/>\n" + "<property name=\"path\" value=\"" + subpath + "\"/>\n<property name=\"collisionLayer\" value=\"0\"/>\n<property name=\"ragdollLayer\" value=\"0\"/>\n<property name=\"collisionScale\" value=\"1 1 1\"/>\n<property name=\"ragdollScale\" value=\"1 1 1\"/>\n<property name=\"collisionOffset\" value=\"0 0 0\"/>\n<property name=\"ragdollOffset\" value=\"0 0 0\"/>\n<property name=\"type\" value=\"Detail\"/>\n<property name=\"flags\" value=\"collision;ragdoll\"/>\n</collider>\n";
          }
          EditorGUIUtility.systemCopyBuffer = tocopy + "</body>\n";
        }
		
        [MenuItem("GameObject/Rename Mixamo", false, 21)]
		  private static void RenameMixamo() {
			var go = Selection.activeGameObject;
			var mixamobase = "mixamorig:";
			if (go == null) {
			  return;
			}

			foreach(Transform child in go.GetComponentsInChildren < Transform > ()) {
			  child.gameObject.name = child.gameObject.name.Replace(mixamobase, "");
			}
		  }
	  
	  
		[MenuItem("GameObject/Tag Bones", false, 33)]
			private static void TagBones()
			{
				var go = Selection.activeGameObject;
				if (go == null)
					return;

				go.AddComponent<MixamoTagBones>();
			}


	    [MenuItem("GameObject/Add Children", false, 22)]
			private static void CreateChildren()
			{
				var go = Selection.activeGameObject;
				if (go == null)
					return;

				go.AddComponent<MixamoCreateStructure>();
			}	  
			
	  

      [MenuItem("GameObject/Copy Path", true, 0)]
      private static bool CopyPathValidation() {
        // We can only copy the path in case 1 object is selected
        return Selection.gameObjects.Length == 1;
      }
    }