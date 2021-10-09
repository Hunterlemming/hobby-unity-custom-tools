using UnityEditor;
using UnityEngine;

using static System.IO.Directory;
using static System.IO.Path;

namespace hunterlemming
{
	public static class ToolsMenu
	{

		[MenuItem("Tools/Setup/Create Default Folders/Base Project")]
		public static void CreateBaseProjectFolderStructure()
		{
			CreateDefaultFolders(0);
		}
		
		[MenuItem("Tools/Setup/Create Default Folders/Default Project")]
		public static void CreateDefaultProjectFolderStructure()
		{
			CreateDefaultFolders(1);
		}

		[MenuItem("Tools/Setup/Create Default Folders/Full Project")]
		public static void CreateFullProjectFolderStructure()
		{
			CreateDefaultFolders(1000);
		}
		
		private static void CreateDefaultFolders(int depth)
		{
			CreateDirectories("_Project", "Scripts", "Art", "Scenes", "Prefabs", "Audio");

			if (1 <= depth)
			{
				CreateDirectories("_Project.Scripts", "Editor", "Effects", "Game");
				CreateDirectories("_Project.Art", "Animations", "Models", "Materials");
				CreateDirectories("_Project.Prefabs", "Environment", "Characters", "VFX", "UI", "Utils");
				CreateDirectories("_Project.Audio", "AudioClips", "Mixers");
			}

			if (2 <= depth)
			{
				// Art
				CreateDirectories("_Project.Art.Animations", "AnimationClips", "Animators", "Avatar Masks");
				CreateDirectories("_Project.Art.Materials", "Characters", "Effects", "PhysicsMaterials");
				CreateDirectories("_Project.Art.Models", "Characters", "Effects");
				
				// Prefabs
				CreateDirectories("_Project.Prefabs.Environment", "Building Blocks", "Intractables");
				CreateDirectories("_Project.Prefabs.Utils", "Camera", "SceneControl");
				
				// Audio
				CreateDirectories("_Project.Audio.AudioClips", "Environment", "Characters", "UI");
			}
			
			AssetDatabase.Refresh();
		}

		#region CreateDictionaries

		/// <summary>
		/// Creates directories in a root folder, located by a string.
		/// </summary>
		/// <param name="root">Relative route to the root folder</param>
		/// <param name="dirNames">Directories to create in the root folder</param>
		private static void CreateDirectories(string root, params string[] dirNames)
		{
			CreateDirectories(root, '.', dirNames);
		}
		
		/// <summary>
		/// Creates directories in a root folder, located by a string.
		/// </summary>
		/// <param name="root">Relative route to the root folder</param>
		/// <param name="separator">Custom delimiting character to split the string by (default separator = '.')</param>
		/// <param name="dirNames">Directories to create in the root folder</param>
		private static void CreateDirectories(string root, char separator, params string[] dirNames)
		{
			var altRootDescription = root.Split(separator);
			CreateDirectories(altRootDescription, dirNames);
		}

		/// <summary>
		/// Creates directories in a root folder, located by an array of strings.
		/// </summary>
		/// <param name="root">Relative route to the root folder</param>
		/// <param name="dirNames">Directories to create in the root folder</param>
		private static void CreateDirectories(string[] root, params string[] dirNames)
		{
			var relativePath = Combine(root);
			var fullPath = Combine(Application.dataPath, relativePath);
			
			foreach (var directory in dirNames)
			{
				CreateDirectory(Combine(fullPath, directory));
			}
		}

		#endregion
		
	}
}
