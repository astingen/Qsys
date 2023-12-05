﻿using System;
using QscQsys.NamedComponents;

namespace QscQsys.Utils
{
    public static class ControlNameUtils
    {

        private const string MUTE = "mute";
        private const string GAIN = "gain";
        private const string THRESHOLD = "threshold";
        private const string HOLD_TIME = "hold_time";
        private const string INFINITE_HOLD = "infinite_hold";
        private const string SIGNAL_PRESENCE = "signal_presence";

        private const string MATRIX_MIXER_CONTROL_NAME_FORMAT = "input_{0}_output_{1}_{2}";
        private const string METER_NAME_FORMAT = "meter_{0}";
        private const string ROUTER_SELECT_NAME_FORMAT = "select_{0}";
        private const string ROUTER_MUTE_NAME_FORMAT = "mute_{0}";
        private const string AV_STREAM_ROUTER_SELECT_NAME_FORMAT = "output_{0}_select";
        private const string SIGNAL_PRESENCE_METER_CONTROL_NAME_FORMAT = SIGNAL_PRESENCE + "_{0}";
        private const string SNAPSHOT_LOAD_CONTROL_NAME_FORMAT = "load_{0}";
        private const string SNAPSHOT_SAVE_CONTROL_NAME_FORMAT = "save_{0}";
        private const string ROOM_COMBINER_WALL_OPEN_NAME_FORMAT = "wall_{0}_open";
        private const string ROOM_COMBINER_OUTPUT_COMBINED_NAME_FORMAT = "output_{0}_combined";


        public static string GetMatrixCrosspointMuteName(int input, int output)
        {
            return string.Format(MATRIX_MIXER_CONTROL_NAME_FORMAT, input, output, MUTE);
        }

        public static string GetMatrixCrosspointGainName(int input, int output)
        {
            return string.Format(MATRIX_MIXER_CONTROL_NAME_FORMAT, input, output, GAIN);
        }

        public static string GetMeterName(int index)
        {
            return string.Format(METER_NAME_FORMAT, index);
        }

        public static string GetRouterSelectName(int output)
        {
            return string.Format(ROUTER_SELECT_NAME_FORMAT, output);
        }

        public static string GetRouterMuteName(int output)
        {
            return string.Format(ROUTER_MUTE_NAME_FORMAT, output);
        }

        public static string GetAvStreamRouterSelectName(int output)
        {
            return string.Format(AV_STREAM_ROUTER_SELECT_NAME_FORMAT, output);
        }

        public static string GetSignalPresenceMeterName(int index, int totalCount)
        {
            // special case handling - if only 1, index isn't used
            if (totalCount == 1 && index == 1)
                return SIGNAL_PRESENCE;
            
            return string.Format(SIGNAL_PRESENCE_METER_CONTROL_NAME_FORMAT, index);
        }

        public static string GetSnapshotLoadControlName(int index)
        {
            return string.Format(SNAPSHOT_LOAD_CONTROL_NAME_FORMAT, index);
        }

        public static string GetSnapshotSaveControlName(int index)
        {
            return string.Format(SNAPSHOT_SAVE_CONTROL_NAME_FORMAT, index);
        }

        public static string GetRoomCombinerWallOpenName(int index)
        {
            return string.Format(ROOM_COMBINER_WALL_OPEN_NAME_FORMAT, index);
        }

        public static string GetRoomCombinerOutputCombinedName(int index)
        {
            return string.Format(ROOM_COMBINER_OUTPUT_COMBINED_NAME_FORMAT, index);
        }

        public static string GetMuteControlName()
        {
            return MUTE;
        }

        public static string GetGainControlName()
        {
            return GAIN;
        }

        public static string GetThresholdControlName()
        {
            return THRESHOLD;
        }

        public static string GetHoldTimeControlName()
        {
            return HOLD_TIME;
        }

        public static string GetInfiniteHoldControlName()
        {
            return INFINITE_HOLD;
        }

        public static string GetControlNameForPtzType(QsysCamera.PtzTypes type)
        {
            switch (type)
            {
                case QsysCamera.PtzTypes.Up:
                    return "tilt_up";
                case QsysCamera.PtzTypes.Down:
                    return "tilt_down";
                case QsysCamera.PtzTypes.Left:
                    return "pan_left";
                case QsysCamera.PtzTypes.Right:
                    return "pan_right";
                case QsysCamera.PtzTypes.ZoomIn:
                    return "zoom_in";
                case QsysCamera.PtzTypes.ZoomOut:
                    return "zoom_out";
                default:
                    throw new ArgumentOutOfRangeException("type");
            }
        }
    }
}