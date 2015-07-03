using Kerosene.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compare.EF.EagerMode
{
	// ==================================================== 
	public class Country
	{
		public byte[] RowVersion { get; set; }
		public string Id { get; set; }
		public string Name { get; set; }
		public string RegionId { get; set; }

		public Region Region { get; set; }
		public List<Employee> Employees { get; set; }

		public Country()
		{
			Employees = new List<Employee>();
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder("{");
			sb.AppendFormat("Id={0}", Id ?? string.Empty);
			if (Name != null) sb.AppendFormat(", Name={0}", Name);
			if (RegionId != null) sb.AppendFormat(", RegionId={0}", RegionId);
			if (RowVersion != null) sb.AppendFormat(", RowVersion={0}", RowVersion.Sketch());
			sb.Append("}"); return sb.ToString();
		}
	}
}
