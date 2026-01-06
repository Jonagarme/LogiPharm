using System.Drawing;

namespace LogiPharm.Presentacion.Utilidades
{
    /// <summary>
    /// Helper para usar iconos Unicode en Windows Forms
    /// Usa Segoe UI Symbol que está preinstalada en Windows
    /// </summary>
    public static class IconHelper
    {
        // Símbolos Unicode compatibles con Segoe UI Symbol
        public const string IconBox = "??";              // U+1F4E6 Package
        public const string IconExchange = "?";         // U+21C4 Exchange arrows
        public const string IconPlus = "?";            // U+2795 Heavy Plus
        public const string IconTimes = "?";            // U+2716 Heavy Multiplication X
        public const string IconCheck = "?";            // U+2714 Heavy Check Mark
        public const string IconSearch = "??";          // U+1F50D Magnifying glass
        public const string IconList = "??";            // U+1F4CB Clipboard
        public const string IconCog = "?";              // U+2699 Gear
        public const string IconArrowRight = "?";       // U+25B6 Right arrow
        public const string IconClipboard = "??";       // U+1F4CB Clipboard
        public const string IconWarehouse = "??";       // U+1F3E2 Office building
        public const string IconBoxes = "??";           // U+1F4E6 Package
        public const string IconCalendar = "??";        // U+1F4C5 Calendar
        public const string IconBarcode = "?";          // U+25A4 Square
        public const string IconTrash = "??";           // U+1F5D1 Wastebasket
        public const string IconEdit = "?";             // U+270F Pencil
        public const string IconInfo = "?";             // U+2139 Information

        /// <summary>
        /// Obtiene la fuente Segoe UI Symbol para iconos
        /// </summary>
        public static Font GetIconFont(float size = 10f)
        {
            return new Font("Segoe UI Symbol", size, FontStyle.Regular);
        }

        /// <summary>
        /// Obtiene la fuente Segoe UI Emoji para emojis
        /// </summary>
        public static Font GetEmojiFont(float size = 10f)
        {
            return new Font("Segoe UI Emoji", size, FontStyle.Regular);
        }

        /// <summary>
        /// Obtiene un texto con icono para usar en controles
        /// </summary>
        public static string GetIconText(string icon, string text)
        {
            return $"{icon} {text}";
        }
    }
}

