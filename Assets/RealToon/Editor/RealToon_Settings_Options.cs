//RealToonGUI
//MJQStudioWorks
//©2025

using UnityEngine;
using UnityEditor;
using System;

namespace RealToon.SettingsOptions
{

    internal class RTToggleOption : MaterialPropertyDrawer
    {

        public override void OnGUI(Rect position, MaterialProperty prop, GUIContent label, MaterialEditor editor)
        {

            bool value = (prop.floatValue != 0.0f);

            EditorGUI.BeginChangeCheck();
            EditorGUI.showMixedValue = prop.hasMixedValue;

            value = EditorGUI.Toggle(position, label, value);

            EditorGUI.showMixedValue = false;
            if (EditorGUI.EndChangeCheck())
            {

                prop.floatValue = value ? 1.0f : 0.0f;

            }

        }

    }

}