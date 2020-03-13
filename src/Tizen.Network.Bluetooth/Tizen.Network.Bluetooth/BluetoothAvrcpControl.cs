/*
 * Copyright (c) 2020 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */


using System;
using System.Threading.Tasks;

namespace Tizen.Network.Bluetooth
{
    /// <summary>
    /// This class is used to send commands from the control device (For example, headset) to the target device (For example, media player).
    /// </summary>
    /// <privilege> http://tizen.org/privilege/bluetooth </privilege>
    /// <since_tizen> 8 </since_tizen>
    public class BluetoothAvrcpControl : BluetoothProfile
    {
        private TaskCompletionSource<bool> _taskForConnection;
        private TaskCompletionSource<bool> _taskForDisconnection;
        public event EventHandler<PositionChangedEventArgs> PositionChanged
        {
            add
            {
                BluetoothAvrcpControlImpl.Instance.PositionChanged += value;
            }
            remove
            {
                BluetoothAvrcpControlImpl.Instance.PositionChanged -= value;
            }
        }

        public event EventHandler<PlayStateChangedEventArgs> PlayStateChanged
        {
            add
            {
                BluetoothAvrcpControlImpl.Instance.PlayStateChanged += value;
            }
            remove
            {
                BluetoothAvrcpControlImpl.Instance.PlayStateChanged -= value;
            }
        }

        public event EventHandler<TrackInfoChangedEventArgs> TrackInfoChanged
        {
            add
            {
                BluetoothAvrcpControlImpl.Instance.TrackInfoChanged += value;
            }
            remove
            {
                BluetoothAvrcpControlImpl.Instance.TrackInfoChanged -= value;
            }
        }

