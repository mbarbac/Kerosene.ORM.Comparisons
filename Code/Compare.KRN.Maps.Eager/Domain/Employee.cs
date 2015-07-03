using Kerosene.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compare.KRN.Maps.Eager
{
	// ==================================================== 
	public class Employee
	{
		object RowVersion = null;
		public string Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public CalendarDate BirthDate { get; set; }
		public bool? Active { get; set; }
		public Employee Manager { get; set; }
		public List<Employee> Employees { get; set; }
		public Country Country { get; set; }
		public CalendarDate JoinDate { get; set; }
		public ClockTime StartTime { get; set; }
		public byte[] Photo { get; set; }

		public Employee()
		{
			Employees = new List<Employee>();
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder("{");
			sb.AppendFormat("Id={0}", Id ?? string.Empty);
			if (FirstName != null) sb.AppendFormat(", FirstName={0}", FirstName);
			if (LastName != null) sb.AppendFormat(", LastName={0}", LastName);
			if (BirthDate != null) sb.AppendFormat(", BirthDate={0}", BirthDate);
			if (Active != null) sb.AppendFormat(", Active={0}", Active);
			if (Manager != null) sb.AppendFormat(", Manager={0}", Manager.Id);
			if (Employees.Count != 0) sb.AppendFormat(", Employees={0}", Employees.Select(x => x.Id).Sketch());
			if (Country != null) sb.AppendFormat(", Country={0}", Country.Id);
			if (JoinDate != null) sb.AppendFormat(", JoinDate={0}", JoinDate);
			if (StartTime != null) sb.AppendFormat(", StartTime={0}", StartTime);
			if (Photo != null) sb.AppendFormat(", Photo={0}", Photo.Sketch());
			if (RowVersion != null) sb.AppendFormat(", RowVersion={0}", RowVersion.Sketch());
			sb.Append("}"); return sb.ToString();
		}
	}
}
