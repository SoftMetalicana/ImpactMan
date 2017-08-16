namespace ImpactMan.IO.Recording
{
    using SharpAvi;
    using SharpAvi.Codecs;
    using SharpAvi.Output;

    public class RecorderParams
    {
        private readonly int framesPerSecond, quality;
        private readonly string fileName;
        private readonly FourCC codec;

        public RecorderParams(string filename, int frameRate, FourCC encoder, int quality)
        {
            this.fileName = filename;
            this.framesPerSecond = frameRate;
            this.codec = encoder;
            this.quality = quality;

            this.Height = Constants.Graphics.GraphicsConstants.PreferredBufferHeight;
            this.Width = Constants.Graphics.GraphicsConstants.PreferredBufferWidth;
        }

        public int Height { get; private set; }

        public int Width { get; private set; }

        public AviWriter CreateAviWriter()
        {
            return new AviWriter(this.fileName)
            {
                FramesPerSecond = this.framesPerSecond,
                EmitIndex1 = true,
            };
        }

        public IAviVideoStream CreateVideoStream(AviWriter writer)
        {
            // Select encoder type based on FOURCC of codec
            if (this.codec == KnownFourCCs.Codecs.Uncompressed)
                return writer.AddUncompressedVideoStream(this.Width, this.Height);
            else if (this.codec == KnownFourCCs.Codecs.MotionJpeg)
                return writer.AddMotionJpegVideoStream(this.Width, this.Height, this.quality);
            else
            {
                return writer.AddMpeg4VideoStream(this.Width, this.Height, (double)writer.FramesPerSecond,
                    // It seems that all tested MPEG-4 VfW codecs ignore the quality affecting parameters passed through VfW API
                    // They only respect the settings from their own configuration dialogs, and Mpeg4VideoEncoder currently has no support for this
                    quality: this.quality,
                    codec: this.codec,
                    // Most of VfW codecs expect single-threaded use, so we wrap this encoder to special wrapper
                    // Thus all calls to the encoder (including its instantiation) will be invoked on a single thread although encoding (and writing) is performed asynchronously
                    forceSingleThreadedAccess: true);
            }
        }
    }
}