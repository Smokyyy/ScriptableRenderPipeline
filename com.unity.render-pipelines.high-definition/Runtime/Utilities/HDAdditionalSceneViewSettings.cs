namespace UnityEngine.Rendering.HighDefinition
{
#if UNITY_EDITOR
    using UnityEditor;
    using AntialiasingMode = HDAdditionalCameraData.AntialiasingMode;

    [InitializeOnLoad]
    static class HDAdditionalSceneViewSettings
    {
        static AntialiasingMode s_SceneViewAntialiasing = AntialiasingMode.None;

        public static AntialiasingMode sceneViewAntialiasing
        {
            get => s_SceneViewAntialiasing;
            set => s_SceneViewAntialiasing = value;
        }

        static bool s_SceneViewStopNaNs = false;

        public static bool sceneViewStopNaNs
        {
            get => s_SceneViewStopNaNs;
            set => s_SceneViewStopNaNs = value;
        }

        static HDAdditionalSceneViewSettings()
        {
            SceneViewCameraWindow.additionalSettingsGui += DoAdditionalSettings;
        }

        static void DoAdditionalSettings(SceneView sceneView)
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("HD Render Pipeline", EditorStyles.boldLabel);

            s_SceneViewAntialiasing = (AntialiasingMode)EditorGUILayout.EnumPopup("Camera Anti-aliasing", s_SceneViewAntialiasing);
            if (s_SceneViewAntialiasing == AntialiasingMode.TemporalAntialiasing)
                EditorGUILayout.HelpBox("Temporal Anti-aliasing in the Scene View is only supported when Animated Materials are enabled.", MessageType.Info);

            s_SceneViewStopNaNs = EditorGUILayout.Toggle("Camera Stop NaNs", s_SceneViewStopNaNs);
        }
    }
#endif
}
