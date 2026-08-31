namespace Duniverse.Web.Services
{
    /// <summary>
    /// One bit of page context: whether the reader is standing in the open sand. The
    /// desert raises it while mounted and the reading ritual holds off, since asking how
    /// far someone has read makes a poor greeting on a page that says nothing is here.
    /// The catch-all route means no path test can know this; only the desert itself can.
    /// </summary>
    public sealed class LostPageSignal
    {
        public bool Active { get; private set; }

        public event Action? Changed;

        public void Set(bool active)
        {
            if (Active == active)
            {
                return;
            }

            Active = active;
            Changed?.Invoke();
        }
    }
}
