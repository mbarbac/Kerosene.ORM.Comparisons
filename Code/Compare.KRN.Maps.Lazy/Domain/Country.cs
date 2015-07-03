using Kerosene.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compare.KRN.Maps.Lazy
{
	// ==================================================== 
	public class Country
	{
		object RowVersion = null;
		public string Id { get; set; }
		public string Name { get; set; }
		virtual public Region Region { get; set; }
		virtual public List<Employee> Employees { get; set; }

		public Country()
		{
			Employees = new List<Employee>();
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder("{");
			sb.AppendFormat("Id={0}", Id ?? string.Empty);
			if (Name != null) sb.AppendFormat(", Name={0}", Name);
			if (Region != null) sb.AppendFormat(", Region={0}", Region.Id);
			if (Employees.Count != 0) sb.AppendFormat(", Employees={0}", Employees.Select(x => x.Id).Sketch());
			if (RowVersion != null) sb.AppendFormat(", RowVersion={0}", RowVersion.Sketch());
			sb.Append("}"); return sb.ToString();
		}
	}
}
