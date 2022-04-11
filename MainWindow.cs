using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace svc01
{
    public class MainWindow : Window
    {
        [UI] private readonly Label label1;
        [UI] private readonly Button button1;

        private int counter;
        private readonly ILogger logger;

        public MainWindow(ILogger<MainWindow> _logger) : this(new Builder("MainWindow.glade")) {
            logger = _logger;
        }

        private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
        {
            builder.Autoconnect(this);

            DeleteEvent += Window_DeleteEvent;
            button1.Clicked += Button1_Clicked;
        }

        private void Window_DeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
        }

        private void Button1_Clicked(object sender, EventArgs a)
        {
            counter++;
            label1.Text = "Hello World! This button has been clicked " + counter + " time(s).";
            logger.LogInformation(label1.Text);
        }
    }
}
