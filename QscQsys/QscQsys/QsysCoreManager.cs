﻿using System;
using System.Collections.Generic;
using Crestron.SimplSharp;

namespace QscQsys
{
    internal class QsysCoreManager
    {
        private static readonly object _coresLock = new object();
        internal static Dictionary<string, QsysCore> Cores = new Dictionary<string, QsysCore>();

        internal static event EventHandler<CoreAddedEventArgs> CoreAdded;
        internal static event EventHandler<CoreRemovedEventArgs> CoreRemoved;

        internal static bool Is3Series
        {
            get
            {
                return InitialParametersClass.ControllerPromptName.Contains("3");
            }
        }

        internal static void AddCore(QsysCore core)
        {
            try
            {
                lock (_coresLock)
                {
                    if (!Cores.ContainsKey(core.CoreId))
                    {
                        Cores.Add(core.CoreId, core);

                        OnCoreAdded(new CoreAddedEventArgs(core.CoreId));
                    }
                }
            }
            catch (Exception e)
            {
                ErrorLog.Error("Error in QsysCoreManager AddCore: {0}", e.Message);
            }
        }

        internal static void RemoveCore(QsysCore core)
        {
            try
            {
                lock (_coresLock)
                {
                    if(Cores.ContainsKey(core.CoreId))
                    {
                        Cores.Remove(core.CoreId);

                        OnCoreRemoved(new CoreRemovedEventArgs(core.CoreId));
                    }
                }
            }
            catch (Exception e)
            {
                ErrorLog.Error("Error in QsysCoreManager RemoveCore: {0}", e.Message);
            }
        }

        private static void OnCoreAdded(CoreAddedEventArgs e)
        {
            EventHandler<CoreAddedEventArgs> handler = CoreAdded; ;

            if (handler != null)
            {
                handler(null, e);
            }
        }

        private static void OnCoreRemoved(CoreRemovedEventArgs e)
        {
            EventHandler<CoreRemovedEventArgs> handler = CoreRemoved;

            if (handler != null)
            {
                handler(null, e);
            }
        }

        internal static double ScaleUp(double level)
        {
            double scaleLevel = level;
            double levelScaled = (scaleLevel * 65535.0);
            return levelScaled;
        }

        internal static double ScaleDown(double level)
        {
            double scaleLevel = level;
            double levelScaled = (scaleLevel / 65535.0);
            return levelScaled;
        }
    }
}