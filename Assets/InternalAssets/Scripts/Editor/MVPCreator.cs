using UnityEditor;
using UnityEngine;
using System.IO;

public class MVPCreator : EditorWindow
{
    private string _baseName = "NewFeature"; // Назва для файлів, яку можна змінювати

    [MenuItem("Tools/Create MVP Scripts")]
    public static void ShowWindow()
    {
        GetWindow<MVPCreator>("Create MVP Scripts");
    }

    void OnGUI()
    {
        GUILayout.Label("MVP Template Generator", EditorStyles.boldLabel);
        _baseName = EditorGUILayout.TextField("Base Name", _baseName);

        if (GUILayout.Button("Generate MVP Scripts"))
        {
            CreateMVPScripts();
        }
    }

    private void CreateMVPScripts()
    {
        // Шлях для збереження файлів
        string path = "Assets/InternalAssets/Scripts/" + _baseName + "/";

        // Створення папки, якщо вона не існує
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }

        // Створення файлів для кожного шаблону
        CreateScript(path, _baseName + "Model.cs", GetModelTemplate());
        CreateScript(path, _baseName + "View.cs", GetViewTemplate());
        CreateScript(path, _baseName + "Presenter.cs", GetPresenterTemplate());
        CreateScript(path, _baseName + "Manager.cs", GetManagerTemplate());

        // Оновлення проекту, щоб Unity розпізнав нові скрипти
        AssetDatabase.Refresh();
    }

    private void CreateScript(string path, string fileName, string content)
    {
        string fullPath = path + fileName;
        if (!File.Exists(fullPath))
        {
            File.WriteAllText(fullPath, content);
            Debug.Log(fileName + " created at " + fullPath);
        }
        else
        {
            Debug.LogWarning(fileName + " already exists at " + fullPath);
        }
    }

    // Шаблони для кожного скрипта
    private string GetModelTemplate()
    {
        return
$@"using UnityEngine;

public class {_baseName}Model
{{
    // Model properties and logic here
}}";
    }

    private string GetViewTemplate()
    {
        return
$@"using UnityEngine;

public class {_baseName}View : MonoBehaviour
{{
    // View components and UI handling here
}}";
    }

    private string GetPresenterTemplate()
    {
        return
$@"using UnityEngine;

public class {_baseName}Presenter
{{
    private {_baseName}Model _model;
    private {_baseName}View _view;

    public {_baseName}Presenter({_baseName}Model model, {_baseName}View view)
    {{
        _model = model;
        _view = view;
    }}

    // Presenter logic here
}}";
    }

    private string GetManagerTemplate()
    {
        return
$@"using UnityEngine;

[RequireComponent(typeof({_baseName}View))]
public class {_baseName}Manager : MonoBehaviour
{{
    private {_baseName}Model _model;
    private {_baseName}View _view;
    private {_baseName}Presenter _presenter;

    public {_baseName}Presenter Presenter => _presenter;

    private void Awake()
    {{
        _model = new {_baseName}Model();
        _view = GetComponent<{_baseName}View>();
        _presenter = new {_baseName}Presenter(_model, _view);
    }}

    // Manager logic here
}}";
    }
}