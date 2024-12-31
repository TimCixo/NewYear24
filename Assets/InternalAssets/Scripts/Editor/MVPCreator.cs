using UnityEditor;
using UnityEngine;
using System.IO;

public class MVPCreator : EditorWindow
{
    private string _baseName = "NewFeature"; // Назва для файлів, яку можна змінювати
    private string _path = "Assets/InternalAssets/Scripts";

    [MenuItem("Assets/Create/MVP Module", false, 0)]
    public static void ShowWindow()
    {
        GetWindow<MVPCreator>("Create MVP Module");
    }

    void OnGUI()
    {
        GUILayout.Label("MVP Template Generator", EditorStyles.boldLabel);
        
        _baseName = EditorGUILayout.TextField("Base Name", _baseName);
        _path = EditorGUILayout.TextField("Path", AssetDatabase.GetAssetPath(Selection.activeObject));

        if (GUILayout.Button("Generate MVP Module"))
        {
            CreateMVPScripts();
        }
    }

    private void CreateMVPScripts()
    {
        // Шлях для збереження файлів
        _path += $"/{_baseName}/";

        // Створення папки, якщо вона не існує
        if (!Directory.Exists(_path))
        {
            Directory.CreateDirectory(_path);
        }

        // Створення файлів для кожного шаблону
        CreateScript(_path, _baseName + "Model.cs", GetModelTemplate());
        CreateScript(_path, _baseName + "View.cs", GetViewTemplate());
        CreateScript(_path, _baseName + "Presenter.cs", GetPresenterTemplate());
        CreateScript(_path, _baseName + "Manager.cs", GetManagerTemplate());

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

[RequireComponent(typeof({_baseName}View), typeof(Bootstrap))]
public class {_baseName}Manager : MonoBehaviour, IBootstrapable
{{
    private {_baseName}Model _model;
    private {_baseName}View _view;
    private {_baseName}Presenter _presenter;

    public {_baseName}Presenter Presenter => _presenter;

    public void BootstrapInit()
    {{
        _model = new {_baseName}Model();

        ModelInit();

        _view = GetComponent<{_baseName}View>();
        _presenter = new {_baseName}Presenter(_model, _view);
    }}

    private void ModelInit()
    {{
        // Manager model initialization here
    }}

    // Manager logic here
}}";
    }
}