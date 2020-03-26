/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// The default Progress style
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DefaultProgressStyle : StyleBase
    {
        /// <summary>
        /// Return default Progress style
        /// </summary>
        internal protected override ViewStyle GetViewStyle()
        {
            ProgressStyle style = new ProgressStyle
            {
                Size = new Size(200, 5),
                Track = new ImageViewStyle
                {
                    BackgroundColor = new Color(0, 0, 0, 0.1f),
                },
                Buffer = new ImageViewStyle
                {
                    BackgroundColor = new Color(0.05f, 0.63f, 0.9f, 0.3f)
                },
                Progress = new ImageViewStyle
                {
                    BackgroundColor = new Color(0.05f, 0.63f, 0.9f, 1)
                },

            };
            return style;
        }
    }
}
