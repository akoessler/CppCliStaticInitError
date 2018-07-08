using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagedUtilsLibrary
{
	public class DtoFactory
	{
		public Dto CreateDto(int data)
		{
			return new Dto(42);
		}
	}
}
