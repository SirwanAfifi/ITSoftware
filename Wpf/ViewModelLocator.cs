using Wpf.viewmodels;

namespace Wpf
{
    public class ViewModelLocator
    {
        private static PeopleListViewModel peopleListViewModel
            = new PeopleListViewModel();

        public static PeopleListViewModel PeopleListViewModel
        {
            get
            {
                return peopleListViewModel;
            }
        }
    }
}