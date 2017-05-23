﻿using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Leap.Unity.Examples {

  [CustomEditor(typeof(WorkstationBehaviourExample))]
  public class WorkstationBehaviourEditor : CustomEditorBase<WorkstationBehaviourExample> {

    public override void OnInspectorGUI() {
      EditorGUI.BeginDisabledGroup(target.workstationModeTween == null
                                   || target.workstationModeTween.targetTransform == null
                                   || target.workstationModeTween.startTransform == null
                                   || target.workstationModeTween.endTransform == null
                                   || PrefabUtility.GetPrefabType(target.gameObject) == PrefabType.Prefab);

      EditorGUILayout.BeginHorizontal();

      if (GUILayout.Button(new GUIContent("Open Workstation",
                                          "If the workstationModeTween is fully configured, you can "
                                        + "press this to set the target transform to the end (open) "
                                        + "state."))) {
        Undo.IncrementCurrentGroup();
        Undo.SetCurrentGroupName("Open Workstation");
        Undo.RecordObject(target.workstationModeTween.targetTransform, "Move Target To End");
        target.workstationModeTween.SetTargetToEnd();
      }

      if (GUILayout.Button(new GUIContent("Close Workstation",
                                          "If the workstationModeTween is fully configured, you can "
                                        + "press this button to set the target transform to the start "
                                        + "(closed) state."))) {
        Undo.IncrementCurrentGroup();
        Undo.SetCurrentGroupName("Close Workstation");
        Undo.RecordObject(target.workstationModeTween.targetTransform, "Move Target To Start");
        target.workstationModeTween.SetTargetToStart();
      }

      EditorGUILayout.EndHorizontal();

      EditorGUI.EndDisabledGroup();

      base.OnInspectorGUI();
    }

  }

}