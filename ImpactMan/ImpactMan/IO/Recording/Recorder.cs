namespace ImpactMan.IO.Recording
{
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Threading.Tasks;
    using SharpAvi.Output;

    public class Recorder : IDisposable
    {
        #region Fields

        private readonly AviWriter writer;
        private readonly RecorderParams Params;
        private readonly IAviVideoStream videoStream;
        private readonly Thread screenThread;
        private readonly ManualResetEvent stopThread = new ManualResetEvent(false);

        #endregion

        public Recorder(RecorderParams Params)
        {
            this.Params = Params;

            // Create AVI writer and specify FPS
            this.writer = Params.CreateAviWriter();

            // Create video stream
            this.videoStream = Params.CreateVideoStream(this.writer);
            // Set only name. Other properties were when creating stream, 
            // either explicitly by arguments or implicitly by the encoder used
            this.videoStream.Name = "Captura";

            this.screenThread = new Thread(this.RecordScreen)
            {
                Name = typeof(Recorder).Name + ".RecordScreen",
                IsBackground = true
            };

            this.screenThread.Start();
        }

        public void Dispose()
        {
            this.stopThread.Set();
            this.screenThread.Join();

            this.writer.Close();
            this.stopThread.Dispose();
        }

        public void RecordScreen()
        {
            var frameInterval = TimeSpan.FromSeconds(1 / (double)this.writer.FramesPerSecond);
            var buffer = new byte[this.Params.Width * this.Params.Height * 4];
            Task videoWriteTask = null;
            var timeTillNextFrame = TimeSpan.Zero;

            while (!this.stopThread.WaitOne(timeTillNextFrame))
            {
                var timestamp = DateTime.Now;

                this.Screenshot(buffer);

                // Wait for the previous frame is written
                videoWriteTask?.Wait();

                // Start asynchronous (encoding and) writing of the new frame
                videoWriteTask = this.videoStream.WriteFrameAsync(true, buffer, 0, buffer.Length);

                timeTillNextFrame = timestamp + frameInterval - DateTime.Now;
                if (timeTillNextFrame < TimeSpan.Zero)
                    timeTillNextFrame = TimeSpan.Zero;
            }

            // Wait for the last frame is written
            videoWriteTask?.Wait();
        }

        public void Screenshot(byte[] buffer)
        {
            using (var bmp = new Bitmap(this.Params.Width, this.Params.Height))
            {
                using (var g = Graphics.FromImage(bmp))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, new Size(this.Params.Width, this.Params.Height),
                        CopyPixelOperation.SourceCopy);

                    g.Flush();

                    var bits = bmp.LockBits(new Rectangle(0, 0, this.Params.Width, this.Params.Height), ImageLockMode.ReadOnly,
                        PixelFormat.Format32bppRgb);
                    Marshal.Copy(bits.Scan0, buffer, 0, buffer.Length);
                    bmp.UnlockBits(bits);
                }
            }
        }
    }
}