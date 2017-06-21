using Rocket.API.Providers.Translations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Rocket.API.Extensions
{
	public static class StringExtension
	{
		public static string Format (this string s, params object [] args)
		{
			for (int i = 0; i < args.Length; i++)
			{
				var regex = new Regex (Regex.Escape ("{}"));
				s = regex.Replace (s, args [i].ToString (), 1);
				s = s.Replace ("{" + i.ToString () + "}", args [i].ToString ());
			}
			return s;
		}

		public static string Append (this string s, params object [] args)
		{
			return (s + String.Format (" ", args.Select (a => a.ToString ()))).Trim ();
		}

		public static Color ToColor (this string s, Color fallback)
		{
			s = s.Trim ();
			Color color = fallback;
			if (Regex.IsMatch (s, @"[a-fA-F0-9]{3,6}|") && ColorUtility.TryParseHtmlString (Regex.Match (s, @"[a-fA-F0-9]{6}").Value, out color))
				return color;
			if (Regex.IsMatch (s, @"[0-255]+ [0-255]+ [0-255]+"))
			{
				var rgb = Regex.Match (s, @"[0-255]+ [0-255]+ [0-255]+").Value.Split (' ').Select (c => (float)(int.Parse (c) / 255)).ToArray ();
				return new Color (rgb [0], rgb [1], rgb [2]);
			}
			switch (s.ToLower ())
			{
				case "black":
					return Color.black;
				case "blue":
					return Color.blue;
				case "cyan":
					return Color.cyan;
				case "gray":
					return Color.gray;
				case "green":
					return Color.green;
				case "grey":
					return Color.grey;
				case "magenta":
					return Color.magenta;
				case "red":
					return Color.red;
				case "white":
					return Color.white;
				case "yellow":
					return Color.yellow;
				case "purple":
					return new Color (155 / 255, 48 / 255, 1);
				case "orange":
					return new Color (1, 165 / 255, 0);
			}
			return fallback;
		}
	}
}
