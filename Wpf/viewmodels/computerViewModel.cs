using cmp;

namespace win.viewmodels
{
    public class computerViewModel
    {
        private Cmp _cmp;

        public computerViewModel(Cmp cmp)
        {
            _cmp = cmp;
        }

        public string Cpu { get { return _cmp.Cpu; } }
        public string Mb { get { return _cmp.Mb; } }
        public string Ram { get { return _cmp.Ram; } }
        public string User { get { return _cmp.User; } }
    }
}