        public Task ConnectAsync(string remote_address)
        {
            return _taskForConnection.Task;
        }
        public Task DisonnectAsync(string remote_address)
        {
            return _taskForDisconnection.Task;
        }
        public void SetEqualizerState(EqualizerState state)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                BluetoothAvrcpControlImpl.Instance.SetEqualizerState(state);
            }
            else
            {
                if (!Globals.IsAudioInitialize)
                {
                    if (!Globals.IsInitialize)
                    {
                        Log.Error(Globals.LogTag, "Bluetooth Not Initialized");
                    }
                    Log.Error(Globals.LogTag, "Audio Not Initialized");
                }
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        public EqualizerState GetEqualizerState()
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize)
            {
                return BluetoothAvrcpControlImpl.Instance.GetEqualizerState();
            }
            else
            {
                if (!Globals.IsAudioInitialize)
                {
                    if (!Globals.IsInitialize)
                    {
                        Log.Error(Globals.LogTag, "Bluetooth Not Initialized");
                    }
                    Log.Error(Globals.LogTag, "Audio Not Initialized");
                }
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
                return EqualizerState.Off;
            }
        }

        public void SetRepeatMode(RepeatMode mode)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize && Globals.IsAudioInitialize)
            {
                BluetoothAvrcpControlImpl.Instance.SetRepeatMode(mode);
            }
            else
            {
                if (!Globals.IsAudioInitialize)
                {
                    if (!Globals.IsInitialize)
                    {
                        Log.Error(Globals.LogTag, "Bluetooth Not Initialized");
                    }
                    Log.Error(Globals.LogTag, "Audio Not Initialized");
                }
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }

        public RepeatMode GetRepeatMode()
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize && Globals.IsAudioInitialize)
            {
                return BluetoothAvrcpControlImpl.Instance.GetRepeatMode();
            }
            else
            {
                if (!Globals.IsAudioInitialize)
                {
                    if (!Globals.IsInitialize)
                    {
                        Log.Error(Globals.LogTag, "Bluetooth Not Initialized");
                    }
                    Log.Error(Globals.LogTag, "Audio Not Initialized");
                }
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
            return RepeatMode.Off;
        }
        public void SetShuffleMode(ShuffleMode mode)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize && Globals.IsAudioInitialize)
            {
                BluetoothAvrcpControlImpl.Instance.SetShuffleMode(mode);
            }
            else
            {
                if (!Globals.IsAudioInitialize)
                {
                    if (!Globals.IsInitialize)
                    {
                        Log.Error(Globals.LogTag, "Bluetooth Not Initialized");
                    }
                    Log.Error(Globals.LogTag, "Audio Not Initialized");
                }
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }
        public ShuffleMode GetShuffleMode()
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize && Globals.IsAudioInitialize)
            {
                return BluetoothAvrcpControlImpl.Instance.GetShuffleMode();
            }
            else
            {
                if (!Globals.IsAudioInitialize)
                {
                    if (!Globals.IsInitialize)
                    {
                        Log.Error(Globals.LogTag, "Bluetooth Not Initialized");
                    }
                    Log.Error(Globals.LogTag, "Audio Not Initialized");
                }
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
            return ShuffleMode.Off;
        }
        public void SetScanMode(ScanMode mode)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize && Globals.IsAudioInitialize)
            {
                BluetoothAvrcpControlImpl.Instance.SetScanMode(mode);
            }
            else
            {
                if (!Globals.IsAudioInitialize)
                {
                    if (!Globals.IsInitialize)
                    {
                        Log.Error(Globals.LogTag, "Bluetooth Not Initialized");
                    }
                    Log.Error(Globals.LogTag, "Audio Not Initialized");
                }
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }
        public ScanMode GetScanMode()
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize && Globals.IsAudioInitialize)
            {
                return BluetoothAvrcpControlImpl.Instance.GetScanMode();
            }
            else
            {
                if (!Globals.IsAudioInitialize)
                {
                    if (!Globals.IsInitialize)
                    {
                        Log.Error(Globals.LogTag, "Bluetooth Not Initialized");
                    }
                    Log.Error(Globals.LogTag, "Audio Not Initialized");
                }
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
            return ScanMode.Off;
        }
        public uint GetPosition()
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize && Globals.IsAudioInitialize)
            {
                return BluetoothAvrcpControlImpl.Instance.GetPosition();
            }
            else
            {
                if (!Globals.IsAudioInitialize)
                {
                    if (!Globals.IsInitialize)
                    {
                        Log.Error(Globals.LogTag, "Bluetooth Not Initialized");
                    }
                    Log.Error(Globals.LogTag, "Audio Not Initialized");
                }
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
            return 0;
        }
        public PlayerState GetPlayStatus()
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize && Globals.IsAudioInitialize)
            {
                return BluetoothAvrcpControlImpl.Instance.GetPlayStatus();
            }
            else
            {
                if (!Globals.IsAudioInitialize)
                {
                    if (!Globals.IsInitialize)
                    {
                        Log.Error(Globals.LogTag, "Bluetooth Not Initialized");
                    }
                    Log.Error(Globals.LogTag, "Audio Not Initialized");
                }
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
            return PlayerState.Stopped;
        }
        public Track GetTrackInfo()
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize && Globals.IsAudioInitialize)
            {
                return BluetoothAvrcpControlImpl.Instance.GetTrackInfo();
            }
            else
            {
                if (!Globals.IsAudioInitialize)
                {
                    if (!Globals.IsInitialize)
                    {
                        Log.Error(Globals.LogTag, "Bluetooth Not Initialized");
                    }
                    Log.Error(Globals.LogTag, "Audio Not Initialized");
                }
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
            return null;
        }
        public void FreeTrackInfo(Track trackData) //needs special testing
        {

        }
        public void SendPlayerCommand(PlayerCommand command)
        {
        }
        public void SendPlayerCommandTo(PlayerCommand command, string remote_address)
        {
        }
        public void SetAbsoluteVolume(uint volume)
        {
            if (BluetoothAdapter.IsBluetoothEnabled && Globals.IsInitialize && Globals.IsAudioInitialize)
            {
                Interop.Bluetooth.SetAbsoluteVolume(volume);
            }
            else
            {
                if (!Globals.IsAudioInitialize)
                {
                    if (!Globals.IsInitialize)
                    {
                        Log.Error(Globals.LogTag, "Bluetooth Not Initialized");
                    }
                    Log.Error(Globals.LogTag, "Audio Not Initialized");
                }
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NotEnabled);
            }
        }
        public void IncreaseVolume()
        {
        }
        public void DecreaseVolume()
        {
        }
        public void SendDelayReport(uint value)
        {
        }
    }
}