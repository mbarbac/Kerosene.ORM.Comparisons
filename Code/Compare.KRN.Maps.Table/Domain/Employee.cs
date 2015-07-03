﻿using Kerosene.Tools;
using System;
using System.Linq;
using System.Text;

namespace Compare.KRN.Maps.Table
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
		public string ManagerId { get; set; }
		public string CountryId { get; set; }
		public CalendarDate JoinDate { get; set; }
		public ClockTime StartTime { get; set; }
		public byte[] Photo { get; set; }

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder("{");
			sb.AppendFormat("Id={0}", Id ?? string.Empty);
			if (FirstName != null) sb.AppendFormat(", FirstName={0}", FirstName);
			if (LastName != null) sb.AppendFormat(", LastName={0}", LastName);
			if (BirthDate != null) sb.AppendFormat(", BirthDate={0}", BirthDate);
			if (Active != null) sb.AppendFormat(", Active={0}", Active);
			if (ManagerId != null) sb.AppendFormat(", ManagerId={0}", ManagerId);
			if (CountryId != null) sb.AppendFormat(", CountryId={0}", CountryId);
			if (JoinDate != null) sb.AppendFormat(", JoinDate={0}", JoinDate);
			if (StartTime != null) sb.AppendFormat(", StartTime={0}", StartTime);
			if (Photo != null) sb.AppendFormat(", Photo={0}", Photo.Sketch());
			if (RowVersion != null) sb.AppendFormat(", RowVersion={0}", RowVersion.Sketch());
			sb.Append("}"); return sb.ToString();
		}
	}
}
