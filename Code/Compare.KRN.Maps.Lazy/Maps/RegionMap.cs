﻿using Kerosene.ORM.Maps;
using Kerosene.Tools;
using System;
using System.Linq;
using Concrete = Kerosene.ORM.Maps.Concrete;

namespace Compare.KRN.Maps.Lazy
{
	// ==================================================== 
	public class RegionMap : Concrete.DataMap<Region>
	{
		public RegionMap(IDataRepository repo) : this((Concrete.DataRepository)repo) { }

		public RegionMap(Concrete.DataRepository repo)
			: base(repo, x => x.Regions)
		{
			Members.Add(x => x.Parent)
				.WithColumn(x => x.ParentId, col =>
				{
					// We need this column in the record...
					col.OnWriteRecord(obj => { return obj.Parent == null ? null : obj.Parent.Id; });
				})
				.OnComplete((rec, obj) =>
				{
					obj.Parent = Repository.FindNow<Region>(x => x.Id == rec["ParentId"]);
				})
				.SetDependencyMode(MemberDependencyMode.Parent);

			Members.Add(x => x.Childs)
				.OnComplete((rec, obj) =>
				{
					// We just clear the object's member for sanity reasons...
					obj.Childs.Clear();
					obj.Childs.AddRange(Repository.Where<Region>(x => x.ParentId == obj.Id).ToList());
				})
				.SetDependencyMode(MemberDependencyMode.Child);

			Members.Add(x => x.Countries)
				.OnComplete((rec, obj) =>
				{
					// We just clear the object's member for sanity reasons...
					obj.Countries.Clear();
					obj.Countries.AddRange(Repository.Where<Country>(x => x.RegionId == obj.Id).ToList());
				})
				.SetDependencyMode(MemberDependencyMode.Child);

			VersionColumn
				.SetName(x => x.RowVersion);
		}
	}
}
