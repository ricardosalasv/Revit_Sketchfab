using System.Windows.Media.Imaging;

namespace Revit_Sketchfab_Resources
{
    /// <summary>
    /// Gets the embedded resource image from the Revit_Sketchfab_Resources assembly based on user provided file name with extension.
    /// Helper methods.
    /// </summary>
    public static class ResourceImage
    {
        /// <summary>
        /// Gets the icon image from resource assembly by specified name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static BitmapImage GetIcon(string name)
        {
            // Create the resource reader stream
            var stream = ResourceAssembly.GetAssembly().GetManifestResourceStream(ResourceAssembly.GetNamespace() + "Images.Icons." + name);

            var image = new BitmapImage();

            // Construct and return the image itself
            image.BeginInit();
            image.StreamSource = stream;
            image.EndInit();

            // Return constructed BitmapImage
            return image;
        }
    }
}
