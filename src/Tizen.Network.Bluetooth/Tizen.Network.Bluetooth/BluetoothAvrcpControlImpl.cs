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
                    //handling after function implementation;
                }
                _playStateChanged += value;
            }
            remove
            {
                _playStateChanged -= value;
                if (_playStateChanged == null)
                {
                    //handling after function implementation;
                }
            }
        }

        internal event EventHandler<TrackInfoChangedEventArgs> TrackInfoChanged
        {
            add
            {
                if (_trackInfoChanged == null)
                {
                    //handling after function implementation;
                }
                _trackInfoChanged += value;
            }
            remove
            {
                _trackInfoChanged -= value;
                if (_trackInfoChanged == null)
                {
                    //handling after function implementation;
                }
            }
        }

        private void RegisterPositionChangedEvent()
        {
            _positionChangedCallback = (int position, IntPtr userData) =>
            {
                if (_positionChanged != null)
                {
                    //_positionChanged(null, new PositionChangedEventArgs(position));
                    //Invoke Event after implementing the class PositionChangedEventArgs
                }
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

        internal static BluetoothAvrcpControlImpl Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}