using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace System
{
	public class INI
	{
		public static void Write(string INIValue, string INIAttribute, string INICategory = "[DEFAULT]", string INIFileLocation = "config.ini")
		{
			string CategoryLine;
			string AttributeLine;
			string attribute;
			string value;
			int linenumber = 0;

			if (!File.Exists(INIFileLocation))
			{
				using (StreamWriter INIWriter = new StreamWriter(INIFileLocation))
				{
					INIWriter.WriteLine(INICategory);
					INIWriter.WriteLine("{0}={1}", INIAttribute, INIValue);
					INIWriter.Flush();
				}
			}

			foreach (string line in File.ReadLines(INIFileLocation))
			{
				++linenumber;
				while (line != null)
				{
					if (line == INICategory)
					{
						Console.WriteLine("Category {0} found, looking for attribute...", INICategory);
						foreach (string attributeline in File.ReadLines(INIFileLocation))
						{

						}
					}
				}
			}
		}

		public static string Load(string INIAttribute, string INICategory = "[DEFAULT]", string INIFileLocation = "config.ini")
		{
			string CategoryLine;
			string AttributeLine;
			string attribute;
			string value;

			if (!File.Exists(INIFileLocation))
				return "missing ini file " + INIFileLocation;
			using (StreamReader INIReader = new StreamReader(INIFileLocation))
			{
				while ((CategoryLine = INIReader.ReadLine()) != null)
				{
					if (CategoryLine == INICategory)
					{
						while ((AttributeLine = INIReader.ReadLine()) != null)
						{
							if (AttributeLine.Contains('[') | AttributeLine == null)
								break;
							attribute = AttributeLine.Split('=')[0];
							value = AttributeLine.Substring(AttributeLine.IndexOf('=') + 1);
							if (attribute == INIAttribute)
								if (value.StartsWith("\"") | value.EndsWith("\""))
									return value.Trim('"');
								else
									return value;
						}
					}
				}
			}
			return null;
		}
	}
}
