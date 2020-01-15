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
        public event EventHandler<PositionChangedEventArgs> PositionChanged /// Use unsigned int
        {
            add
            {

            }
            remove
            {

            }
        }

        public event EventHandler<PlayStateChangedEventArgs> PlayStateChanged /// Use enum PlayerState
        {
            add
            {

            }
            remove
            {

            }
        }

        public event EventHandler<TrackInfoChangedEventArgs> TrackInfoChanged /// Use class Track
        {
            add
            {

            }
            remove
            {

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
        }
        public void GetEqualizerState(EqualizerState state)
        {
        }
        public void SetRepeatMode(RepeatMode mode)
        {
        }
        public void GetRepeatMode(RepeatMode mode)
        {
        }
        public void SetShuffleMode(ShuffleMode mode)
        {
        }
        public void GetShuffleMode(ShuffleMode mode)
        {
        }
        public void SetScanMode(ScanMode mode)
        {
        }
        public void GetScanMode(ScanMode mode)
        {
        }
        public void GetPosition(ref uint position)
        {
        }
        public void GetPlayStatus(PlayerState state)
        {
        }
        public void GetTrackInfo(Track trackData)
        {
        }
        public void FreeTrackInfo(Track trackData)
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