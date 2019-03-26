using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glass_Size_Estimator
{
	// This class was implemented to supply helper functions that retrieve enum from different categories after being given a string
	class EnumFactory
	{
		// Return an enum based on the given string value and category
		public static Object GetEnum(string value, string category)
		{
			switch (category)
			{
				case "WallJamb":
					return GetWallJamb(value);
				case "Configuration":
					return GetConfiguration(value);
				case "Series":
					return GetSeries(value);
				case "GlassType":
					return GetGlassType(value);
				default:
					return null;
			}
		}

		// Return a wall jamb enum
		private static Object GetWallJamb(string wallJamb)
		{
			switch (wallJamb)
			{
				case "ZD1028":
					return WallJamb.ZD1028;
				case "ZD1006":
					return WallJamb.ZD1006;
				default:
					return null;
			}
		}

		// Return a configuration enum
		private static Object GetConfiguration(string configuration)
		{
			switch (configuration)
			{
				case "NEO_PANEL":
					return Configuration.NEO_PANEL;
				case "NOTCHED_INLINE_PANEL":
					return Configuration.NOTCHED_INLINE_PANEL;
				case "ONE_INLINE_PANEL":
					return Configuration.ONE_INLINE_PANEL;
				case "RETURN_PANEL_135_DEGREE":
					return Configuration.RETURN_PANEL_135_DEGREE;
				case "RETURN_PANEL_90_DEGREE":
					return Configuration.RETURN_PANEL_90_DEGREE;
				case "TWO_INLINE_PANEL":
					return Configuration.TWO_INLINE_PANEL;
				case "TWO_PARTIAL_INLINE_PANEL":
					return Configuration.TWO_PARTIAL_INLINE_PANEL;
				default:
					return null;
			}
		}

		// Return a series enum
		private static Object GetSeries(string series)
		{
			switch (series)
			{
				case "ASE":
					return Series.ASE;
				case "ATE":
					return Series.ATE;
				case "ESE":
					return Series.ESE;
				case "ETE":
					return Series.ETE;
				case "HASE":
					return Series.HASE;
				case "HATE":
					return Series.HATE;
				case "HGSE":
					return Series.HGSE;
				case "HGTE":
					return Series.HGTE;
				case "LESE":
					return Series.LESE;
				case "LETE":
					return Series.LETE;
				case "PRESE":
					return Series.PRESE;
				case "PRETE":
					return Series.PRETE;
				case "PSE":
					return Series.PSE;
				case "PTE":
					return Series.PTE;
				case "PTESE":
					return Series.PTESE;
				case "PTETE":
					return Series.PTETE;
				case "SE":
					return Series.SE;
				case "TE":
					return Series.TE;
				case "TESE":
					return Series.TESE;
				case "TETE":
					return Series.TETE;
				case "TSE":
					return Series.TSE;
				case "TTE":
					return Series.TTE;
				default:
					return null;
			}
		}

		// Return a glass type enum
		private static Object GetGlassType(string glassType)
		{
			switch (glassType)
			{
				case "CLEAR":
					return GlassType.CLEAR;
				case "RAIN":
					return GlassType.RAIN;
				case "P5":
					return GlassType.P5;
				default:
					return null;
			}
		}
	}
}
