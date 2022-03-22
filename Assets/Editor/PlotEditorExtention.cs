using UnityEditor;
using UnityEngine;
using System;

public class PlotEditorExtention : Editor
{
    [MenuItem("GameObject/CopyHierarchyPath", false, 10)]
    public static void CopyHierarchyPath()
    {
        if (Selection.transforms == null || Selection.transforms.Length == 0)
            return;

        Transform trans = Selection.transforms[0];
        if (trans == null)
            return;

        string hierarchyPath = string.Empty;
        while(trans != null)
        {
            if(hierarchyPath.Equals(string.Empty))
            {
                hierarchyPath = trans.name;
            }
            else
            {
                hierarchyPath = trans.name + "/" + hierarchyPath;
            }

            trans = trans.parent;
        }

        GUIUtility.systemCopyBuffer = hierarchyPath;
    }
}
