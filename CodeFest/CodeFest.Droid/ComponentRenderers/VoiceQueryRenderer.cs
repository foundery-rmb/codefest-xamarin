using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using CodeFest.Droid;
using CodeFest.Droid.ComponentRenderers;
using CodeFest.Query;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Button = Android.Widget.Button;

[assembly: ExportRenderer(typeof(VoiceQuery), typeof(VoiceQueryRenderer))]
namespace CodeFest.Droid.ComponentRenderers
{
    class VoiceQueryRenderer : ViewRenderer<VoiceQuery, LinearLayout>
    {
        private static String mFileName = null;
        private static String LOG_TAG = "AudioRecordTest";

        private Button mRecordButton;
        private MediaRecorder mRecorder = null;

        private Button mPlayButton;
        private MediaPlayer mPlayer = null;

        bool mStartRecording = true;
        bool mStartPlaying;
        protected override void OnElementChanged(ElementChangedEventArgs<VoiceQuery> e)
        {
            LinearLayout ll = new LinearLayout(Context);
            mRecordButton = new Button(Context)
            {
                Text = "Start Recording"
            };
            ll.AddView(mRecordButton,
                new LinearLayout.LayoutParams(
                    ViewGroup.LayoutParams.WrapContent,
                    ViewGroup.LayoutParams.WrapContent,
                    0));
            mPlayButton = new Button(Context)
            {
                Text = "Start Playing"
            };
            ll.AddView(mPlayButton,
                new LinearLayout.LayoutParams(
                    ViewGroup.LayoutParams.WrapContent,
                    ViewGroup.LayoutParams.WrapContent,
                    0));

            mRecordButton.Click += (sender, args) =>
            {
                onRecord(mStartRecording);
                mRecordButton.Text = mStartRecording ? "Stop recording" : "Start recording";
                mStartRecording = !mStartRecording;
            };

            mPlayButton.Click += (sender, args) =>
            {
                onPlay(mStartPlaying);
                mPlayButton.Text = mStartPlaying ? "Stop playing" : "Start playing";
                mStartPlaying = !mStartPlaying;
            };
            SetNativeControl(ll);
        }

        private void onRecord(bool start)
        {
            if (start)
            {
                startRecording();
            }
            else
            {
                stopRecording();
            }
        }

        private void onPlay(bool start)
        {
            if (start)
            {
                startPlaying();
            }
            else
            {
                stopPlaying();
            }
        }

        private void startPlaying()
        {
            mPlayer = new MediaPlayer();
            try
            {
                mPlayer.SetDataSource(mFileName);
                mPlayer.Prepare();
                mPlayer.Start();
            }
            catch (Exception e)
            {
                Log.Error(LOG_TAG, "prepare() failed");
            }
        }

        private void stopPlaying()
        {
            mPlayer.Release();
            mPlayer = null;
        }

        private void startRecording()
        {
            mRecorder = new MediaRecorder();
            mRecorder.SetAudioSource(AudioSource.Mic);
            mRecorder.SetOutputFormat(OutputFormat.ThreeGpp);
            mRecorder.SetOutputFile(mFileName);
            mRecorder.SetAudioEncoder(AudioEncoder.AmrNb);

            try
            {
                mRecorder.Prepare();
            }
            catch (Exception e)
            {
                Log.Error(LOG_TAG, "prepare() failed");
            }

            mRecorder.Start();
        }

        private void stopRecording()
        {
            mRecorder.Stop();
            mRecorder.Release();
            mRecorder = null;
        }
    }
}