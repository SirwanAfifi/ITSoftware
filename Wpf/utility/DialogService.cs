using System.Windows;
using Wpf.views;

namespace Wpf.utility
{
    public class DialogService
    {
        Window detailView = null;

        public void ShowDialog()
        {
            detailView = new PersonDetailView();
            detailView.ShowDialog();
        }

        public void CloseDialog()
        {
            if (detailView != null)
                detailView.Close();
        }
    }
}
