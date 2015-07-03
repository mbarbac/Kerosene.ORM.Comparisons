﻿using Kerosene.ORM.Maps;
using Kerosene.Tools;
using System;
using System.Linq;
using Concrete = Kerosene.ORM.Maps.Concrete;

namespace Compare.KRN.Maps.Eager
{
	// ==================================================== 
	public class CountryMap : Concrete.DataMap<Country>
	{
		public CountryMap(IDataRepository repo) : this((Concrete.DataRepository)repo) { }

		public CountryMap(Concrete.DataRepository repo)
			: base(repo, x => x.Countries)
		{
			Members.Add(x => x.Region)
				.WithColumn(x => x.RegionId, col =>
				{
					// We need this column in the record...
					col.OnWriteRecord(obj => { return obj.Region == null ? null : obj.Region.Id; });
				})
				.OnComplete((rec, obj) =>
				{
					obj.Region = Repository.FindNow<Region>(x => x.Id == rec["RegionId"]);
				})
				.SetDependencyMode(MemberDependencyMode.Parent);

			Members.Add(x => x.Employees)
				.OnComplete((rec, obj) =>
				{
					// We just clear the object's member for sanity reasons...
					obj.Employees.Clear();
					obj.Employees.AddRange(Repository.Where<Employee>(x => x.CountryId == obj.Id).ToList());
				})
				.SetDependencyMode(MemberDependencyMode.Child);

			VersionColumn
				.SetName(x => x.RowVersion);
		}
	}
}
