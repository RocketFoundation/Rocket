using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Rocket.API.Extensions
{
	public static class ColorExtension
	{
		public static string ToHex (this Color c)
		{
			return ColorUtility.ToHtmlStringRGB (c);
		}
	}
}
