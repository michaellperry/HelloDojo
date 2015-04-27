using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lister
{
	public class PersonDetailViewModel 
	{
		private readonly Person _person;
		private readonly PersonEdit _personEdit;
		public PersonDetailViewModel(Person person)
		{
			_person = person;
			_personEdit = new PersonEdit (){ Name = _person.Name};
		}

		public string Name
		{
			get{ return _personEdit.Name; }
			set{ _personEdit.Name = value;}
		}

		public void Save()
		{
			_person.Name = _personEdit.Name;
		}

		public void Discard()
		{
			_personEdit.Name = _person.Name;
		}
	}
}

