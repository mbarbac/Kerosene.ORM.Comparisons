using Kerosene.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compare.EF.EagerMode
{
	// ==================================================== 
	public class Region
	{
		public byte[] RowVersion { get; set; }
		public string Id { get; set; }
		public string Name { get; set; }
		public string ParentId { get; set; }

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
			if (ParentId != null) sb.AppendFormat(", ParentId={0}", ParentId);
			if (RowVersion != null) sb.AppendFormat(", RowVersion={0}", RowVersion.Sketch());
			sb.Append("}"); return sb.ToString();
		}
	}
}
