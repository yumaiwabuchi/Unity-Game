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
            EditorGUILayout.LabelField("覐΂̓����̐ݒ�");
            _target.Setteing.Rotate   = EditorGUILayout.DelayedFloatField ("�p�x", _target.Setteing.Rotate);
            _target.Setteing.Speed    = EditorGUILayout.DelayedFloatField ("���x", _target.Setteing.Speed);
            _target.Setteing.Rotation = EditorGUILayout.DelayedFloatField ("��]", _target.Setteing.Rotation);
        }

        // GUI�̍X�V������������s
        if (EditorGUI.EndChangeCheck())
        {
            EditorUtility.SetDirty(_target);
        }
    }
}
#endif
