using LealForms.Examples.StickyNotes;

namespace LealForms.Examples
{
    internal static class Program
    {
        [STAThread]
        internal static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new StickyNotesFormExample());
        }
    }
}