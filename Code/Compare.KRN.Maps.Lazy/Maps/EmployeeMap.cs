using Kerosene.ORM.Maps;
using Kerosene.Tools;
using System;
using System.Linq;
using Concrete = Kerosene.ORM.Maps.Concrete;

namespace Compare.KRN.Maps.Lazy
{
	// ==================================================== 
	public class EmployeeMap : Concrete.DataMap<Employee>
	{
		public EmployeeMap(IDataRepository repo) : this((Concrete.DataRepository)repo) { }

		public EmployeeMap(Concrete.DataRepository repo)
			: base(repo, x => x.Employees)
		{
			Members.Add(x => x.Manager)
				.WithColumn(x => x.ManagerId, col =>
				{
					// We need this column in the record...
					col.OnWriteRecord(obj => { return obj.Manager == null ? null : obj.Manager.Id; });
				})
				.OnComplete((rec, obj) =>
				{
					obj.Manager = Repository.FindNow<Employee>(x => x.Id == rec["ManagerId"]);
				})
				.SetDependencyMode(MemberDependencyMode.Parent);

			Members.Add(x => x.Country)
				.WithColumn(x => x.CountryId, col =>
				{
					// We need this column in the record...
					col.OnWriteRecord(obj => { return obj.Country == null ? null : obj.Country.Id; });
				})
				.OnComplete((rec, obj) =>
				{
					obj.Country = Repository.FindNow<Country>(x => x.Id == rec["CountryId"]);
				})
				.SetDependencyMode(MemberDependencyMode.Parent);

			Members.Add(x => x.Employees)
				.OnComplete((rec, obj) =>
				{
					// We just clear the object's member for sanity reasons...
					obj.Employees.Clear();
					obj.Employees.AddRange(Repository.Where<Employee>(x => x.ManagerId == obj.Id).ToList());
				})
				.SetDependencyMode(MemberDependencyMode.Child);

			VersionColumn
				.SetName(x => x.RowVersion);
		}
	}
}
