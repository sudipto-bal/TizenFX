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

namespace Tizen.Network.Bluetooth
{
    internal class BluetoothAvrcpControlImpl //implement Disposable interface
    {
        private event EventHandler<PositionChangedEventArgs> _positionChanged;
        private event EventHandler<PlayStateChangedEventArgs> _playStateChanged;
        private event EventHandler<TrackInfoChangedEventArgs> _trackInfoChanged;

        private Interop.Bluetooth.PositionChangedCallback _positionChangedCallback;
        private Interop.Bluetooth.PlayStatusChangedCallback _playStateChangedCallback;
        private Interop.Bluetooth.TrackInfoChangedCallback _trackInfoChangedCallback;

        private static BluetoothAvrcpControlImpl _instance = new BluetoothAvrcpControlImpl();

        internal event EventHandler<PositionChangedEventArgs> PositionChanged
        {
            add
            {
                if (_positionChanged == null)
                {
                    RegisterPositionChangedEvent();
                }
                _positionChanged += value;
            }
            remove
            {
                _positionChanged -= value;
                if (_positionChanged == null)
                {
                    UnregisterPositionChangedEvent();
                }
            }
        }

        internal event EventHandler<PlayStateChangedEventArgs> PlayStateChanged
        {
            add
            {
                if (_playStateChanged == null)
                {
                    RegisterPlayStateChangedEvent();
                }
                _playStateChanged += value;
            }
            remove
            {
                _playStateChanged -= value;
                if (_playStateChanged == null)
                {
                    UnregisterPlayStateChangedEvent();
                }
            }
        }

        internal event EventHandler<TrackInfoChangedEventArgs> TrackInfoChanged
        {
            add
            {
                if (_trackInfoChanged == null)
                {
                    RegisterTrackInfoChangedEvent();
                }
                _trackInfoChanged += value;
            }
            remove
            {
                _trackInfoChanged -= value;
                if (_trackInfoChanged == null)
                {
                    UnregisterTrackInfoChangedEvent();
                }
            }
        }

        private void RegisterPositionChangedEvent()
        {
            _positionChangedCallback = (uint position, IntPtr userData) =>
            {
                _positionChanged?.Invoke(null, new PositionChangedEventArgs(position));
            };
            int ret = Interop.Bluetooth.SetPositionChangedCallback(_positionChangedCallback, IntPtr.Zero);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set position changed callback, Error - " + (BluetoothError)ret);
            }
        }

        private void UnregisterPositionChangedEvent()
        {
            int ret = Interop.Bluetooth.UnsetPositionChangedCallback();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset position changed callback, Error - " + (BluetoothError)ret);
            }
        }

        private void RegisterPlayStateChangedEvent()
        {
            _playStateChangedCallback = (int state, IntPtr userdata) =>
            {
                if (_playStateChanged != null)
                {
                    PlayerState State = (PlayerState)state;
                    _playStateChanged.Invoke(null, new PlayStateChangedEventArgs(State));
                }
            };
            int ret = Interop.Bluetooth.SetPlayStatusChangedCallback(_playStateChangedCallback, IntPtr.Zero);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set play status changed callback, Error - " + (BluetoothError)ret);
            }
        }

        private void UnregisterPlayStateChangedEvent()
        {
            int ret = Interop.Bluetooth.UnsetPlayStatusChangedCallback();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset play status changed callback, Error - " + (BluetoothError)ret);
            }
        }

        private void RegisterTrackInfoChangedEvent()
        {
            _trackInfoChangedCallback = (ref TrackInfoStruct track_info, IntPtr userdata) =>
            {
                if (_trackInfoChanged != null)
                {
                    Track _track = new Track();
                    _track.Album = track_info.Album;
                    _track.Artist = track_info.Artist;
                    _track.Genre = track_info.Genre;
                    _track.Title = track_info.Title;
                    _track.TotalTracks = track_info.total_tracks;
                    _track.TrackNum = track_info.number;
                    _track.Duration = track_info.duration;
                    _trackInfoChanged.Invoke(null, new TrackInfoChangedEventArgs(_track));
                }
                int ret = Interop.Bluetooth.SetTrackInfoChangedCallback(_trackInfoChangedCallback, IntPtr.Zero);
                if (ret != (int)BluetoothError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set track info changed callback, Error - " + (BluetoothError)ret);
                }
            };

        }

        private void UnregisterTrackInfoChangedEvent()
        {
            int ret = Interop.Bluetooth.UnsetTrackInfoChangedCallback();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset track info changed callback, Error - " + (BluetoothError)ret);
            }
        }

        internal void GetEqualizerState(ref EqualizerState state)
        {
            EqualizerState _state = 0;
            int ret = Interop.Bluetooth.GetEqualizerState(ref _state);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get equalizer state " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
            else
            {
                state = _state;
            }
        }

        internal void SetEqualizerState(EqualizerState state)
        {
            int ret = Interop.Bluetooth.SetEqualizerState(state);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set equalizer state to " + state + " - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        internal void GetRepeatMode(ref RepeatMode mode)
        {
            RepeatMode _mode = 0;
            int ret = Interop.Bluetooth.GetRepeatMode(ref _mode);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get repeat mode" + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
            else
            {
                mode = _mode;
            }
        }

        internal void SetRepeatMode(RepeatMode mode)
        {
            int ret = Interop.Bluetooth.SetRepeatMode(mode);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set repeat mode to " + mode + " - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        internal void GetShuffleMode(ref ShuffleMode mode)
        {
            ShuffleMode _mode = 0;
            int ret = Interop.Bluetooth.GetShuffleMode(ref _mode);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get shuffle mode" + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
            else
            {
                mode = _mode;
            }
        }

        internal void SetShuffleMode(ShuffleMode mode)
        {
            int ret = Interop.Bluetooth.SetShuffleMode(mode);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set shuffle mode to " + mode + " - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        internal void GetScanMode(ref ScanMode mode)
        {
            ScanMode _mode = 0;
            int ret = Interop.Bluetooth.GetScanMode(ref _mode);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get scan mode" + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
            else
            {
                mode = _mode;
            }
        }

        internal void SetScanMode(ScanMode mode)
        {
            int ret = Interop.Bluetooth.SetScanMode(mode);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set scan mode to " + mode + " - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        internal void SetAbsoluteVolume(uint volume)
        {
            int ret = Interop.Bluetooth.SetAbsoluteVolume(volume);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set absolute volume to level " + volume + " - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        internal static BluetoothAvrcpControlImpl Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}