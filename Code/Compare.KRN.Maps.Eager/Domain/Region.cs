﻿using Kerosene.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compare.KRN.Maps.Eager
{
	// ==================================================== 
	public class Region
	{
		object RowVersion = null;
		public string Id { get; set; }
		public string Name { get; set; }
		public Region Parent { get; set; }
		public List<Region> Childs { get; set; }
		public List<Country> Countries { get; set; }

		public Region()
		{
			Childs = new List<Region>();
			Countries = new List<Country>();
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder("{");
			sb.AppendFormat("Id={0}", Id ?? string.Empty);
			if (Name != null) sb.AppendFormat(", Name={0}", Name);
			if (Parent != null) sb.AppendFormat(", Parent={0}", Parent.Id);
			if (Childs.Count != 0) sb.AppendFormat(", Childs={0}", Childs.Select(x => x.Id).Sketch());
			if (Countries.Count != 0) sb.AppendFormat(", Countries={0}", Countries.Select(x => x.Id).Sketch());
			if (RowVersion != null) sb.AppendFormat(", RowVersion={0}", RowVersion.Sketch());
			sb.Append("}"); return sb.ToString();
		}
	}
}
