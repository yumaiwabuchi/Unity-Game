#if UNITY_EDITOR
using UnityEditor;
[CustomEditor(typeof(MeteoriteController))]
public class HogeObjectEditor : Editor
{
    private MeteoriteController _target;

    private void Awake()
    {
        _target = target as MeteoriteController;
    }

    public override void OnInspectorGUI()
    {
        EditorGUI.BeginChangeCheck();

        _target.EnableMove = EditorGUILayout.ToggleLeft("EnabledMove", _target.EnableMove);
        if (_target.EnableMove)
        {
            EditorGUILayout.LabelField("隕石の動きの設定");
            _target.Setteing.Rotate   = EditorGUILayout.DelayedFloatField ("角度", _target.Setteing.Rotate);
            _target.Setteing.Speed    = EditorGUILayout.DelayedFloatField ("速度", _target.Setteing.Speed);
            _target.Setteing.Rotation = EditorGUILayout.DelayedFloatField ("回転", _target.Setteing.Rotation);
        }

        // GUIの更新があったら実行
        if (EditorGUI.EndChangeCheck())
        {
            EditorUtility.SetDirty(_target);
        }
    }
}
#endif
