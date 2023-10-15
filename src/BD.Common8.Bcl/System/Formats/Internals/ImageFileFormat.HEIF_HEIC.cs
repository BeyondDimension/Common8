#pragma warning disable SA1600 // Elements should be documented

namespace System.Formats.Internals;

partial class ImageFileFormat
{
    /// <summary>
    /// High Efficiency Image File Format
    /// <para>https://en.wikipedia.org/wiki/High_Efficiency_Image_File_Format</para>
    /// <para>https://www.jianshu.com/p/b016d10a087d</para>
    /// <para>https://www.freesion.com/article/5585164728/</para>
    /// </summary>
    public static class HEIF_HEIC
    {
        public static class HEIF
        {
            public const ImageFormat Format = ImageFormat.HEIF;

            public const string DefaultFileExtension = FileEx.HEIF;

            public const string DefaultMIME = MediaTypeNames.HEIF;

            /// <summary>
            /// ftypmif1
            /// </summary>
            public static readonly byte?[] MagicNumber;

            static HEIF()
            {
#pragma warning disable SA1010 // Opening square brackets should be spaced correctly
                MagicNumber = [null, null, null, null, (byte)'f', (byte)'t', (byte)'y', (byte)'p', (byte)'m', (byte)'i', (byte)'f', (byte)'1'];
#pragma warning restore SA1010 // Opening square brackets should be spaced correctly
            }
        }

        public static class HEIFSequence
        {
            public const ImageFormat Format = ImageFormat.HEIFSequence;

            public const string DefaultMIME = MediaTypeNames.HEIFSequence;

            /// <summary>
            /// ftypmsf1
            /// </summary>
            public static readonly byte?[] MagicNumber;

            static HEIFSequence()
            {
#pragma warning disable SA1010 // Opening square brackets should be spaced correctly
                MagicNumber = [null, null, null, null, (byte)'f', (byte)'t', (byte)'y', (byte)'p', (byte)'m', (byte)'s', (byte)'f', (byte)'1'];
#pragma warning restore SA1010 // Opening square brackets should be spaced correctly
            }
        }

        public static class HEIC
        {
            public const ImageFormat Format = ImageFormat.HEIC;

            public const string DefaultFileExtension = FileEx.HEIC;

            public const string DefaultMIME = MediaTypeNames.HEIC;

            public static readonly byte?[]?[] MagicNumber;

            /// <summary>
            /// ftypheic
            /// </summary>
            public static readonly byte?[] MagicNumber1;

            /// <summary>
            /// ftypheix
            /// </summary>
            public static readonly byte?[] MagicNumber2;

            static HEIC()
            {
#pragma warning disable SA1010 // Opening square brackets should be spaced correctly
                MagicNumber1 = [null, null, null, null, (byte)'f', (byte)'t', (byte)'y', (byte)'p', (byte)'h', (byte)'e', (byte)'i', (byte)'c'];
                MagicNumber2 = [null, null, null, null, (byte)'f', (byte)'t', (byte)'y', (byte)'p', (byte)'h', (byte)'e', (byte)'i', (byte)'x'];
#pragma warning restore SA1010 // Opening square brackets should be spaced correctly
                MagicNumber = new[] { MagicNumber1, MagicNumber2 };
            }
        }

        public static class HEICSequence
        {
            public const ImageFormat Format = ImageFormat.HEICSequence;

            public const string DefaultMIME = MediaTypeNames.HEICSequence;

            public static readonly byte?[]?[] MagicNumber;

            /// <summary>
            /// ftyphevc
            /// </summary>
            public static readonly byte?[] MagicNumber1;

            /// <summary>
            /// ftyphevx
            /// </summary>
            public static readonly byte?[] MagicNumber2;

            static HEICSequence()
            {
#pragma warning disable SA1010 // Opening square brackets should be spaced correctly
                MagicNumber1 = [null, null, null, null, (byte)'f', (byte)'t', (byte)'y', (byte)'p', (byte)'h', (byte)'e', (byte)'v', (byte)'c'];
                MagicNumber2 = [null, null, null, null, (byte)'f', (byte)'t', (byte)'y', (byte)'p', (byte)'h', (byte)'e', (byte)'v', (byte)'x'];
#pragma warning restore SA1010 // Opening square brackets should be spaced correctly
                MagicNumber = new[] { MagicNumber1, MagicNumber2 };
            }
        }
    }
}