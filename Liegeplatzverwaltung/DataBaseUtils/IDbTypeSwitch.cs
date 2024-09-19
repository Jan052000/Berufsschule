using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liegeplatzverwaltung.DataBaseUtils
{
	public interface IDbTypeSwitch
	{
		string GetDBType(Type type);
	}
}
