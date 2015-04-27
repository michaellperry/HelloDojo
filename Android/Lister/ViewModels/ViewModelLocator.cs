using System;

namespace Lister
{
	public class ViewModelLocator
	{
		private static ViewModelLocator _instance = new ViewModelLocator();
		private readonly AddressBook _addressBook = new AddressBook();
		private readonly PersonSelection _personSelection = new PersonSelection();
		private ViewModelLocator ()
		{
		}

		public static ViewModelLocator Instance{get{ return _instance;}}

		public AddressBookViewModel Main
		{
			get
			{ 
				return new AddressBookViewModel (_addressBook, _personSelection);
			}
		}

		public PersonDetailViewModel Detail
		{
			get
			{ 
				if (_personSelection.SelectedPerson == null)
					return null;
				return new PersonDetailViewModel (_personSelection.SelectedPerson);
			}
		}
	}
}

