using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Android.Content;
using Android.Media;
using Android.Util;
using Android.Widget;
using CodeFest.Droid.ComponentRenderers;
using CodeFest.Query;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Button = Android.Widget.Button;

[assembly: ExportRenderer(typeof(VoiceQuery), typeof(VoiceQueryRenderer))]

namespace CodeFest.Droid.ComponentRenderers
{
    internal class VoiceQueryRenderer : ViewRenderer<VoiceQuery, LinearLayout>
    {
        private static readonly string LOG_TAG = "AudioRecordTest";
        private int _bufferSizeInBytes;
        private List<byte> _data;
        private bool _recording;

        private AudioRecord audRecorder;
        private CancellationTokenSource cts;

        private Button mRecordButton;

        protected override void OnElementChanged(ElementChangedEventArgs<VoiceQuery> e)
        {
            _bufferSizeInBytes = AudioRecord.GetMinBufferSize(16000,
                ChannelIn.Mono,
                Encoding.Pcm16bit);
            _data = new List<byte>(_bufferSizeInBytes*10);

            var ll = new LinearLayout(Context);
            mRecordButton = new Button(Context)
            {
                Text = "Start Recording"
            };
            ll.AddView(mRecordButton,
                new LinearLayout.LayoutParams(
                    LayoutParams.WrapContent,
                    LayoutParams.WrapContent,
                    0));

            mRecordButton.Click += async (sender, args) =>
            {
                if (!_recording)
                {
                    _recording = true;
                    cts = new CancellationTokenSource();

                    try
                    {
                        mRecordButton.Text = "Stop Recording";
                        await RecordAudioAndSend(cts.Token);
                    }
                    catch (OperationApplicationException)
                    {
                        audRecorder.Stop();
                        audRecorder.Release();
                    }
                    catch (Exception)
                    {
                        audRecorder.Stop();
                        audRecorder.Release();
                    }
                }
                else
                {
                    _recording = false;
                    mRecordButton.Text = "Start Recording";
                    cts.Cancel();
                    audRecorder.Stop();
                    audRecorder.Release();
                    Element.ActivityIndicator.IsRunning = true;
                    var result = await new SpeechService().RecognizeAsync(Base64.EncodeToString(_data.ToArray(),
                        Base64Flags.NoWrap));
                    Element.ActivityIndicator.IsRunning = false;
                    _data = new List<byte>(_bufferSizeInBytes);
                    Element.DisplayResult(result);
                }
            };
            SetNativeControl(ll);
        }

        public async Task RecordAudioAndSend(CancellationToken ct)
        {
            var audioBuffer = new byte[_bufferSizeInBytes];

            audRecorder = new AudioRecord(AudioSource.Mic,
                16000,
                ChannelIn.Mono,
                Encoding.Pcm16bit,
                _bufferSizeInBytes);

            // You might need to slow things down to have a chance to cancel.
            await Task.Delay(41, ct);

            await Task.Run(() =>
            {
                audRecorder.StartRecording();
                while (!cts.IsCancellationRequested)
                    try
                    {
                        //get current timestamp
                        // Keep reading the buffer while there is audio input.
                        audRecorder.Read(audioBuffer, 0, audioBuffer.Length);
                        _data.AddRange(audioBuffer);
                    }
                    catch (Exception ex)
                    {
                        Console.Out.WriteLine(ex.Message);
                        break;
                    }
            }, ct);
        }
    }
}