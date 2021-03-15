using System;
using System.IO;
using UnityEditor;

namespace Starship.Editor
{
    public class NamespaceResolver : UnityEditor.AssetModificationProcessor
    {
        //If there would be more than one keyword to replace, add a Dictionary
        public static void OnWillCreateAsset(string metaFilePath)
        {
            var FileName = Path.GetFileNameWithoutExtension(metaFilePath);

            if (!FileName.EndsWith(".cs"))
                return;

            var ActualFile = $"{Path.GetDirectoryName(metaFilePath)}\\{FileName}";
            var SegmentedPath = $"{Path.GetDirectoryName(metaFilePath)}".Split(new[] { '\\' }, StringSplitOptions.None);

            var GeneratedNamespace = "";
            var FinalNamespace = "";

            // In case of placing the class at the root of a folder such as (Editor, Scripts, etc...)  
            if (SegmentedPath.Length <= 2)
                FinalNamespace = EditorSettings.projectGenerationRootNamespace;
            else
            {
                // Skipping the Assets folder and a single subfolder (i.e. Scripts, Editor, Plugins, etc...)
                for (var i = 2; i < SegmentedPath.Length; i++)
                {
                    GeneratedNamespace +=
                        i == SegmentedPath.Length - 1
                            ? SegmentedPath[i]
                            : SegmentedPath[i] + "."; // Don't add '.' at the end of the namespace
                }
                
                FinalNamespace = EditorSettings.projectGenerationRootNamespace + "." + GeneratedNamespace;
            }
            
            var Content = File.ReadAllText(ActualFile);
            var NewContent = Content.Replace("#NAMESPACE#", FinalNamespace);

            if (Content != NewContent)
            {
                File.WriteAllText(ActualFile, NewContent);
                AssetDatabase.Refresh();
            }
        }
    }
}
