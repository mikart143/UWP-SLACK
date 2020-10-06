using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using InwentarzRzeczowy.UWP.Helpers;
using ReactiveUI;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.PixelFormats;

namespace InwentarzRzeczowy.UWP.Converters
{
    public class BitmapImageConverter: IBindingTypeConverter
    {
        public int GetAffinityForObjects(Type fromType, Type toType)
        {
            if (fromType.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>)))
            {
                return 100;
            }
            else
            {
                return 0;
            }
        }

        public bool TryConvert(object? @from, Type toType, object? conversionHint, out object? result)
        {
            if (from is null)
            {
                result = null;
                return false;
            }

            if (from.GetType().GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>)))
            {
                //TODO: Fix casting (white images)
                var fromCast = (IEnumerable<Image>)from;
                var outImages = new List<ImageTemplateWrapper>();
                foreach (var image in fromCast)
                {
                    var _IMemoryGroup = image.CloneAs<Rgba32>().GetPixelMemoryGroup();
                    var _MemoryGroup = _IMemoryGroup.ToArray()[0];
                    var PixelData = MemoryMarshal.AsBytes(_MemoryGroup.Span).ToArray();
                    var toImage = new WriteableBitmap(image.Width, image.Height);
                    var stream = new InMemoryRandomAccessStream();
                    stream.WriteAsync(PixelData.AsBuffer()).GetResults();
                    stream.Seek(0);
                    toImage.SetSource(stream);
                    outImages.Add(new ImageTemplateWrapper()
                    {
                        Thumbnail = toImage
                    });
                }
                
                result = outImages;
            }
            else
            {
                result = null;
                return false;
            }

            return true;
        }
    }
}